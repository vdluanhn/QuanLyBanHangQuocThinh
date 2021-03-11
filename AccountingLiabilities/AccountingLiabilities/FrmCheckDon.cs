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
    public partial class FrmCheckDon : Form
    {
        public FrmCheckDon()
        {
            InitializeComponent();
            datePickStart.Value = DateTime.Now.AddDays(-90);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var item = cbCheckCondition.Text;
            Console.WriteLine(item);
            var startDate = datePickStart.Value.AddDays(-1);
            var endDate = datePickerEnd.Value.AddDays(1);
            //var obj = DBHelper.SelectDonDiHoanThanh();
            using (var db = new DBQuocThinhEntities())
            {
                //from c in table0
                //join o in table1 on c.sno equals o.sno into ps
                //from o in ps.DefaultIfEmpty()
                //select new { c.name, o.number }
                var datas = from d in db.DonDis
                            join dsvc in db.DoiSoatVanChuyens on d.code equals dsvc.code into ljoin

                            from dsvc in ljoin.DefaultIfEmpty() orderby d.id descending
                            select new { 
                                d.code, d.amount, d.cust_name, d.cust_address, d.cust_mobile, d.description, d.out_date,
                                status_name = dsvc.code == null?"Mã đơn hàng của ĐVVC không tồn tại":
                                            (dsvc.code != null && dsvc.collection_amount > 0 && dsvc.refund_fee == 0) ?"Đơn hoàn thành" :
                                            (dsvc.code != null && dsvc.refund_fee > 0 && dsvc.collection_amount > 0) ? "Đơn hoàn trả và có phí thu hộ" :
                                            (dsvc.code != null && dsvc.refund_fee > 0 && dsvc.collection_amount<=0) ? "Đơn hoàn trả và không có phí thu hộ" : "Chưa xác định"
                                            , tien_thu_ho=dsvc.collection_amount,
                                            ngay_nhap_soi_soat = dsvc.created_date, ngay_doi_soat = dsvc.finish_date, 
                                thanh_toan_du = (dsvc.code != null && dsvc.collection_amount > 0 && d.amount== dsvc.collection_amount) ? "Thanh toán đủ":"Lệch tiền (tiền đơn hàng - tiền thu hộ): "+(d.amount - dsvc.collection_amount) +" ",
                                phi_hoan_tra=dsvc.refund_fee, thanhtien = dsvc.amount
                            };
                datas = datas.Where(x => x.ngay_doi_soat > startDate && x.ngay_doi_soat < endDate);

                switch (item)
                {
                    case "Đơn đã hoàn thành":
                        var data = datas.Where(x => x.status_name == "Đơn hoàn thành");
                        dataGridView1.DataSource = data.ToList();
                        break;
                    case "Đơn hoàn trên danh sách ĐVVC gửi":
                            var data1 = datas.Where(x => x.status_name == "Đơn hoàn trả");
                            dataGridView1.DataSource = data1.ToList();

                            break;
                    case "Đơn hoàn thực tế":
                            var data2 = datas.Where(x => x.status_name == "Chưa xác định");
                            dataGridView1.DataSource = data2.ToList();

                        break;
                    case "Mã đơn hàng của ĐVVC không tồn tại":
                        var data3 = datas.Where(x => x.status_name == "Mã đơn hàng của ĐVVC không tồn tại");
                        dataGridView1.DataSource = data3.ToList();
                        break;
                    case "Đơn hoàn trả và có phí thu hộ":
                        var data5 = datas.Where(x => x.status_name == "Đơn hoàn trả và có phí thu hộ");
                        dataGridView1.DataSource = data5.ToList();
                        break;
                    case "Đơn hoàn trả và không có phí thu hộ":
                        var data4 = datas.Where(x => x.status_name == "Đơn hoàn trả và không có phí thu hộ");
                        dataGridView1.DataSource = data4.ToList();

                        break;
                    default:
                        dataGridView1.DataSource = datas.ToList();

                        break;
                }
                MessageBox.Show("Đã tìm thấy "+ dataGridView1.Rows.Count + " kết quả!");
            }

        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable
            // DataTable này mỗi bạn lấy mỗi khác. 
            // Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
            // Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
            // DataGridView nhé 
            //excel.Export(dt, "Danh sach", "DANH SÁCH CÁC ĐƠN VỊ");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
