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
    public partial class FrmNhapXuatExecl : Form
    {
        DataSet ds;
        public FrmNhapXuatExecl()
        {
            InitializeComponent();
        }

        public FrmNhapXuatExecl(int index)
        {
            InitializeComponent();
            cbbType.SelectedIndex = index - 1;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi, con vo ga: " + ex.Message);
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbKQ.Text = "Đang đọc dữ liệu của sheet " + cbSheet.Text + " ...";
            dataGridView1.DataSource = ds.Tables[cbSheet.SelectedIndex];
            Utils.themSTT(dataGridView1);
            lbKQ.Text = "Sheet " + cbSheet.Text + " có " + dataGridView1.Rows.Count + " bản ghi!";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var listData = dataGridView1.DataSource;
                Console.WriteLine(dataGridView1.Rows.Count);
                List<NhapXuatTon> lstData = new List<NhapXuatTon>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var item = new NhapXuatTon();
                    if (dataGridView1.Columns.Contains("Mã sản phẩm") == true)
                        item.product_code = row.Cells["Mã sản phẩm"].Value == null ? "" : row.Cells["Mã sản phẩm"].Value.ToString().Trim().ToUpper();
                    else
                        if (dataGridView1.Columns.Contains("Mã đơn hàng") == true)
                            item.product_code = row.Cells["Mã đơn hàng"].Value == null ? "" : row.Cells["Mã đơn hàng"].Value.ToString().Trim().ToUpper();
                        else
                            if (dataGridView1.Columns.Contains("Sản phẩm") == true)
                                item.product_code = row.Cells["Sản phẩm"].Value == null ? "" : row.Cells["Sản phẩm"].Value.ToString().Trim().ToUpper();
                    if (dataGridView1.Columns.Contains("Mã mẫu mã") == true)
                        item.color_code = row.Cells["Mã mẫu mã"].Value == null ? "" : row.Cells["Mã mẫu mã"].Value.ToString().Trim().ToUpper();
                    else
                        if (dataGridView1.Columns.Contains("Mã màu") == true)
                            item.color_code = row.Cells["Mã màu"].Value == null ? "" : row.Cells["Mã màu"].Value.ToString().Trim().ToUpper();
                        else
                            if (dataGridView1.Columns.Contains("Màu") == true)
                                item.color_code = row.Cells["Màu"].Value == null ? "" : row.Cells["Màu"].Value.ToString().Trim().ToUpper();
                            else
                                if (dataGridView1.Columns.Contains("Color") == true)
                                    item.color_code = row.Cells["Color"].Value == null ? "" : row.Cells["Color"].Value.ToString().Trim().ToUpper();
                    if (dataGridView1.Columns.Contains("Mã kích cỡ") == true)
                        item.size_code = row.Cells["Mã kích cỡ"].Value == null ? "" : row.Cells["Mã kích cỡ"].Value.ToString().Trim().ToUpper();
                    else
                        if (dataGridView1.Columns.Contains("Kích cỡ") == true)
                            item.size_code = row.Cells["Kích cỡ"].Value == null ? "" : row.Cells["Kích cỡ"].Value.ToString().Trim().ToUpper();
                        else
                            if (dataGridView1.Columns.Contains("Size") == true)
                                item.size_code = row.Cells["Size"].Value == null ? "" : row.Cells["Size"].Value.ToString().Trim().ToUpper();
                    if (dataGridView1.Columns.Contains("Số lượng") == true)
                        item.quantity = Convert.ToInt32(row.Cells["Số lượng"].Value == null ? "0" : row.Cells["Số lượng"].Value.ToString().Trim());
                    if (dataGridView1.Columns.Contains("Đơn giá") == true)
                        item.price = Convert.ToInt32(row.Cells["Đơn giá"].Value == null ? "0" : row.Cells["Đơn giá"].Value.ToString().Trim());

                    
                    item.type = cbbType.SelectedIndex+1;
                    item.nxt_date = dtPickerDS.Value.Date;
                    item.created_date = DateTime.Now;
                    
                    lstData.Add(item);
                }
                Console.WriteLine(lstData.Count);


                int n = DBHelper.InsertNhapXuatTons(lstData);
            }
            catch (Exception exx)
            {
                MessageBox.Show("Dữ liệu đầu vào bị sai gì đó rồi vợ, kiểm tra và thử lại nhé. \nChi tiết: " + exx.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
