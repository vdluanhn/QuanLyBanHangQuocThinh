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
    public partial class FrmDanhMuc : Form
    {
        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    var sp = new DanhMucCauHinh();
                    sp.code = txtCode.Text.Trim().ToUpper();
                    sp.name = txtName.Text.Trim();
                    sp.value = txtValue.Text.Trim();
                    sp.description = txtDesc.Text;
                    sp.type = cbbType.Text;
                    sp.status = 1;
                    sp.created_date = DateTime.Now;
                    var datas = db.DanhMucCauHinhs.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công: " + sp.name);
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi xảy ra. Chi tiết: " + exx.ToString());
            }
        }
    }
}
