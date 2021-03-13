using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingLiabilities.Utilities
{
    class Utils
    {
        public static void themSTT(DataGridView gridView)
        {
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                gridView.Rows[i].Cells[0].Value = i + 1;
            }
        }
        //        Tất cả
        //Đơn đã hoàn thành
        //Đơn đã hoàn thành có lệch tiền
        //Đơn đã hoàn thành không lệch tiền
        //Đơn hoàn trả
        //Đơn hoàn trả và có phí thu hộ
        //Đơn hoàn trả và không phí thu hộ
        //Đơn chưa hoàn trả thực tế
        //Đơn đã hoàn trả thực tế
        //Đơn hàng chưa đối soát
        public static string getCodeByStatusName(string statusName)
        {
            string status = "TATCA";
            switch (statusName.Trim().ToLower())
            {
                case "tất cả":
                    status = "TATCA";
                    break;
                case "đơn đã hoàn thành":
                    status = "DONDAHOANTHANH";
                    break;
                case "đơn đã hoàn thành có lệch tiền":
                    status = "DONDAHOANTHANHCOLECHTIEN";
                    break;
                case "đơn đã hoàn thành không lệch tiền":
                    status = "DONDAHOANTHANHKHONGLECHTIEN";
                    break;
                case "đơn hoàn trả":
                    status = "DONHOANTRA";
                    break;
                case "đơn hoàn trả và có phí thu hộ":
                    status = "DONHOANTRACOPHITHUHO";
                    break;
                case "đơn hoàn trả và không phí thu hộ":
                    status = "DONHOANTRAKHONGPHITHUHO";
                    break;
                case "đơn chưa hoàn trả thực tế":
                    status = "DONCHUAHOANTRATHUCTE";
                    break;
                case "đơn đã hoàn trả thực tế":
                    status = "DONDAHOANTRATHUCTE";
                    break;
                case "đơn hàng chưa đối soát":
                    status = "DONHANGCHUADOISOAT";
                    break;
                default:
                    status = "TATCA";
                    break;
            }
            return status;
        }
    }
}
