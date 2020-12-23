using PropertyTaxCollectionCMS.Bll.Repository.Repository;
using PropertyTaxCollectionCMS.Bll.ViewModels;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Models.SessionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyTaxCollectionCMS.Controllers
{
    public class HomeController : Controller
    {

        IRepository Repository;
        public HomeController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository();
            }
            else
                Redirect("/Account/Login");
        }
        public ActionResult Index()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                DashBoardVM _DashBoardVM = new DashBoardVM();
                _DashBoardVM = Repository.DashBoardDetails(SessionHandler.Current.AppId);
                return View(_DashBoardVM);
            }
            else
            {
                return Redirect("/Account/Login");  
            }
        }

        public ActionResult UserLocationList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                List<DashBoardVM> _DashBoardVM = new List<DashBoardVM>();
                _DashBoardVM = Repository.getAttendenceDetailsOnMap(SessionHandler.Current.AppId);
                //return View(_DashBoardVM);
                var jsonResult = Json(_DashBoardVM, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }
        [HttpGet]
        public ActionResult EmployeeTaxCollectionType()
        {
            if (SessionHandler.Current.AppId != 0)
            {

                IEnumerable<EmployeeTaxCollectionType> obj;

              

                obj = Repository.getEmployeeTaxCollectionType(SessionHandler.Current.AppId);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
                return Redirect("/Account/Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
              
    }
}