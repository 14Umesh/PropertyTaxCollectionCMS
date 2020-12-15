using PropertyTaxCollectionCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTaxCollectionCMS.Bll.Repository.Repository
{
    public abstract class DBMain
    {
        protected PropertyTaxCollectionCMSMain_Entities dbMain;

        protected PropertyTaxCollectionCMSMain_Entities dbChild;
        public DBMain()
        {
            dbMain = new PropertyTaxCollectionCMSMain_Entities();
         


        }
    }
}
