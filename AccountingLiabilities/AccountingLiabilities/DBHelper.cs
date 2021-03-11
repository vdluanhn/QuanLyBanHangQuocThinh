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

        public static void InsertDonDis(List<DonDi> donDis)
        {
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    foreach (var item in donDis)
                    {
                        if (item.code == null || item.code.Trim() == "")
                        {
                            Console.WriteLine("Don hang ko co ma don, bo qua ko insert");
                            continue;
                        }
                        var check = db.DonDis.Where(x => x.code.Trim() == item.code.Trim()).FirstOrDefault<DonDi>();
                        if (check != null)
                        {
                            Console.WriteLine("Trung ma don hang: " + check.code + ". Se xoa ma don hang hiện tại và insert mới");
                            db.DonDis.Remove(check);
                            db.SaveChanges();
                        }
                        db.DonDis.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.InnerException.Message;
                if (msg.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Danh sách mã đơn hàng đã được thêm vào trước đó.");
                }
                else
                    System.Windows.Forms.MessageBox.Show("Loi: " + ex.ToString());

            }
        }

        public static void InsertDoiSoatVanChuyens(List<DoiSoatVanChuyen> doiSoatVanChuyens)
        {
            DoiSoatVanChuyen itemCur = new DoiSoatVanChuyen();
            try
            {
                using (var db = new DBQuocThinhEntities())
                {
                    foreach (var item in doiSoatVanChuyens)
                    {
                        if (item.code==null || item.code.Trim()=="")
                        {
                            Console.WriteLine("Don hang ko co ma don, bo qua ko insert");
                            continue;
                        }
                        var check = db.DoiSoatVanChuyens.Where(x => x.code.Trim()==item.code.Trim()).FirstOrDefault<DoiSoatVanChuyen>();
                        if (check!=null)
                        {
                            Console.WriteLine("Trung ma don hang: "+check.code+". Se xoa ma don hang hiện tại và insert mới");
                            db.DoiSoatVanChuyens.Remove(check);
                            db.SaveChanges();
                        }
                        db.DoiSoatVanChuyens.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.InnerException.Message;
                if (msg.Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Danh sách mã đơn hàng đã được thêm vào trước đó.");
                }else
                    System.Windows.Forms.MessageBox.Show("Loi: " + ex.ToString());
            }
            
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
