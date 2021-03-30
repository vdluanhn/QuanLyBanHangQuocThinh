using AccountingLiabilities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            dtFrom.Value = DateTime.Now.AddDays(-30);
            dtTo.Value = DateTime.Now.AddDays(1);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmNhapHang nhapHang = new FrmNhapHang();
            nhapHang.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmXuatHang xuatHang = new FrmXuatHang();
            xuatHang.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbKQ.Text = "Đang tìm kiếm....";
            try
            {
                string keyword = txtKeyword.Text.Trim();
                DateTime fromDate = dtFrom.Value;
                DateTime toDate = dtTo.Value;
                int type = 0;
                if (cbbType.SelectedIndex != null)
                {
                    type = cbbType.SelectedIndex;
                }
                using (var db = new DBQuocThinhEntities())
                {
                    if (type==0)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAM(keyword,fromDate, toDate).OrderBy(x => x.code);
                        dataGridView1.DataSource = datas.ToList();
                    }
                    if (type == 1)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAMCOLOR(keyword, fromDate, toDate).OrderBy(x => x.product_code);
                        dataGridView1.DataSource = datas.ToList();
                    }
                    if (type == 2)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAMSIZE(keyword, fromDate, toDate).OrderBy(x => x.product_code);
                        dataGridView1.DataSource = datas.ToList();
                    }
                    if (type == 3)
                    {
                        var datas = db.PROC_SEARCH_NHAPXUATTON_SANPHAMCOLORSIZE(keyword, fromDate, toDate).OrderBy(x => x.product_code);
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
    }
}
