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
    public partial class FrmXuatHang : Form
    {
        public FrmXuatHang()
        {
            InitializeComponent();
            dtFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtTo.Value = DateTime.Now.Date;
        }
        public FrmXuatHang(int index)
        {
            InitializeComponent();
            dtFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtTo.Value = DateTime.Now.Date;
            cbbType.SelectedIndex = index - 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbKQ.Text = "Đang tìm kiếm....";
            try
            {
                string keyword = txtKeyword.Text.Trim();
                DateTime fromDate = dtFrom.Value.Date;
                DateTime toDate = dtTo.Value.Date.AddDays(1);
                int type = 0;
                if (cbbType.SelectedIndex != null)
                {
                    type = cbbType.SelectedIndex;
                }
                using (var db = new DBQuocThinhEntities())
                {
                    var datas = db.PROC_SEARCH_NHAPXUATTON(keyword, type, fromDate, toDate).OrderBy(p => p.product_code).ThenBy(c=>c.color_code).ThenBy(s=>s.size_code);
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
            FrmNhapXuat nhapXuat = new FrmNhapXuat(2);
            nhapXuat.ShowDialog();
            btnSearch_Click(sender, e);
        }

        PROC_SEARCH_NHAPXUATTON_Result itemSelected = null;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng cần xóa.", "Thông báo");
                    return;
                }
                int n = dataGridView1.SelectedRows.Count;
                if (MessageBox.Show("Are you sure that you want to delete " + dataGridView1.SelectedRows.Count + " item selected", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow obj in this.dataGridView1.SelectedRows)
                    {
                        var item = (PROC_SEARCH_NHAPXUATTON_Result)obj.DataBoundItem;
                        using (var db = new DBQuocThinhEntities())
                        {
                            var data = db.NhapXuatTons.Where(x => x.id == item.id).FirstOrDefault();
                            if (data != null)
                            {
                                db.NhapXuatTons.Remove(data as NhapXuatTon);
                                db.SaveChanges();
                                Console.WriteLine("Xóa thành công mã đơn hàng " + itemSelected.product_code + " có id = " + itemSelected.id + ".");
                            }
                        }
                    }
                    MessageBox.Show("Xóa thành công " + n + " bản ghi.");
                    btnSearch_Click(sender, e);
                }
                //if (itemSelected == null)
                //{
                //    MessageBox.Show("Vui lòng chọn một đơn hàng cần xóa.", "Thông báo");
                //}
                //else
                //{
                //    if (MessageBox.Show("Are you sure that you want to delete this item with code: " + itemSelected.product_code + " and id = " + itemSelected.id + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        using (var db = new DBQuocThinhEntities())
                //        {
                //            var data = db.NhapXuatTons.Where(x => x.id == itemSelected.id).FirstOrDefault();
                //            if (data != null)
                //            {
                //                db.NhapXuatTons.Remove(data as NhapXuatTon);
                //                db.SaveChanges();
                //            }
                //            MessageBox.Show("Xóa thành công mã đơn hàng " + itemSelected.product_code + " có id = " + itemSelected.id + ".");
                //            btnSearch_Click(sender, e);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa. Chi tiết: " + ex.ToString());
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            itemSelected = (PROC_SEARCH_NHAPXUATTON_Result)dataGridView1.CurrentRow.DataBoundItem;
            if (itemSelected != null)
            {
                Console.WriteLine(itemSelected.id);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmNhapXuatExecl nhapXuatExecl = new FrmNhapXuatExecl(2);
            nhapXuatExecl.ShowDialog();
            btnSearch_Click(sender, e);
        }
    }
}
