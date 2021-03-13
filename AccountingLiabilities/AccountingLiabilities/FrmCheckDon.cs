using AccountingLiabilities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace AccountingLiabilities
{
    public partial class FrmCheckDon : Form
    {
        public FrmCheckDon()
        {
            InitializeComponent();
            datePickStart.Value = DateTime.Now.AddDays(-30);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbKQTK.Text = "Đang tìm kiếm....";
            try
            {
                var item = cbCheckCondition.Text;
                Console.WriteLine(item);
                var startDate = datePickStart.Value.AddDays(-1);
                var endDate = datePickerEnd.Value.AddDays(1);
                //var obj = DBHelper.SelectDonDiHoanThanh();
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_DOISOAT_BY_PARAM(cbbPartner.Text, Utils.getCodeByStatusName(cbCheckCondition.Text.Trim()),txtMaDonHang.Text.Trim(),startDate, endDate);
                    
                            dataGridView1.DataSource = datas.ToList();
                    Utils.themSTT(dataGridView1);
                    lbKQTK.Text = "Đã tìm thấy " + dataGridView1.Rows.Count + " kết quả!";
                }
            }
            catch (Exception ex)
            {
                    System.Windows.Forms.MessageBox.Show("Dốt, lỗi rồi: " + ex.ToString());
            }
            finally
            {
            }
            

        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            lbKQTK.Text = "Đang xử lý xuất file excel kết quả tìm kiếm "+ dataGridView1.Rows.Count + " đơn hàng....";
            ExportarDataGridViewExcel(dataGridView1);
        }
        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls";
                string fileName = "export_doisoat_" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".xls";
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
                    lbKQTK.Text = "- Xuất file chứa " + dataGridView1.Rows.Count + " (đơn hàng) thành công! Kiểm tra file tại: "+ Path.GetFullPath(fichero.FileName)+"- Do you want to open the file now?";
                    if (MessageBox.Show(lbKQTK.Text, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes) {
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

        private void exportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
