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
    public class AttendenceController : Controller
    {

        IRepository Repository;
        // GET: Attendence

        public AttendenceController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository();
           //   childRepository = new ChildRepository(SessionHandler.Current.AppId);
            }
            else
                Redirect("/Account/Login");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRoute(int daId)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                ViewBag.daId = daId;
                return View();
            }
            else
                return Redirect("/Account/Login");

        }

        public ActionResult UserRouteData(int daId)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                List<PTCUserLocationMapView> obj = new List<PTCUserLocationMapView>();
                obj = Repository.GetUserAttenRoute(daId);
                // return Json(obj);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
                return Redirect("/Account/Login");

        }

        public ActionResult HouseRoute(int daId)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                ViewBag.daId = daId;
                ViewBag.lat = SessionHandler.Current.Latitude;
                ViewBag.lang = SessionHandler.Current.Logitude;
                return View();
            }
            else
                return Redirect("/Account/Login");

        }

        public ActionResult HouseRouteData(int daId)
        {
            if (SessionHandler.Current.AppId != 0)
            {

                List<PTCUserLocationMapView> obj = new List<PTCUserLocationMapView>();

                int Appid = SessionHandler.Current.AppId;
                obj = Repository.GetHouseAttenRoute(daId,Appid);
                // return Json(obj);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
                return Redirect("/Account/Login");

        }
    }
}