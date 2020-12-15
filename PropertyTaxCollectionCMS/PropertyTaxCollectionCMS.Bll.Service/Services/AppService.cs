using PropertyTaxCollectionCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTaxCollectionCMS.Bll.Service.Services
{
    public abstract class AppService
    {
        public abstract class DBMain
        {
            protected PropertyTaxCollectionCMSMain_Entities dbMain;
            public DBMain()
            {
                dbMain = new PropertyTaxCollectionCMSMain_Entities();
            }

       
        }
    }
}
