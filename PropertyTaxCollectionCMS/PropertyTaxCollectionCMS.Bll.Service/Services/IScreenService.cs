﻿using PropertyTaxCollectionCMS.Bll.ViewModels;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTaxCollectionCMS.Bll.Service.Services
{
    public interface IScreenService
    {
        //List<PTCUserLocationMapView> GetUserAttenRoute(int userId);

        DashBoardVM GetHouseOnMapDetails(int AppId);

        List<PTCUserLocationMapView> GetAllHouseLocation(string date, int userid, string SearchString, int? GarbageType, int FilterType);
    }
}
