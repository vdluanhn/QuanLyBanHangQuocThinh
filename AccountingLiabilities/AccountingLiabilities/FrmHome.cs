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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnQLTonKho_Click(object sender, EventArgs e)
        {
            FrmNhapXuatTon nhapXuatTon = new FrmNhapXuatTon();
            nhapXuatTon.ShowDialog();
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            FrmNhapHang nhapHang = new FrmNhapHang(2);
            nhapHang.Show();
        }

        private void btnDoiSoat_Click(object sender, EventArgs e)
        {
            FrmCheckDon checkDon = new FrmCheckDon();
            checkDon.ShowDialog();
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            FrmXuatHang xuatHang = new FrmXuatHang(3);
            xuatHang.ShowDialog();
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            FrmSanPham sanPham = new FrmSanPham();
            sanPham.ShowDialog();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            FrmDanhMucCauHinh danhMucCauHinh = new FrmDanhMucCauHinh();
            danhMucCauHinh.ShowDialog();
        }
    }
}
