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
    public partial class FrmDanhMucCauHinh : Form
    {
        public FrmDanhMucCauHinh()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbKQ.Text = "Đang tìm kiếm....";
            try
            {
                string keyword = txtKeyword.Text.Trim();
                string type = cbType.Text;
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_DANHMUCCAUHINH(keyword,type).OrderBy(x => x.id);
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
            FrmDanhMuc danhMuc = new FrmDanhMuc();
            danhMuc.ShowDialog();
            btnSearch_Click(sender, e);
        }
    }
}
