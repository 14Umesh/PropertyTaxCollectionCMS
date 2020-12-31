using PropertyTaxCollectionCMS.Bll.Repository.Repository;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Models.SessionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyTaxCollectionCMS.Controllers.Report
{
    public class ReportController : Controller
    {
        IRepository Repository;
        public ReportController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository();
            }
            else
                Redirect("/Account/Login");
        }

        // GET: Report
        public ActionResult AttendenceReport()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpPost]
        public ActionResult GetEmployeeList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                EmployeeVM obj = new EmployeeVM();

                obj = Repository.GetEmployeeList();
                return Json(obj.UserList, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public JsonResult getAttendenceReport(string fromDate, string toDate,int q)
        {
            var griddata = Repository.getAttendenceReport(fromDate, toDate,q);
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult TaxReceiptReport()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public JsonResult getTaxReceiptReport(string fromDate, string toDate, int q = -1,int t=1)
        {
            int AppId = SessionHandler.Current.AppId;
            var griddata = Repository.getTaxReceiptReport(q,t, fromDate, toDate, AppId);
          
            var jsonResult = Json(new { aaData = griddata }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        public ActionResult TaxPaymentReport()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public JsonResult getTaxPaymentReport(string fromDate, string toDate, int q = -1,int t=2)
        {
            int AppId = SessionHandler.Current.AppId;
            var griddata = Repository.getTaxPaymentReport(q,t, fromDate, toDate, AppId);
       
            var jsonResult = Json(new { aaData = griddata }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult TaxReminderReport()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpPost]
        public JsonResult getTaxReminderReport(string fromDate, string toDate, int q = -1,int t=3)
        {
            int AppId = SessionHandler.Current.AppId;
            var griddata = Repository.getTaxReminderReport(q,t, fromDate, toDate,AppId);
            var jsonResult = Json(new { aaData = griddata }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        public ActionResult TaxSchedule()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        [HttpGet]
        public JsonResult getTaxSchedule(string fromDate, string toDate, int q = -1, int t = 3)
        {
            int AppId = SessionHandler.Current.AppId;
            var griddata = Repository.getTodaySchedule(q, t, fromDate, toDate, AppId);
          
            var jsonResult = Json(new { aaData = griddata }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}