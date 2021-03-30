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
    public partial class FrmNhapXuat : Form
    {
        public FrmNhapXuat()
        {
            InitializeComponent();
        }
        public FrmNhapXuat(int type)
        {
            InitializeComponent();
            cbbType.SelectedIndex = type-1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    if (cbbProduct.SelectedItem==null)
                    {
                        cbbProduct.SelectedIndex = 0;
                    }
                    SanPham product = (SanPham)cbbProduct.SelectedItem;
                    if (cbbColor.SelectedItem == null)
                    {
                        cbbColor.SelectedIndex = 0;
                    }
                    DanhMucCauHinh color = (DanhMucCauHinh)cbbColor.SelectedItem;
                    if (cbbSize.SelectedItem == null)
                    {
                        cbbSize.SelectedIndex = 0;
                    }
                    DanhMucCauHinh size = (DanhMucCauHinh)cbbSize.SelectedItem;
                    var sp = new NhapXuatTon();
                    sp.product_code = product.code;
                    sp.color_code = color.code;
                    sp.size_code = size.code;
                    sp.nxt_date = dtNXT.Value;
                    sp.price = Int32.Parse(txtPrice.Text.Trim());
                    sp.type = cbbType.SelectedIndex + 1;
                    sp.quantity = Int32.Parse(txtQuantity.Text.Trim());
                    sp.created_date = DateTime.Now;
                    var datas = db.NhapXuatTons.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công: " + sp.product_code);
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi xảy ra. Chi tiết: " + exx.ToString());
            }
        }

        private void FrmNhapXuat_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadDanhMucCauHinh("COLOR", cbbColor);
            loadDanhMucCauHinh("SIZE", cbbSize);
        }

        private void loadSanPham()
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.SanPhams.OrderBy(x => x.name);
                    cbbProduct.DataSource = datas.ToList();
                    cbbProduct.DisplayMember = "name";
                    cbbProduct.ValueMember = "code";
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
            }
        }
        private void loadDanhMucCauHinh(string type, ComboBox cbb)
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.DanhMucCauHinhs.Where(x=>x.type.ToUpper()==type.ToUpper().Trim()).OrderBy(x => x.name);
                    cbb.DataSource = datas.ToList();
                    cbb.DisplayMember = "name";
                    cbb.ValueMember = "code";
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
            }
        }

        private void cbbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    SanPham item = (SanPham)cbbProduct.SelectedItem;
                    string value = item.code;
                    var datas = db.SanPhams.Where(x=>x.code== value).OrderBy(x => x.name).SingleOrDefault();
                    if (datas!=null)
                    {
                        txtPrice.Text = datas.price.ToString();
                    }
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            FrmSanPham sanPham = new FrmSanPham();
            sanPham.ShowDialog();
            loadSanPham();
        }
    }
}
