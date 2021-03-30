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
    public partial class FrmNhapHang : Form
    {
        public FrmNhapHang()
        {
            InitializeComponent();
            dtFrom.Value = DateTime.Now.AddDays(-30);
            dtTo.Value = DateTime.Now.AddDays(1);
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
                if (cbbType.SelectedIndex!=null)
                {
                    type = cbbType.SelectedIndex;
                }
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_NHAPXUATTON(keyword, type, fromDate, toDate).OrderByDescending(x => x.id);
                    dataGridView1.DataSource = datas.ToList();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNhapXuat nhapXuat = new FrmNhapXuat(1);
            nhapXuat.ShowDialog();

        }
    }
}
