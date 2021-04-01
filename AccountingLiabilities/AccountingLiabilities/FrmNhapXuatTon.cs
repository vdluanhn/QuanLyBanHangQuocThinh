using AccountingLiabilities.Utilities;
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
    public partial class FrmNhapXuatTon : Form
    {
        public FrmNhapXuatTon()
        {
            InitializeComponent();
            dtFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtTo.Value = DateTime.Now.Date;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmNhapHang nhapHang = new FrmNhapHang(2);
            nhapHang.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmXuatHang xuatHang = new FrmXuatHang(3);
            xuatHang.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbKQ.Text = "Đang tìm kiếm....";
            try
            {
                string keyword = txtKeyword.Text.Trim();
                DateTime fromDate = dtFrom.Value.Date;
                DateTime toDate = dtTo.Value.Date.AddDays(1);
                int type = 0;
                if (cbbType.SelectedIndex != null)
                {
                    type = cbbType.SelectedIndex;
                }
                using (var db = new DBQuocThinhEntities())
                {
                    if (type==0)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAM(keyword,fromDate, toDate).OrderBy(x => x.code).Select(x=> new { product_code = x.code, color_code ="", size_code = "", x.slTonDau, x.slNhap, x.slXuat, x.slTon });
                        dataGridView1.DataSource = datas.ToList();
                    }
                    if (type == 1)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAMCOLOR(keyword, fromDate, toDate).OrderBy(p => p.product_code).ThenBy(c => c.color_code).Select(x => new { product_code = x.product_code, color_code=x.color_code, size_code = "", x.slTonDau, x.slNhap, x.slXuat, x.slTon });
                        dataGridView1.DataSource = datas.ToList();
                    }
                    if (type == 2)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAMSIZE(keyword, fromDate, toDate).OrderBy(p => p.product_code).ThenBy(s => s.size_code).Select(x => new { product_code = x.product_code, color_code = "", size_code =x.size_code, x.slTonDau, x.slNhap, x.slXuat, x.slTon });
                        dataGridView1.DataSource = datas.ToList();
                    }
                    if (type == 3)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAMCOLORSIZE(keyword, fromDate, toDate).OrderBy(p => p.product_code).ThenBy(c => c.color_code).ThenBy(s => s.size_code).Select(x => new { product_code = x.product_code, color_code = x.color_code, size_code = x.size_code, x.slTonDau, x.slNhap, x.slXuat, x.slTon });
                        dataGridView1.DataSource = datas.ToList();
                    }
                    Utils.themSTT(dataGridView1);
                    lbKQ.Text = "Đã tìm thấy " + dataGridView1.Rows.Count + " kết quả!";
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
                lbKQ.Text = "Tìm kiếm thât bại, vui lòng thử lại";
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {

            lbKQ.Text = "Đang xử lý xuất file excel kết quả tìm kiếm " + dataGridView1.Rows.Count + " đơn hàng....";
            ExportarDataGridViewExcel(dataGridView1);
        }

        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls";
                string fileName = "export_tonkho_"+dtFrom.Value.ToString("yyyyMMdd") + "_" + dtTo.Value.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".xls";
                fichero.FileName = fileName;
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    // changing the name of active sheet
                    hoja_trabajo.Name = "Exported from App";
                    // storing header part in Excel
                    for (int i = 1; i < grd.Columns.Count + 1; i++)
                    {
                        hoja_trabajo.Cells[1, i] = grd.Columns[i - 1].HeaderText;
                    }

                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 1; i < grd.Rows.Count + 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i - 1].Cells[j].Value == null ? "" : grd.Rows[i - 1].Cells[j].Value.ToString();
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    lbKQ.Text = "- Xuất file chứa " + dataGridView1.Rows.Count + " (đơn hàng) thành công! Kiểm tra file tại: " + Path.GetFullPath(fichero.FileName) + "- Do you want to open the file now?";
                    if (MessageBox.Show(lbKQ.Text, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string fileExcel;
                        fileExcel = Path.GetFullPath(fichero.FileName);
                        Microsoft.Office.Interop.Excel.Application xlapp;
                        Microsoft.Office.Interop.Excel.Workbook xlworkbook;
                        xlapp = new Microsoft.Office.Interop.Excel.Application();

                        xlworkbook = xlapp.Workbooks.Open(fileExcel, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                        xlapp.Visible = true;
                    }
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Xuất file lỗi, Chi tiết: " + exx.ToString());
            }

        }
    }
}
