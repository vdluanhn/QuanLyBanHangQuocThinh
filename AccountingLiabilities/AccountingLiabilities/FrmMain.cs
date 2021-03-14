using AccountingLiabilities.Utilities;
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
            lbTenFile.Text = "Đang đọc dữ liệu file....";
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
                        lbTenFile.Text = Path.GetFileName(ofd.FileName); 
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Loi, con vo ga: " + ex.Message);
            }
            
        }
        private void themSTT(DataGridView gridView)
        {
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                gridView.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbKQ.Text = "Đang đọc dữ liệu của sheet " + cbSheet.Text+" ...";
            dataGridView1.DataSource = ds.Tables[cbSheet.SelectedIndex];
            Utils.themSTT(dataGridView1);
            lbKQ.Text = "Sheet " + cbSheet.Text + " có " + dataGridView1.Rows.Count + " bản ghi!";
        }

        private void btnImportDonDi_Click(object sender, EventArgs e)
        {
            try
            {
                var listData = dataGridView1.DataSource;
                Console.WriteLine(dataGridView1.Rows.Count);
                List<DonDi> lstData = new List<DonDi>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var item = new DonDi();
                    if (dataGridView1.Columns.Contains("Mã đơn hàng") == true)
                        item.code = row.Cells["Mã đơn hàng"].Value == null ? "" : row.Cells["Mã đơn hàng"].Value.ToString().Trim();
                    if (dataGridView1.Columns.Contains("Tên khách hàng") == true)
                        item.cust_name = row.Cells["Tên khách hàng"].Value == null ? "" : row.Cells["Tên khách hàng"].Value.ToString().Trim();
                    if (dataGridView1.Columns.Contains("Địa chỉ") == true)
                        item.cust_address = row.Cells["Địa chỉ"].Value == null ? "" : row.Cells["Địa chỉ"].Value.ToString();
                    if (dataGridView1.Columns.Contains("Số điện thoại") == true)
                        item.cust_mobile = row.Cells["Số điện thoại"].Value == null ? "" : row.Cells["Số điện thoại"].Value.ToString().Trim();
                    if (dataGridView1.Columns.Contains("Mô tả") == true)
                        item.description = row.Cells["Mô tả"].Value == null ? "" : row.Cells["Mô tả"].Value.ToString().Trim();
                    if (dataGridView1.Columns.Contains("pos") == true)
                        item.description = row.Cells["pos"].Value == null ? "" : row.Cells["pos"].Value.ToString();
                    if (dataGridView1.Columns.Contains("Trạng thái") == true)
                        item.status = row.Cells["Trạng thái"].Value == null ? "" : row.Cells["Trạng thái"].Value.ToString().Trim();
                    if (dataGridView1.Columns.Contains("Ngày xuất đơn") == true)
                        item.out_date = Convert.ToDateTime(row.Cells["Ngày xuất đơn"].Value);
                    else item.out_date = dtPickerDS.Value;
                    if (dataGridView1.Columns.Contains("Số tiền") == true)
                        item.amount = Convert.ToInt32(row.Cells["Số tiền"].Value);
                    else if (dataGridView1.Columns.Contains("Tiền COD") == true)
                        item.amount = Convert.ToInt32(row.Cells["Tiền COD"].Value);
                    item.partners = cbbPartner.Text.Trim();
                    lstData.Add(item);
                }
                Console.WriteLine(lstData.Count);


                int n = DBHelper.InsertDonDis(lstData);
            }
            catch (Exception exx)
            {
                MessageBox.Show("Dữ liệu đầu vào bị sai gì đó rồi vợ, kiểm tra và thử lại nhé. \nChi tiết: " + exx.ToString());
            }
            
        }
        int n1 = 0;
        private void btnImportDS_Click(object sender, EventArgs e)
        {
            try
            {
                var listData = dataGridView1.DataSource;
                Console.WriteLine(dataGridView1.Rows.Count);
                List<DoiSoatVanChuyen> lstData = new List<DoiSoatVanChuyen>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    n1++;
                    if (n1==639)
                    {
                        Console.WriteLine("gia tri: "+row.Cells["Tiền COD"].Value);
                    }
                    var item = new DoiSoatVanChuyen();
                    if (dataGridView1.Columns.Contains("Mã đơn hàng") == true)
                        item.code = row.Cells["Mã đơn hàng"].Value == null ? "" : row.Cells["Mã đơn hàng"].Value.ToString().Trim();
                    else if (dataGridView1.Columns.Contains("Tracking number") == true)
                        item.code = row.Cells["Tracking number"].Value == null ? "" : row.Cells["Tracking number"].Value.ToString().Trim();
                    if (dataGridView1.Columns.Contains("Tiền thu hộ") == true)
                        item.collection_amount = (row.Cells["Tiền thu hộ"].Value == null || row.Cells["Tiền thu hộ"].Value=="")?0 : Convert.ToInt32(row.Cells["Tiền thu hộ"].Value);
                    else if (dataGridView1.Columns.Contains("Tiền COD") == true)
                        item.collection_amount = (row.Cells["Tiền COD"].Value == null || row.Cells["Tiền COD"].Value == "") ? 0 : Convert.ToInt32(row.Cells["Tiền COD"].Value);
                    if (dataGridView1.Columns.Contains("Phí giao hàng") == true)
                        item.delivery_fee = Convert.ToInt32(row.Cells["Phí giao hàng"].Value);
                    if (dataGridView1.Columns.Contains("Phí chuyển hoàn") == true)
                        item.refund_fee = Convert.ToInt32(row.Cells["Phí chuyển hoàn"].Value);
                    item.finish_date = dtPickerDS.Value;
                    if (dataGridView1.Columns.Contains("Mã đơn hàng shop") == true)
                        item.code_shop = row.Cells["Mã đơn hàng shop"].Value == null ? "" : row.Cells["Mã đơn hàng shop"].Value.ToString();
                    if (dataGridView1.Columns.Contains("Thanh toán") == true)
                        item.amount = Convert.ToInt32(row.Cells["Thanh toán"].Value);
                    item.partners = cbbPartner.Text;
               
                    item.created_date = DateTime.Now;
                    lstData.Add(item);
                }
                Console.WriteLine(lstData.Count);


                int n = DBHelper.InsertDoiSoatVanChuyens(lstData);
            }
            catch (Exception exx)
            {
                MessageBox.Show("Loi dong "+n1+" -Dữ liệu đầu vào bị sai gì đó rồi vợ, kiểm tra và thử lại nhé. \nChi tiết: " + exx.ToString());
            }
        }

        private void btnDonHOanThucTe_Click(object sender, EventArgs e)
        {
            try { 
                var listData = dataGridView1.DataSource;
                Console.WriteLine(dataGridView1.Rows.Count);
                List<DonDaHoanTraThucTe> lstData = new List<DonDaHoanTraThucTe>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var item = new DonDaHoanTraThucTe();
                    item.sub_code = row.Cells["Mã đơn hàng"].Value == null ? "" : row.Cells["Mã đơn hàng"].Value.ToString().Trim();
                    item.org_delivery = cbbPartner.Text.Trim();
                    item.partners = cbbPartner.Text.Trim();
                    item.cross_check_date = dtPickerDS.Value;
                    item.created_date = DateTime.Now;
                    lstData.Add(item);
                }
                Console.WriteLine(lstData.Count);


                int n = DBHelper.InsertDonHoanTraThucTes(lstData);
            }
            catch (Exception exx)
            {
                MessageBox.Show("Dữ liệu đầu vào bị sai gì đó rồi vợ, kiểm tra và thử lại nhé. \nChi tiết: "+exx.ToString());
            }
}
    }
}
