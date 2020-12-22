using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTaxCollectionCMS.Bll.ViewModels
{
    public class DashBoardVM
    {
        public string Attendence { get; set; }
        public string TaxReceipt { get; set; }
        public string TaxPayment { get; set; }
        public string Reminder { get; set; }


        public string UserName { get; set; }
        public string InTime { get; set; }
        public string InLat { get; set; }
        public string InLong { get; set; }
        
    }

    public class AttendanceDetailsVM
    {
        public int DA_ID { get; set; }
        public string UserName { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
    }

    public class TaxReceiptDetailsVM
    {
        public string ADUM_USER_NAME { get; set; }

        public string House_Owner_NAME { get; set; }
        public int TC_ID { get; set; }
        public int TCAT_ID { get; set; }
        public string RECEIPT_NO { get; set; }
        public string PAYMENT_DATE { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public decimal RECEIVED_AMOUNT { get; set; }
        public decimal REMAINING_AMOUNT { get; set; }
        public string HOUSEID { get; set; }

        public string REASON { get; set; }
        public string RECEIVER_NAME { get; set; }
        public string RECEIVER_SIGNATURE { get; set; }

        public string CAMERA_IMAGE { get; set; }

        public string TaxRemImage { get; set; }

    }


}
