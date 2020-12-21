using PropertyTaxCollectionCMS.Bll.Repository.Repository;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Bll.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyTaxCollectionCMS.Models.SessionHandler;

namespace PropertyTaxCollectionCMS.Controllers.Master
{
    public class MasterController : Controller
    {

        IRepository Repository;
        
        public MasterController()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository();
            }
            else
                Redirect("/Account/Login");
        }

        // GET: Master

        [HttpPost]
        public ActionResult EmployeeList()
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
        public JsonResult getEmployeeDetails()
        {
            var griddata = Repository.getEmployeeDetails();
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Employee(int q=-1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                var viewModel = new EmployeeVM();
                viewModel = Repository.getEmployeeDetailsByID(q);
                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }


        [HttpPost]
        public ActionResult Employee(EmployeeVM Employee, HttpPostedFileBase file)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                if (file != null && file.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                    var fileName = Path.GetFileName(file.FileName);
                    var ext = Path.GetExtension(file.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        var path = Path.Combine(Server.MapPath("~/Images"), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Employee.PROFILE_IMAGE = myfile;
                        file.SaveAs(path);
                    }
                }

                Result Result = new Result();
                Result = Repository.EmployeeSave(Employee);
                ViewBag.Message = Result.message;

                return Redirect("/Master/EmployeeList");
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }

    }
}