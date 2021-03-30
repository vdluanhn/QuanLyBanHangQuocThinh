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
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    var sp = new SanPham();
                    sp.code = txtCode.Text.Trim().ToUpper();
                    sp.name = txtName.Text.Trim();
                    sp.supplier = txtSuplier.Text.Trim();
                    sp.price = Int32.Parse(txtPrice.Text.Trim());
                    sp.created_date = DateTime.Now;
                    var datas = db.SanPhams.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công sản phẩm: " + sp.name);
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi xảy ra. Chi tiết: " + exx.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
