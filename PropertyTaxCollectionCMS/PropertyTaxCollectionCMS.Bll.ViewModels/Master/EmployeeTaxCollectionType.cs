using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTaxCollectionCMS.Bll.ViewModels.Master
{
  public  class EmployeeTaxCollectionType
    {
        public Nullable<int> TaxReceipt { get; set; }
        public Nullable<int> TaxPayment { get; set; }
        public Nullable<int> TaxRemainder { get; set; }

        public string inTime { get; set; }
        public Nullable<int> Count { get; set; }

        public int ADUM_USER_CODE { get; set; }
        public string ADUM_USER_NAME { get; set; }
    
        public string TodayDate { get; set; }
    }
}
