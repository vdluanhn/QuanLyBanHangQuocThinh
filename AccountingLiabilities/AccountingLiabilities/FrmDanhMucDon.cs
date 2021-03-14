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
    public partial class FrmDanhMucDon : Form
    {
        public FrmDanhMucDon()
        {
            InitializeComponent();
            datePickStart.Value = DateTime.Now.AddDays(-30);
            dtPickerDSStart.Value = DateTime.Now.AddDays(-30);
            dtHTStart.Value = DateTime.Now.AddDays(-30);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbKQTK.Text = "Đang tìm kiếm....";
            try { 
                string partner = cbbPartner.Text.Trim();
                if (partner == "Tất cả")
                {
                    partner = "TATCA";
                }
                string code = txtMaDonHang.Text.Trim();
                DateTime fromDate = datePickStart.Value;
                DateTime toDate = datePickerEnd.Value;
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_DONDI_BY_PARAM(partner, code, fromDate, toDate).OrderByDescending(x=>x.id); 
                    dataGridView1.DataSource = datas.ToList();
                    Utils.themSTT(dataGridView1);
                    lbKQTK.Text = "Đã tìm thấy " + dataGridView1.Rows.Count + " kết quả!";
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
                lbKQTK.Text = "Tìm kiếm thât bại, vui lòng thử lại";
            }
}

        PROC_SEARCH_DONDI_BY_PARAM_Result itemSelected = null;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            itemSelected = (PROC_SEARCH_DONDI_BY_PARAM_Result)dataGridView1.CurrentRow.DataBoundItem;
            Console.WriteLine(itemSelected.id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSelected == null)
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng cần xóa.", "Thông báo");
                }
                else
                {
                    if (MessageBox.Show("Are you sure that you want to delete this item with code: " + itemSelected.Mã_đơn_hàng + " and id = " + itemSelected.id + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var db = new DBQuocThinhEntities())
                        {
                            var data = db.DonDis.Where(x => x.id == itemSelected.id).FirstOrDefault();
                            if (data != null)
                            {
                                db.DonDis.Remove(data as DonDi);
                                db.SaveChanges();
                            }
                            btnSearch_Click(sender, e);
                            MessageBox.Show("Xóa thành công mã đơn hàng " + itemSelected.Mã_đơn_hàng + " có id = "+itemSelected.id+".");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa. Chi tiết: " + ex.ToString());
            }
            
        }

        private void btnSearchDS_Click(object sender, EventArgs e)
        {
            try { 
                lbKQTKDS.Text = "Đang tìm kiếm....";
                string partner = cbbPartnerDS.Text.Trim();
                if (partner == "Tất cả")
                {
                    partner = "TATCA";
                }
                string code = txtMaDonHang.Text.Trim();
                DateTime fromDate = dtPickerDSStart.Value;
                DateTime toDate = dtPickerDSEnd.Value;
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_DONDOISOAT_BY_PARAM(partner, code, fromDate, toDate).OrderByDescending(x => x.id);
                    dataGridView2.DataSource = datas.ToList();
                    Utils.themSTT(dataGridView2);
                    lbKQTKDS.Text = "Đã tìm thấy " + dataGridView2.Rows.Count + " kết quả!";
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
                lbKQTKDS.Text = "Tìm kiếm thât bại, vui lòng thử lại";
            }
}

        private void btnXoaDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemDSSelected == null)
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng cần xóa.", "Thông báo");
                }
                else
                {
                    if (MessageBox.Show("Are you sure that you want to delete this item with code: " + itemDSSelected.code + " and id = " + itemDSSelected.id + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var db = new DBQuocThinhEntities())
                        {
                            var data = db.DoiSoatVanChuyens.Where(x => x.id == itemDSSelected.id).FirstOrDefault();
                            if (data != null)
                            {
                                db.DoiSoatVanChuyens.Remove(data as DoiSoatVanChuyen);
                                db.SaveChanges();
                            }
                            btnSearchDS_Click(sender, e);
                            MessageBox.Show("Xóa thành công mã đơn hàng " + itemDSSelected.code + " có id = " + itemDSSelected.id + ".");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa. Chi tiết: " + ex.ToString());
            }
        }

        PROC_SEARCH_DONDOISOAT_BY_PARAM_Result itemDSSelected = null;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            itemDSSelected = (PROC_SEARCH_DONDOISOAT_BY_PARAM_Result)dataGridView2.CurrentRow.DataBoundItem;
            Console.WriteLine(itemDSSelected.id);
        }

        PROC_SEARCH_DONHOANTHUC_BY_PARAM_Result itemHTSelected = null;
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            itemHTSelected = (PROC_SEARCH_DONHOANTHUC_BY_PARAM_Result)dataGridView3.CurrentRow.DataBoundItem;
            Console.WriteLine(itemHTSelected.id);
        }

        private void btnSearchHT_Click(object sender, EventArgs e)
        {
            lbKQTKHT.Text = "Đang tìm kiếm....";
            try
            {
                string partner = cbbPartnerHT.Text.Trim();
                if (partner == "Tất cả")
                {
                    partner = "TATCA";
                }
                string code = txtCodeHT.Text.Trim();
                DateTime fromDate = dtHTStart.Value;
                DateTime toDate = dtHTEnd.Value;
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_DONHOANTHUC_BY_PARAM(partner, code, fromDate, toDate).OrderByDescending(x => x.id);
                    dataGridView3.DataSource = datas.ToList();
                    Utils.themSTT(dataGridView3);
                    lbKQTKHT.Text = "Đã tìm thấy " + dataGridView3.Rows.Count + " kết quả!";
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm. Chi tiết: " + exx.ToString());
                lbKQTKHT.Text = "Tìm kiếm thât bại, vui lòng thử lại";
            }
            
        }

        private void btnDeleteHT_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemHTSelected == null)
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng cần xóa.", "Thông báo");
                }
                else
                {
                    if (MessageBox.Show("Are you sure that you want to delete this item with code: " + itemHTSelected.sub_code + " and id = " + itemHTSelected.id + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var db = new DBQuocThinhEntities())
                        {
                            var data = db.DonDaHoanTraThucTes.Where(x => x.id == itemHTSelected.id).FirstOrDefault();
                            if (data != null)
                            {
                                db.DonDaHoanTraThucTes.Remove(data as DonDaHoanTraThucTe);
                                db.SaveChanges();
                            }
                            btnSearchHT_Click(sender, e);
                            MessageBox.Show("Xóa thành công mã đơn hàng " + itemHTSelected.sub_code + " có id = " + itemHTSelected.id + ".");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa. Chi tiết: " + ex.ToString());
            }
        }
    }
}
