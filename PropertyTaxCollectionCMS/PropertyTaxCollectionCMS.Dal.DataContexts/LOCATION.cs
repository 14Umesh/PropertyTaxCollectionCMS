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
    
    public partial class LOCATION
    {
        public int LOC_ID { get; set; }
        public Nullable<int> APP_ID { get; set; }
        public Nullable<int> ADUM_USER_CODE { get; set; }
        public Nullable<System.DateTime> LOC_DATE_TIME { get; set; }
        public string LAT { get; set; }
        public string LONG { get; set; }
        public string ADDRESS { get; set; }
        public string Area { get; set; }
        public Nullable<int> LOC_TYPE { get; set; }
        public Nullable<int> HOUSEID { get; set; }
        public string BATTERY_STATUS { get; set; }
        public Nullable<decimal> DISTANCE { get; set; }
        public Nullable<bool> IS_OFFLINE { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
    }
}
