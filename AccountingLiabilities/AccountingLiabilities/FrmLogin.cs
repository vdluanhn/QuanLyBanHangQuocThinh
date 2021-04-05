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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text=="huongnhem" && txtpwd.Text=="tinhco123")
            {
                FrmHome home = new FrmHome();
                this.Hide();
                home.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác, vui lòng thử lại.", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
