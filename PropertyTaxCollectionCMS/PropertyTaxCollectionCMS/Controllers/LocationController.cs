
using PropertyTaxCollectionCMS.Bll.Repository.ChildRepository;
using PropertyTaxCollectionCMS.Bll.Repository.Repository;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Models.SessionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyTaxCollectionCMS.Controllers
{
    public class LocationController : Controller
    {

        IRepository Repository;

        IChildRepository childRepository;

        public LocationController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository();
                childRepository = new ChildRepository(SessionHandler.Current.AppId);

            }
            else
                Redirect("/Account/Login");
        }
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HouseOnMap()
        {
            return View();
        }

        public ActionResult AllHouseLocation()
        {
            if (SessionHandler.Current.AppId != 0)
            {
             ViewBag.lat = 21.141557158848535;
             ViewBag.lang = 79.06083081692962;
             ViewBag.AppName = SessionHandler.Current.AppName;
             int AppId = SessionHandler.Current.AppId;
             var details = childRepository.GetHouseOnMapDetails(AppId);
             return View(details);
            }
            else
                return Redirect("/Account/Login");
        }
        [HttpPost]
        public ActionResult HouseLocationList(string date, string userid, string SearchString, string garbageType, string filterType)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                int user;
                //int area;
                //int ward;
                int? GarbageType;
                int FilterType;
                if (userid == "-1" || userid == "0" || userid == "null")
                {
                    user = 0;
                }
                else
                {
                    user = Convert.ToInt32(userid);
                }

                //if (areaId == "-1" || areaId == "0" || areaId == "null")
                //{
                //    area = 0;
                //}
                //else
                //{
                //    area = Convert.ToInt32(areaId);
                //}
                //if (wardNo == "-1" || wardNo == "0" || wardNo == "null")
                //{
                //    ward = 0;
                //}
                //else
                //{
                //    ward = Convert.ToInt32(wardNo);
                //}
                if (garbageType == "-1" || garbageType == null)
                {
                    GarbageType = null;
                }
                else
                {
                    GarbageType = Convert.ToInt32(garbageType);
                }
                if (filterType == "-1" || filterType == "0" || filterType == "null")
                {
                    FilterType = 0;
                }
                else
                {
                    FilterType = Convert.ToInt32(filterType);
                }
                if (date == null || date == "")
                {
                    date = DateTime.Now.ToShortDateString();
                }

                List<PTCUserLocationMapView> obj = new List<PTCUserLocationMapView>();
                obj = childRepository.GetAllHouseLocation(date, user, SearchString, GarbageType, FilterType);
                // return Json(obj);
                //if (houseid != null && houseid != "null" && houseid != "-1")
                //{
                //    obj = obj.Where(c => c.houseId == Convert.ToInt32(houseid)).ToList();
                //}
                // return Json(obj, JsonRequestBehavior.AllowGet);

                var jsonResult = Json(obj, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
                return Redirect("/Account/Login");
        }
    }
}