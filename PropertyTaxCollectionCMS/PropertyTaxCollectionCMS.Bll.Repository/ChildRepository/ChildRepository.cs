using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTaxCollectionCMS.Bll.ViewModels;
using PropertyTaxCollectionCMS.Bll.Service.Services;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;

namespace PropertyTaxCollectionCMS.Bll.Repository.ChildRepository
{
    public class ChildRepository : IChildRepository
    {
        private int AppID;
        IScreenService screenService;

        public ChildRepository(int AppId)
        {
            screenService = new ScreenService(AppId);

            AppID = AppId;
        }
        public DashBoardVM GetHouseOnMapDetails(int AppId)
        {
            return screenService.GetHouseOnMapDetails(AppId);
        }

        public List<PTCUserLocationMapView> GetAllHouseLocation(string date, int userid, string SearchString, int? GarbageType, int FilterType)
        {
            return screenService.GetAllHouseLocation(date, userid, SearchString, GarbageType, FilterType);
        }
    }
}
