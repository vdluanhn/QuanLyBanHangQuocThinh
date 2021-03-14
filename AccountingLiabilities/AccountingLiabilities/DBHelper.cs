using AccountingLiabilities.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingLiabilities
{//https://giasutinhoc.vn/huong-dan-thuc-hanh/huong-dan-csharp/huong-dan-su-dung-entity-framework-trong-csharp/
    class DBHelper
    {
        public static void InsertDonDi(DonDi donDi)
        {
            using (var db = new DBQuocThinhEntities())
            {
                db.DonDis.Add(donDi);
                db.SaveChanges();
            }
        }

        public static int InsertDonDis(List<DonDi> donDis)
        {
            try
            {
                var lstData = donDis.GroupBy(x => x.code).Select(g => g.First()).ToList();
                int nDaTonTai = 0;
                int nKhongCoMa = 0;
                using (var db = new DBQuocThinhEntities())
                {
                    foreach (var item in lstData)
                    {
                        if (item.code == null || item.code.Trim() == "")
                        {
                            nKhongCoMa++;
                            Console.WriteLine("Don hang ko co ma don, bo qua ko insert");
                            continue;
                        }
                        var check = db.DonDis.Where(x => x.code.Trim() == item.code.Trim()).FirstOrDefault<DonDi>();
                        if (check != null)
                        {
                            Console.WriteLine("Trung ma don hang: " + check.code + ". Se xoa ma don hang hiện tại và insert mới");
                            db.DonDis.Remove(check);
                            db.SaveChanges();
                            nDaTonTai++;
                        }
                        db.DonDis.Add(item);
                    }
                    db.SaveChanges();
                }
                if (nDaTonTai > 0 && nKhongCoMa == 0)
                {
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng). \n- Trong đó có " + nDaTonTai + " đơn đã tồn tại trước đó, hệ thống đã cập nhật theo đơn mới nhất.", "Thông báo");
                }
                else
                    if (nDaTonTai > 0 && nKhongCoMa > 0)
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng). \n- Trong đó có " + nDaTonTai + " đơn đã tồn tại trước đó, hệ thống đã cập nhật theo đơn mới nhất. \n- Có " + nKhongCoMa + " đơn không có mã, hệ thống đã bỏ qua.", "Thông báo");
                else
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng).", "Thông báo");
                return lstData.Count;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.InnerException.Message;
                if (msg.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Danh sách mã đơn hàng đã được thêm vào trước đó. Chi tiết: "+msg);
                }
                else
                    System.Windows.Forms.MessageBox.Show("Loi: " + ex.ToString());
                return -1;

            }
            return 0;
        }

        public static int InsertDoiSoatVanChuyens(List<DoiSoatVanChuyen> doiSoatVanChuyens)
        {
            DoiSoatVanChuyen itemCur = new DoiSoatVanChuyen();
            try
            {
                var lstData = doiSoatVanChuyens.GroupBy(x => x.code).Select(g => g.First()).ToList();
                int nDaTonTai = 0;
                int nKhongCoMa = 0;
                using (var db = new DBQuocThinhEntities())
                {
                    foreach (var item in lstData)
                    {
                        if (item.code==null || item.code.Trim()=="")
                        {
                            nKhongCoMa++;
                            Console.WriteLine("Don hang ko co ma don, bo qua ko insert");
                            continue;
                        }
                        var check = db.DoiSoatVanChuyens.Where(x => x.code.Trim()==item.code.Trim()).FirstOrDefault<DoiSoatVanChuyen>();
                        if (check!=null)
                        {
                            Console.WriteLine("Trung ma don hang: "+check.code+". Se xoa ma don hang hiện tại và insert mới");
                            db.DoiSoatVanChuyens.Remove(check);
                            db.SaveChanges();
                            nDaTonTai++;
                        }
                        db.DoiSoatVanChuyens.Add(item);
                    }
                    db.SaveChanges();
                }
                if (nDaTonTai>0 && nKhongCoMa==0)
                {
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng). \n- Trong đó có " + nDaTonTai + " đơn đã tồn tại trước đó, hệ thống đã cập nhật theo đơn mới nhất.","Thông báo");
                }else
                    if (nDaTonTai > 0 && nKhongCoMa > 0)
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng). \n- Trong đó có " + nDaTonTai + " đơn đã tồn tại trước đó, hệ thống đã cập nhật theo đơn mới nhất. \n- Có "+nKhongCoMa+" đơn không có mã, hệ thống đã bỏ qua.", "Thông báo");
                else
                        MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng).", "Thông báo");
                return lstData.Count();
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.InnerException.Message;
                if (msg.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Mã đơn hàng đã tồn tại, vui lòng kiểm tra lại mã trùng. Chi tiết: "+ex.InnerException.InnerException.Message);
                }else
                    System.Windows.Forms.MessageBox.Show("Loi: " + ex.ToString());
                return -1;
            }
            return 0;
            
        }

        public static int InsertDonHoanTraThucTes(List<DonDaHoanTraThucTe> donDaHoanTraThucTes)
        {
            DonDaHoanTraThucTe itemCur = new DonDaHoanTraThucTe();
            try
            {
                var lstData = donDaHoanTraThucTes.GroupBy(x => x.sub_code).Select(g => g.First()).ToList();
                int nDaTonTai = 0;
                int nKhongCoMa = 0;
                using (var db = new DBQuocThinhEntities())
                {
                    foreach (var item in donDaHoanTraThucTes)
                    {
                        if (item.sub_code == null || item.sub_code.Trim() == "")
                        {
                            nKhongCoMa++;
                            Console.WriteLine("Don hang ko co ma don, bo qua ko insert");
                            continue;
                        }
                        var check = db.DonDaHoanTraThucTes.Where(x => x.sub_code.Trim() == item.sub_code.Trim()).FirstOrDefault<DonDaHoanTraThucTe>();
                        if (check != null)
                        {
                            Console.WriteLine("Trung ma don hang: " + check.sub_code + ". Se xoa ma don hang hiện tại và insert mới");
                            db.DonDaHoanTraThucTes.Remove(check); 
                            db.SaveChanges();
                            nDaTonTai++;
                        }
                        db.DonDaHoanTraThucTes.Add(item);
                    }
                    db.SaveChanges();
                }
                if (nDaTonTai > 0 && nKhongCoMa == 0)
                {
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng). \n- Trong đó có " + nDaTonTai + " đơn đã tồn tại trước đó, hệ thống đã cập nhật theo đơn mới nhất.", "Thông báo");
                }
                else
                    if (nDaTonTai > 0 && nKhongCoMa > 0)
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng). \n- Trong đó có " + nDaTonTai + " đơn đã tồn tại trước đó, hệ thống đã cập nhật theo đơn mới nhất. \n- Có " + nKhongCoMa + " đơn không có mã, hệ thống đã bỏ qua.", "Thông báo");
                else
                    MessageBox.Show("- Đã nhập thành công " + lstData.Count + " (đơn hàng).", "Thông báo");
                return lstData.Count;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.InnerException.Message;
                if (msg.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Danh sách mã đơn hàng đã được thêm vào trước đó. \n Chi tiết: "+msg);
                }
                else
                    System.Windows.Forms.MessageBox.Show("Loi: " + ex.ToString());
                return -1;
            }
            return 0;

        }
        public static Object SelectDonDiHoanThanh()
        {
            using (var db = new DBQuocThinhEntities())
            {
                //from c in table0
                //join o in table1 on c.sno equals o.sno into ps
                //from o in ps.DefaultIfEmpty()
                //select new { c.name, o.number }
                var datas = from d in db.DonDis
                            join dsvc in db.DoiSoatVanChuyens  on d.code equals dsvc.code into ljoin
                            
                            from dsvc in ljoin.DefaultIfEmpty()
                            let thanhtoan = dsvc.amount
                            select new { d.code, d.amount, d.cust_name, d.cust_address, d.cust_mobile, d.description, thanhtoan };
                return datas;
            }
        }

    }
}
