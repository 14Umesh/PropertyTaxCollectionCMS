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
        protected PropertyTaxCollectionCMSChild_Entities db;
        protected PropertyTaxCollectionCMSMain_Entities dbMain;
             public AppService(int AppId)
            {
            db = new PropertyTaxCollectionCMSChild_Entities(AppId);
            dbMain = new PropertyTaxCollectionCMSMain_Entities();        

        }

       
        }
    }

