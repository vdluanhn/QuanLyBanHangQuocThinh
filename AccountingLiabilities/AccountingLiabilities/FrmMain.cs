using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingLiabilities
{
    public partial class FrmMain : Form
    {
        DataSet ds;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            IExcelDataReader reader;
                            if (ofd.FilterIndex == 2)
                            {
                                reader = ExcelReaderFactory.CreateBinaryReader(stream);
                            }
                            else
                            {
                                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            }

                            ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            cbSheet.Items.Clear();
                            foreach (DataTable dt in ds.Tables)
                            {
                                cbSheet.Items.Add(dt.TableName);
                            }
                            reader.Close();

                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Loi, con vo ga: " + ex.Message);
            }
            
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }

        private void btnImportDonDi_Click(object sender, EventArgs e)
        {
            var listData = dataGridView1.DataSource;
            Console.WriteLine(dataGridView1.Rows.Count);
            List<DonDi> lstData = new List<DonDi>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var item = new DonDi();
                item.code = row.Cells["Mã đơn hàng"].Value==null?"": row.Cells["Mã đơn hàng"].Value.ToString();
                item.cust_name = row.Cells["Tên khách hàng"].Value == null ? "" : row.Cells["Tên khách hàng"].Value.ToString();
                item.cust_address = row.Cells["Địa chỉ"].Value == null ? "" : row.Cells["Địa chỉ"].Value.ToString();
                item.cust_mobile = row.Cells["Số điện thoại"].Value == null ? "" : row.Cells["Số điện thoại"].Value.ToString();
                item.description = row.Cells["Mô tả"].Value == null ? "" : row.Cells["Mô tả"].Value.ToString();
                item.out_date = Convert.ToDateTime(row.Cells["Ngày xuất đơn"].Value);
                item.amount = Convert.ToInt32(row.Cells["Số tiền"].Value);
                lstData.Add(item);
            }
            Console.WriteLine(lstData.Count);


            DBHelper.InsertDonDis(lstData);
            MessageBox.Show("Import danh sách thành công "+ lstData.Count + " (đơn hàng)!");
        }

        private void btnImportDS_Click(object sender, EventArgs e)
        {
            var listData = dataGridView1.DataSource;
            Console.WriteLine(dataGridView1.Rows.Count);
            List<DoiSoatVanChuyen> lstData = new List<DoiSoatVanChuyen>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var item = new DoiSoatVanChuyen();
                item.code = row.Cells["Mã đơn hàng"].Value == null ? "" : row.Cells["Mã đơn hàng"].Value.ToString();
                item.collection_amount = Convert.ToInt32(row.Cells["Tiền thu hộ"].Value);
                item.delivery_fee = Convert.ToInt32(row.Cells["Phí giao hàng"].Value);
                item.refund_fee = Convert.ToInt32(row.Cells["Phí chuyển hoàn"].Value);
                item.finish_date = dtPickerDS.Value;
                item.code_shop = row.Cells["Mã đơn hàng shop"].Value == null ? "" : row.Cells["Mã đơn hàng shop"].Value.ToString();
                item.amount = Convert.ToInt32(row.Cells["Thanh toán"].Value);
                item.created_date = DateTime.Now;
                lstData.Add(item);
            }
            Console.WriteLine(lstData.Count);


            DBHelper.InsertDoiSoatVanChuyens(lstData);

            MessageBox.Show("Import danh sách thành công "+lstData.Count+" (đơn hàng)!");
        }
    }
}
