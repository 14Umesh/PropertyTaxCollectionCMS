//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyTaxCollectionCMS.Dal.DataContexts
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAX_COLLECTION_DETAIL
    {
        public int TC_ID { get; set; }
        public int TCAT_ID { get; set; }
        public int APP_ID { get; set; }
        public string RECIPT_NO { get; set; }
        public Nullable<int> TPAY_ID { get; set; }
        public Nullable<decimal> TOTAL_AMOUNT { get; set; }
        public Nullable<decimal> RECEIVED_AMOUNT { get; set; }
        public Nullable<decimal> REMAINING_AMOUNT { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATE { get; set; }
        public int HOUSEID { get; set; }
        public string EMP_LAT { get; set; }
        public string EMP_LONG { get; set; }
        public Nullable<int> ADUM_USER_CODE { get; set; }
        public string RECEIVER_NAME { get; set; }
        public string RECEIVER_SIGNATURE_IMAGE { get; set; }
        public string ADDRESS { get; set; }
        public Nullable<System.DateTime> REMINDER_NEW_DATE { get; set; }
        public string REMARK { get; set; }
        public string CHEQUE_NO { get; set; }
        public Nullable<System.DateTime> CHEQUE_DATE { get; set; }
        public string CHEQUE_BANK_NAME { get; set; }
        public string CHEQUE_IMAGE { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string CAMERA_IMAGE { get; set; }
        public string REASON { get; set; }
        public string TaxRemImage { get; set; }
    }
}
