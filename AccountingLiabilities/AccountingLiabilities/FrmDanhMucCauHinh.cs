using AccountingLiabilities.Utilities;
using Microsoft.Office.Core;
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

        PROC_SEARCH_DANHMUCCAUHINH_Result itemSelected = null;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một bản ghi cần xóa.", "Thông báo");
                    return;
                }
                int n = dataGridView1.SelectedRows.Count;
                if (MessageBox.Show("Are you sure that you want to delete " + dataGridView1.SelectedRows.Count + " item selected", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow obj in this.dataGridView1.SelectedRows)
                    {
                        var item = (PROC_SEARCH_DANHMUCCAUHINH_Result)obj.DataBoundItem;
                        using (var db = new DBQuocThinhEntities())
                        {
                            var data = db.DanhMucCauHinhs.Where(x => x.id == item.id).FirstOrDefault();
                            if (data != null)
                            {
                                db.DanhMucCauHinhs.Remove(data as DanhMucCauHinh);
                                db.SaveChanges();
                                Console.WriteLine("Xóa thành công bản ghi " + itemSelected.code + " có id = " + itemSelected.id + ".");
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
                //    if (MessageBox.Show("Are you sure that you want to delete this item with code: " + itemSelected.code + " and id = " + itemSelected.id + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        using (var db = new DBQuocThinhEntities())
                //        {
                //            var data = db.DanhMucCauHinhs.Where(x => x.id == itemSelected.id).FirstOrDefault();
                //            if (data != null)
                //            {
                //                db.DanhMucCauHinhs.Remove(data as DanhMucCauHinh);
                //                db.SaveChanges();
                //            }
                //            MessageBox.Show("Xóa thành công danh mục " + itemSelected.code + " có id = " + itemSelected.id + ".");
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
            itemSelected = (PROC_SEARCH_DANHMUCCAUHINH_Result)dataGridView1.CurrentRow.DataBoundItem;
            if (itemSelected!=null)
            {
                Console.WriteLine(itemSelected.id);
            }
        }
    }
}
