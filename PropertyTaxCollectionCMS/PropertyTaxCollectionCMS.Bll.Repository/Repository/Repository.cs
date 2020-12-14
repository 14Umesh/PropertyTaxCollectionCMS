using PropertyTaxCollectionCMS.Bll.ViewModels;
using PropertyTaxCollectionCMS.Bll.ViewModels.Admin;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PropertyTaxCollectionCMS.Bll.Repository.Repository
{
    public class Repository : IRepository
    {
        #region Common

        public DashBoardVM DashBoardDetails(int AppId)
        {
            DashBoardVM Result = new DashBoardVM();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var UserAttendence = db.EMPLOYEE_ATTENDANCE.Where(c => EntityFunctions.TruncateTime(c.DA_START_DATETIME) == EntityFunctions.TruncateTime(DateTime.Now) &c.DA_END_DATETIME == null & c.APP_ID == AppId).Count();
                var TotalUser = db.AD_USER_MST.Where(c => c.APP_ID ==AppId).Count();
                
                var TaxReceipt = db.TAX_COLLECTION_DETAIL.Where(c => EntityFunctions.TruncateTime(c.PAYMENT_DATE) == EntityFunctions.TruncateTime(DateTime.Now) & c.TCAT_ID == 1 & c.APP_ID == AppId).Count();
                var TaxPayment = db.TAX_COLLECTION_DETAIL.Where(c => EntityFunctions.TruncateTime(c.PAYMENT_DATE) == EntityFunctions.TruncateTime(DateTime.Now) & c.TCAT_ID == 2 & c.APP_ID == AppId).Count();
                var Reminder = db.TAX_COLLECTION_DETAIL.Where(c => EntityFunctions.TruncateTime(c.REMINDER_NEW_DATE) == EntityFunctions.TruncateTime(DateTime.Now) & c.APP_ID == AppId).Count();

                Result.Attendence = UserAttendence + "/" + TotalUser;
                Result.TaxReceipt = TaxReceipt.ToString();
                Result.TaxPayment = TaxPayment.ToString();
                Result.Reminder = Reminder.ToString();

            }
            return Result;
        }

        public List<SelectListItem> GetStateList()
        {
            List<SelectListItem> state = new List<SelectListItem>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                SelectListItem itemstate = new SelectListItem() { Text = "Select State", Value = "0" };
                state = db.AD_STATE_MST.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.STATE_NAME,
                        Value = x.STATE_ID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                state.Insert(0, itemstate);
            }

            return state;

        }

        public List<SelectListItem> GetTehsilList()
        {

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var Tehsil = new List<SelectListItem>();

                SelectListItem itemTehsil = new SelectListItem() { Text = "Select Tehsil", Value = "0" };
                Tehsil = db.AD_TALUKA_MST.ToList()
                        .Select(x => new SelectListItem
                        {
                            Text = x.TALUKA_NAME,
                            Value = x.TALUKA_ID.ToString()
                        }).OrderBy(t => t.Text).ToList();
                Tehsil.Insert(0, itemTehsil);

                return Tehsil;
            }

        }

        public List<SelectListItem> GetDistrictList()
        {

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var district = new List<SelectListItem>();

                SelectListItem itemdistrict = new SelectListItem() { Text = "Select District", Value = "0" };
                district = db.AD_CITY_MST.ToList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.CITY,
                        Value = x.CITY_ID.ToString()
                    }).OrderBy(t => t.Text).ToList();
                district.Insert(0, itemdistrict);

                return district;
            }

        }

        #endregion

        public List<EmployeeVM> getEmployeeDetails()
        {
            List<EmployeeVM> result = new List<EmployeeVM>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var task = db.AD_USER_MST.ToList();

                foreach (var x in task)
                {
                    result.Add(new EmployeeVM()
                    {

                        ADUM_USER_CODE = x.ADUM_USER_CODE,
                        SERVER_ID = Convert.ToByte(x.SERVER_ID),
                        APP_ID = x.APP_ID,
                        ADUM_USER_ID = x.ADUM_USER_ID,
                        ADUM_USER_NAME = x.ADUM_USER_NAME,
                        ADUM_LOGIN_ID = x.ADUM_LOGIN_ID,
                        ADUM_PASSWORD = x.ADUM_PASSWORD,
                        ADUM_EMPLOYEE_ID = x.ADUM_EMPLOYEE_ID,
                        ADUM_DESIGNATION = x.ADUM_DESIGNATION,
                        ADUM_MOBILE = x.ADUM_MOBILE,
                        ADUM_EMAIL = x.ADUM_EMAIL,
                        LOCAL_USER_NAME = x.LOCAL_USER_NAME,
                        PROFILE_IMAGE = "~/Images/" + x.PROFILE_IMAGE,
                        ADUM_FRDT = Convert.ToDateTime(x.ADUM_FRDT).ToString(),
                        ADUM_TODT = Convert.ToDateTime(x.ADUM_TODT).ToString(),
                        ADUM_STATUS = Convert.ToBoolean(x.ADUM_STATUS),
                        UPDATE_FLAG = Convert.ToBoolean(x.UPDATE_FLAG),
                        LAST_UPDATE = Convert.ToDateTime(x.LAST_UPDATE).ToString(),
                        AD_USER_TYPE_ID = Convert.ToInt32(x.AD_USER_TYPE_ID),
                        MOBILE_ID = x.MOBILE_ID,
                        IS_ACTIVE = Convert.ToBoolean(x.IS_ACTIVE),

                    });
                }
            }

            return result;
        }

        public Result EmployeeSave(EmployeeVM _Employee)
         {
            Result Result = new Result();
            try
            {
                using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
                {
                    var obj = db.AD_USER_MST.Where(x => x.ADUM_USER_CODE == _Employee.ADUM_USER_CODE).FirstOrDefault();
                    if (obj != null)
                    {

                        obj.SERVER_ID = Convert.ToByte(_Employee.SERVER_ID);
                        obj.APP_ID = _Employee.APP_ID;
                        obj.ADUM_USER_ID = _Employee.ADUM_LOGIN_ID;
                        obj.ADUM_USER_NAME = _Employee.ADUM_USER_NAME;
                        obj.ADUM_LOGIN_ID = _Employee.ADUM_LOGIN_ID;
                        obj.ADUM_PASSWORD = _Employee.ADUM_PASSWORD;
                        obj.ADUM_EMPLOYEE_ID = _Employee.ADUM_EMPLOYEE_ID;
                        obj.ADUM_DESIGNATION = _Employee.ADUM_DESIGNATION;
                        obj.ADUM_MOBILE = _Employee.ADUM_MOBILE;
                        obj.ADUM_EMAIL = _Employee.ADUM_EMAIL;
                        obj.LOCAL_USER_NAME = _Employee.LOCAL_USER_NAME;
                        if (_Employee.PROFILE_IMAGE != null)
                        {
                            obj.PROFILE_IMAGE = _Employee.PROFILE_IMAGE;
                        }
                        //obj.ADUM_FRDT = Convert.ToDateTime(_Employee.ADUM_FRDT);
                        //obj.ADUM_TODT = Convert.ToDateTime(_Employee.ADUM_TODT);
                        obj.UPDATE_FLAG = _Employee.UPDATE_FLAG;
                        obj.LAST_UPDATE = DateTime.Now;//Convert.ToDateTime(_Employee.LAST_UPDATE);
                        obj.AD_USER_TYPE_ID = _Employee.AD_USER_TYPE_ID;
                        obj.IS_ACTIVE = _Employee.IS_ACTIVE;
                    }
                    else
                    {
                        AD_USER_MST Master = new AD_USER_MST();

                        Master.SERVER_ID = Convert.ToByte(_Employee.SERVER_ID);
                        Master.APP_ID = _Employee.APP_ID;
                        Master.ADUM_USER_ID = _Employee.ADUM_LOGIN_ID;
                        Master.ADUM_USER_NAME = _Employee.ADUM_USER_NAME;
                        Master.ADUM_LOGIN_ID = _Employee.ADUM_LOGIN_ID;
                        Master.ADUM_PASSWORD = _Employee.ADUM_PASSWORD;
                        Master.ADUM_EMPLOYEE_ID = _Employee.ADUM_EMPLOYEE_ID;
                        Master.ADUM_DESIGNATION = _Employee.ADUM_DESIGNATION;
                        Master.ADUM_MOBILE = _Employee.ADUM_MOBILE;
                        Master.ADUM_EMAIL = _Employee.ADUM_EMAIL;
                        Master.LOCAL_USER_NAME = _Employee.LOCAL_USER_NAME;
                        Master.PROFILE_IMAGE = _Employee.PROFILE_IMAGE;
                        //Master.ADUM_FRDT = Convert.ToDateTime(_Employee.ADUM_FRDT);
                        //Master.ADUM_TODT = Convert.ToDateTime(_Employee.ADUM_TODT);
                        Master.UPDATE_FLAG = _Employee.UPDATE_FLAG;
                        Master.LAST_UPDATE = DateTime.Now;
                        Master.AD_USER_TYPE_ID = _Employee.AD_USER_TYPE_ID;
                        Master.IS_ACTIVE = _Employee.IS_ACTIVE;
                        db.AD_USER_MST.Add(Master);
                    }

                    db.SaveChanges();
                    Result.message = "success";
                }
            }
            catch(Exception ex)
            {
                Result.message = "error";
            }

            return Result;
        }

        public EmployeeVM getEmployeeDetailsByID(int q)
        {
            EmployeeVM data = new EmployeeVM();
            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var task = db.AD_USER_MST.Where(c => c.ADUM_USER_CODE == q).FirstOrDefault();

                if (task != null)
                {
                    data.ADUM_USER_CODE = task.ADUM_USER_CODE;
                    data.SERVER_ID = Convert.ToByte(task.SERVER_ID);
                    data.APP_ID = task.APP_ID;
                    data.ADUM_USER_ID = task.ADUM_LOGIN_ID;
                    data.ADUM_USER_NAME = task.ADUM_USER_NAME;
                    data.ADUM_LOGIN_ID = task.ADUM_LOGIN_ID;
                    data.ADUM_PASSWORD = task.ADUM_PASSWORD;
                    data.ADUM_EMPLOYEE_ID = task.ADUM_EMPLOYEE_ID;
                    data.ADUM_DESIGNATION = task.ADUM_DESIGNATION;
                    data.ADUM_MOBILE = task.ADUM_MOBILE;
                    data.ADUM_EMAIL = task.ADUM_EMAIL;
                    data.LOCAL_USER_NAME = task.LOCAL_USER_NAME;
                    data.PROFILE_IMAGE = "/Images/" + task.PROFILE_IMAGE;
                    data.UPDATE_FLAG = Convert.ToBoolean(task.UPDATE_FLAG);
                    data.AD_USER_TYPE_ID = Convert.ToInt32(task.AD_USER_TYPE_ID);
                    data.IS_ACTIVE = Convert.ToBoolean(task.IS_ACTIVE);
                }
            }
            return data;
        }

        public Result ClientSave(ClientVM _Client)
        {
            Result Result = new Result();
            try
            {
                using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
                {
                    var obj = db.APP_DETAILS.Where(x => x.AppId == _Client.AppId).FirstOrDefault();
                    if (obj != null)
                    {

                        obj.AppName = _Client.AppName;
                        obj.AppName_mar = _Client.AppName_mar;
                        obj.State = _Client.State;
                        obj.District = _Client.District;
                        obj.Tehsil = _Client.Tehsil;
                        obj.EmailId = _Client.EmailId;
                        obj.website = _Client.website;
                        obj.baseImageUrlCMS = _Client.baseImageUrlCMS;
                        obj.baseImageUrl = _Client.baseImageUrl;
                        obj.basePath = _Client.basePath;
                        obj.Latitude = _Client.Latitude;
                        obj.Logitude = _Client.Logitude;
                        obj.AppVersion = _Client.AppVersion;
                        obj.IsActive = _Client.IsActive;
                        obj.ForceUpdate = _Client.ForceUpdate;

                    }
                    else
                    {
                        APP_DETAILS Master = new APP_DETAILS();

                        Master.AppName = _Client.AppName;
                        Master.AppName_mar = _Client.AppName_mar;
                        Master.State = _Client.State;
                        Master.District = _Client.District;
                        Master.Tehsil = _Client.Tehsil;
                        Master.EmailId = _Client.EmailId;
                        Master.website = _Client.website;
                        Master.baseImageUrlCMS = _Client.baseImageUrlCMS;
                        Master.baseImageUrl = _Client.baseImageUrl;
                        Master.basePath = _Client.basePath;
                        Master.Latitude = _Client.Latitude;
                        Master.Logitude = _Client.Logitude;
                        Master.AppVersion = _Client.AppVersion;
                        Master.IsActive = _Client.IsActive;
                        Master.ForceUpdate = _Client.ForceUpdate;

                        db.APP_DETAILS.Add(Master);
                    }

                    db.SaveChanges();
                    Result.message = "success";
                }
            }
            catch
            {
                Result.message = "error";
            }

            return Result;
        }

        public List<ClientVM> getClientDetails()
        {
            List<ClientVM> result = new List<ClientVM>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var task = //db.APP_DETAILS.ToList();
                (from a in db.APP_DETAILS
                 join b in db.AD_STATE_MST on a.State equals b.STATE_ID
                 join c in db.AD_CITY_MST on a.District equals c.CITY_ID
                 join d in db.AD_TALUKA_MST on a.Tehsil equals d.TALUKA_ID

                 select new
                 {
                    a.AppId,
                    a.AppName,
                    b.STATE_NAME,
                    c.CITY,
                    d.TALUKA_NAME,
                    a.AppVersion,
                    a.ForceUpdate,
                    a.IsActive

                 }).ToList();

                foreach (var x in task)
                {
                    result.Add(new ClientVM()
                    {
                        AppId = x.AppId,
                        AppName = x.AppName,
                        StateName = x.STATE_NAME,
                        TehsilName = x.TALUKA_NAME,
                        DistrictName = x.CITY,
                        AppVersion = x.AppVersion,
                        ForceUpdate = Convert.ToBoolean(x.ForceUpdate),
                        IsActive = Convert.ToBoolean(x.IsActive),
                        
                    });
                }
            }

            return result;
        }

        public ClientVM getClientDetailsByID(int q)
        {
            ClientVM data = new ClientVM();
            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var obj = db.APP_DETAILS.Where(c => c.AppId == q).FirstOrDefault();

                if (obj != null)
                {
                    data.AppName = obj.AppName;
                    data.AppName_mar = obj.AppName_mar;
                    data.State = Convert.ToInt32(obj.State);
                    data.District = Convert.ToInt32(obj.District);
                    data.Tehsil = Convert.ToInt32(obj.Tehsil);
                    data.EmailId = obj.EmailId;
                    data.website = obj.website;
                    data.baseImageUrlCMS = obj.baseImageUrlCMS;
                    data.baseImageUrl = obj.baseImageUrl;
                    data.basePath = obj.basePath;
                    data.Latitude = obj.Latitude;
                    data.Logitude = obj.Logitude;
                    data.AppVersion = obj.AppVersion;
                    data.IsActive = Convert.ToBoolean(obj.IsActive);
                    data.ForceUpdate = Convert.ToBoolean(obj.ForceUpdate);
                }
            }
            return data;
        }

        public List<DashBoardVM> getAttendenceDetailsOnMap(int AppID)
        {
            List<DashBoardVM> Result = new List<DashBoardVM>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var UserAttendence = (from EA in db.EMPLOYEE_ATTENDANCE
                                      join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                                      where EntityFunctions.TruncateTime(EA.DA_START_DATETIME) == EntityFunctions.TruncateTime(DateTime.Now) & EA.APP_ID == AppID & EA.DA_END_DATETIME==null
                                      select new
                                      {
                                          UserName = UM.ADUM_USER_NAME,
                                          InTime = EA.DA_START_DATETIME,
                                          InLat = EA.START_LAT,
                                          InLong = EA.START_LONG,
                                      }).ToList();


                foreach (var x in UserAttendence)
                {
                    Result.Add(new DashBoardVM()
                    {
                        UserName = x.UserName,
                        InTime = Convert.ToDateTime(x.InTime).ToString("hh:mm tt"),
                        InLat = x.InLat.ToString(),
                        InLong = x.InLong.ToString(),
                    });
                }
            }
            return Result;
        }

        public List<AttendanceDetailsVM> getAttendenceDetails()
        {
            List<AttendanceDetailsVM> Result = new List<AttendanceDetailsVM>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var UserAttendence = (from EA in db.EMPLOYEE_ATTENDANCE
                                      join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                                      where EntityFunctions.TruncateTime(EA.DA_START_DATETIME) == EntityFunctions.TruncateTime(DateTime.Now)
                                      select new
                                      {
                                          UserName = UM.ADUM_USER_NAME,
                                          StartDate = EA.DA_START_DATETIME,
                                          EndDate = EA.DA_END_DATETIME,
                                          InLat = EA.START_LAT,
                                          InLong = EA.END_LAT,
                                      }).ToList();


                foreach (var x in UserAttendence)
                {
                    Result.Add(new AttendanceDetailsVM()
                    {
                        UserName = x.UserName,
                        StartDate = Convert.ToDateTime(x.StartDate).ToString("dd/MM/yyyy"),
                        StartTime = Convert.ToDateTime(x.StartDate).ToString("hh:mm tt"),
                        EndDate = (x.EndDate == null ? "" : Convert.ToDateTime(x.EndDate).ToString("dd/MM/yyyy")),
                        EndTime = (x.EndDate == null ? "" : Convert.ToDateTime(x.EndDate).ToString("hh:mm tt")),
                    });
                }
            }
            return Result;
        }

        public List<TaxReceiptDetailsVM> getTaxReceiptDetails(int q)
        {
            List<TaxReceiptDetailsVM> Result = new List<TaxReceiptDetailsVM>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var sqlData = (from TC in db.TAX_COLLECTION_DETAIL
                                      //join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                                      where EntityFunctions.TruncateTime(TC.PAYMENT_DATE) == EntityFunctions.TruncateTime(DateTime.Now) & TC.TCAT_ID == q
                                      select new
                                      {
                                          
                                          TC_ID = TC.TC_ID,
                                          TCAT_ID = TC.TCAT_ID,
                                          RECEIPT_NO = TC.RECIPT_NO,
                                          TOTAL_AMOUNT = TC.TOTAL_AMOUNT,
                                          RECEIVED_AMOUNT = TC.RECEIVED_AMOUNT,
                                          REMAINING_AMOUNT = TC.REMAINING_AMOUNT,
                                          HOUSEID = TC.HOUSEID,
                                          RECEIVER_NAME = TC.RECEIVER_NAME,
                                          RECEIVER_SIGNATURE = TC.RECEIVER_SIGNATURE_IMAGE,
                                      }).ToList();


                foreach (var x in sqlData)
                {
                    Result.Add(new TaxReceiptDetailsVM()
                    {
                        TC_ID = x.TC_ID,
                        TCAT_ID = x.TCAT_ID,
                        RECEIPT_NO = x.RECEIPT_NO,
                        TOTAL_AMOUNT = Convert.ToDecimal(x.TOTAL_AMOUNT),
                        RECEIVED_AMOUNT = Convert.ToDecimal(x.RECEIVED_AMOUNT),
                        REMAINING_AMOUNT = Convert.ToDecimal(x.REMAINING_AMOUNT),
                        HOUSEID = x.HOUSEID,
                        RECEIVER_NAME = x.RECEIVER_NAME,
                        RECEIVER_SIGNATURE = x.RECEIVER_SIGNATURE,
                    });
                }
            }
            return Result;
        }

        public List<TaxReceiptDetailsVM> getTaxReminderDetails(int q)
        {
            List<TaxReceiptDetailsVM> Result = new List<TaxReceiptDetailsVM>();

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var sqlData = (from TC in db.TAX_COLLECTION_DETAIL
                                   //join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                               where EntityFunctions.TruncateTime(TC.REMINDER_NEW_DATE) == EntityFunctions.TruncateTime(DateTime.Now) 
                               select new
                               {

                                   TC_ID = TC.TC_ID,
                                   TCAT_ID = TC.TCAT_ID,
                                   RECEIPT_NO = TC.RECIPT_NO,
                                   TOTAL_AMOUNT = TC.TOTAL_AMOUNT,
                                   RECEIVED_AMOUNT = TC.RECEIVED_AMOUNT,
                                   REMAINING_AMOUNT = TC.REMAINING_AMOUNT,
                                   HOUSEID = TC.HOUSEID,
                                   RECEIVER_NAME = TC.RECEIVER_NAME,
                                   RECEIVER_SIGNATURE = TC.RECEIVER_SIGNATURE_IMAGE,
                               }).ToList();


                foreach (var x in sqlData)
                {
                    Result.Add(new TaxReceiptDetailsVM()
                    {
                        TC_ID = x.TC_ID,
                        TCAT_ID = x.TCAT_ID,
                        RECEIPT_NO = x.RECEIPT_NO,
                        TOTAL_AMOUNT = Convert.ToDecimal(x.TOTAL_AMOUNT),
                        RECEIVED_AMOUNT = Convert.ToDecimal(x.RECEIVED_AMOUNT),
                        REMAINING_AMOUNT = Convert.ToDecimal(x.REMAINING_AMOUNT),
                        HOUSEID = x.HOUSEID,
                        RECEIVER_NAME = x.RECEIVER_NAME,
                        RECEIVER_SIGNATURE = x.RECEIVER_SIGNATURE,
                    });
                }
            }
            return Result;
        }

        public EmployeeVM Login(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                var appUser = (db.AD_USER_MST.Where(x => x.ADUM_LOGIN_ID == _userinfo.ADUM_LOGIN_ID && x.ADUM_PASSWORD == _userinfo.ADUM_PASSWORD).FirstOrDefault());
                if (appUser != null)
                {
                    _EmployeeVM.ADUM_LOGIN_ID = appUser.ADUM_LOGIN_ID;
                    _EmployeeVM.APP_ID = appUser.APP_ID;
                    _EmployeeVM.ADUM_USER_NAME = appUser.ADUM_USER_NAME;
                    _EmployeeVM.ADUM_USER_CODE = Convert.ToInt32(appUser.ADUM_USER_CODE);
                    _EmployeeVM.status = "Success";

                    return _EmployeeVM;
                }
                else
                {
                    _EmployeeVM.status = "Failure";
                    return _EmployeeVM;
                }
            }
        }

        public AppDetailsVM GetApplicationDetails(int AppId)
        {
            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {
                AppDetailsVM model = new AppDetailsVM();
                var appDetails = (db.APP_DETAILS.Where(x => x.AppId == AppId).FirstOrDefault());
                if (appDetails != null)
                {
                    model.AppId = appDetails.AppId;
                    model.AppName = appDetails.AppName;
                    model.State = appDetails.State;
                    model.Tehsil = appDetails.Tehsil;
                    model.District = appDetails.District;
                    model.EmailId = appDetails.EmailId;
                    model.website = appDetails.website;
                    model.Android_GCM_pushNotification_Key = appDetails.Android_GCM_pushNotification_Key;
                    model.AppVersion = appDetails.AppVersion;
                    model.ForceUpdate = appDetails.ForceUpdate;
                    model.IsActive = appDetails.IsActive;
                    model.CreatedDate = DateTime.Now;
                    return model;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<TaxReceiptDetailsVM> getTaxPaymentReport(int q, string fromDate, string toDate)
        {
            List<TaxReceiptDetailsVM> Result = new List<TaxReceiptDetailsVM>();

            DateTime _fromDate = DateTime.ParseExact(fromDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _fdate = new DateTime(_fromDate.Year, _fromDate.Month, _fromDate.Day, 00, 00, 00, 000);  //Today at 00:00:00
            
            DateTime Dateeee = DateTime.ParseExact(toDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _tdate = new DateTime(Dateeee.Year, Dateeee.Month, Dateeee.Day, 23, 59, 59, 999); // Dateeee.AddDays(1).AddTicks

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var sqlData = (from TC in db.TAX_COLLECTION_DETAIL
                                   //join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                               where TC.PAYMENT_DATE >= _fdate & TC.PAYMENT_DATE < _tdate & TC.TCAT_ID == q
                               select new
                               {
                                   TC_ID = TC.TC_ID,
                                   TCAT_ID = TC.TCAT_ID,
                                   RECEIPT_NO = TC.RECIPT_NO,
                                   TOTAL_AMOUNT = TC.TOTAL_AMOUNT,
                                   RECEIVED_AMOUNT = TC.RECEIVED_AMOUNT,
                                   REMAINING_AMOUNT = TC.REMAINING_AMOUNT,
                                   HOUSEID = TC.HOUSEID,
                                   RECEIVER_NAME = TC.RECEIVER_NAME,
                                   RECEIVER_SIGNATURE = TC.RECEIVER_SIGNATURE_IMAGE,
                                   PAYMENT_DATE = TC.PAYMENT_DATE,
                               }).ToList();


                foreach (var x in sqlData)
                {
                    Result.Add(new TaxReceiptDetailsVM()
                    {
                        TC_ID = x.TC_ID,
                        TCAT_ID = x.TCAT_ID,
                        RECEIPT_NO = x.RECEIPT_NO,
                        TOTAL_AMOUNT = Convert.ToDecimal(x.TOTAL_AMOUNT),
                        RECEIVED_AMOUNT = Convert.ToDecimal(x.RECEIVED_AMOUNT),
                        REMAINING_AMOUNT = Convert.ToDecimal(x.REMAINING_AMOUNT),
                        HOUSEID = x.HOUSEID,
                        RECEIVER_NAME = x.RECEIVER_NAME,
                        RECEIVER_SIGNATURE = x.RECEIVER_SIGNATURE,
                        PAYMENT_DATE = Convert.ToDateTime(x.PAYMENT_DATE).ToString("dd/MM/yyyy"),
                    });
                }
            }
            return Result;
        }

        public List<TaxReceiptDetailsVM> getTaxReceiptReport(int q, string fromDate, string toDate,int AppId)
        {
            List<TaxReceiptDetailsVM> Result = new List<TaxReceiptDetailsVM>();

            DateTime _fromDate = DateTime.ParseExact(fromDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _fdate = new DateTime(_fromDate.Year, _fromDate.Month, _fromDate.Day, 00, 00, 00, 000);  //Today at 00:00:00

            DateTime Dateeee = DateTime.ParseExact(toDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _tdate = new DateTime(Dateeee.Year, Dateeee.Month, Dateeee.Day, 23, 59, 59, 999); // Dateeee.AddDays(1).AddTicks

            using ( PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                PropertyTaxCollectionCMSChild_Entities db1 = new PropertyTaxCollectionCMSChild_Entities(AppId);

                var house = db1.HouseMasters.ToList();

                var AD_USER_MST = db.AD_USER_MST.ToList();

                var TAX_COLLECTION_DETAIL = db.TAX_COLLECTION_DETAIL.Where(c => c.PAYMENT_DATE >= _fdate & c.PAYMENT_DATE < _tdate & c.TCAT_ID == q).ToList();

                var sqlData = (from TC in TAX_COLLECTION_DETAIL
                               join UM in AD_USER_MST on TC.ADUM_USER_CODE equals
                               UM.ADUM_USER_CODE
                               join HS in house on TC.HOUSEID equals
                                HS.houseId
                               select new
                               {
                                   ADUM_USER_NAME = UM.ADUM_USER_NAME,
                                   PAYMENT_DATE = TC.PAYMENT_DATE,
                                   TC_ID = TC.TC_ID,
                                   TCAT_ID = TC.TCAT_ID,
                                   RECEIPT_NO = TC.RECIPT_NO,
                                   houseOwner = HS.houseOwner,
                                   TOTAL_AMOUNT = TC.TOTAL_AMOUNT,
                                   RECEIVED_AMOUNT = TC.RECEIVED_AMOUNT,
                                   REMAINING_AMOUNT = TC.REMAINING_AMOUNT,
                                   HOUSEID = TC.HOUSEID,
                                   RECEIVER_NAME = TC.RECEIVER_NAME,
                                   RECEIVER_SIGNATURE = TC.RECEIVER_SIGNATURE_IMAGE,

                               }).ToList();
                foreach (var x in sqlData)
                {
                    Result.Add(new TaxReceiptDetailsVM()
                    {
                        ADUM_USER_NAME = x.ADUM_USER_NAME,
                        TC_ID = x.TC_ID,
                        TCAT_ID = x.TCAT_ID,
                        RECEIPT_NO = x.RECEIPT_NO,
                        House_Owner_NAME=x.houseOwner,
                        PAYMENT_DATE = Convert.ToDateTime(x.PAYMENT_DATE).ToString("dd/MM/yyyy hh:mm tt"),
                        TOTAL_AMOUNT = Convert.ToDecimal(x.TOTAL_AMOUNT),
                        RECEIVED_AMOUNT = Convert.ToDecimal(x.RECEIVED_AMOUNT),
                        REMAINING_AMOUNT = Convert.ToDecimal(x.REMAINING_AMOUNT),
                        HOUSEID = x.HOUSEID,
                        RECEIVER_NAME = x.RECEIVER_NAME,
                        RECEIVER_SIGNATURE = x.RECEIVER_SIGNATURE,
                        
                    });
                }
            }
            return Result;
        }

        public List<TaxReceiptDetailsVM> getTaxReminderReport(int q, string fromDate, string toDate)
        {
            List<TaxReceiptDetailsVM> Result = new List<TaxReceiptDetailsVM>();

            DateTime _fromDate = DateTime.ParseExact(fromDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _fdate = new DateTime(_fromDate.Year, _fromDate.Month, _fromDate.Day, 00, 00, 00, 000);  //Today at 00:00:00

            DateTime Dateeee = DateTime.ParseExact(toDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _tdate = new DateTime(Dateeee.Year, Dateeee.Month, Dateeee.Day, 23, 59, 59, 999); // Dateeee.AddDays(1).AddTicks


            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var sqlData = (from TC in db.TAX_COLLECTION_DETAIL
                                   //join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                               where TC.REMINDER_NEW_DATE >= _fdate & TC.REMINDER_NEW_DATE < _tdate
                               select new
                               {

                                   TC_ID = TC.TC_ID,
                                   TCAT_ID = TC.TCAT_ID,
                                   RECEIPT_NO = TC.RECIPT_NO,
                                   TOTAL_AMOUNT = TC.TOTAL_AMOUNT,
                                   RECEIVED_AMOUNT = TC.RECEIVED_AMOUNT,
                                   REMAINING_AMOUNT = TC.REMAINING_AMOUNT,
                                   HOUSEID = TC.HOUSEID,
                                   RECEIVER_NAME = TC.RECEIVER_NAME,
                                   RECEIVER_SIGNATURE = TC.RECEIVER_SIGNATURE_IMAGE,
                                   PAYMENT_DATE = TC.PAYMENT_DATE,
                               }).ToList();


                foreach (var x in sqlData)
                {
                    Result.Add(new TaxReceiptDetailsVM()
                    {
                        TC_ID = x.TC_ID,
                        TCAT_ID = x.TCAT_ID,
                        RECEIPT_NO = x.RECEIPT_NO,
                        TOTAL_AMOUNT = Convert.ToDecimal(x.TOTAL_AMOUNT),
                        RECEIVED_AMOUNT = Convert.ToDecimal(x.RECEIVED_AMOUNT),
                        REMAINING_AMOUNT = Convert.ToDecimal(x.REMAINING_AMOUNT),
                        HOUSEID = x.HOUSEID,
                        RECEIVER_NAME = x.RECEIVER_NAME,
                        RECEIVER_SIGNATURE = x.RECEIVER_SIGNATURE,
                        PAYMENT_DATE = Convert.ToDateTime(x.PAYMENT_DATE).ToString("dd/MM/yyyy"),
                    });
                }
            }
            return Result;
        }


        public List<AttendanceDetailsVM> getAttendenceReport(string fromDate, string toDate)
        {
            List<AttendanceDetailsVM> Result = new List<AttendanceDetailsVM>();

            DateTime _fromDate = DateTime.ParseExact(fromDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _fdate = new DateTime(_fromDate.Year, _fromDate.Month, _fromDate.Day, 00, 00, 00, 000); 

            DateTime Dateeee = DateTime.ParseExact(toDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            DateTime _tdate = new DateTime(Dateeee.Year, Dateeee.Month, Dateeee.Day, 23, 59, 59, 999);

            using (PropertyTaxCollectionCMSMain_Entities db = new PropertyTaxCollectionCMSMain_Entities())
            {

                var UserAttendence = (from EA in db.EMPLOYEE_ATTENDANCE
                                      join UM in db.AD_USER_MST on EA.ADUM_USER_CODE equals UM.ADUM_USER_CODE
                                      where EA.DA_START_DATETIME >= _fdate & EA.DA_START_DATETIME < _tdate
                                      orderby EA.DA_ID descending
                                      select new
                                      {
                                          UserName = UM.ADUM_USER_NAME,
                                          StartDate = EA.DA_START_DATETIME,
                                          EndDate = EA.DA_END_DATETIME,
                                          InLat = EA.START_LAT,
                                          InLong = EA.END_LAT,
                                      }).ToList();


                foreach (var x in UserAttendence)
                {
                    Result.Add(new AttendanceDetailsVM()
                    {
                        UserName = x.UserName,
                        StartDate = Convert.ToDateTime(x.StartDate).ToString("dd/MM/yyyy hh:mm tt"),
                        EndDate = (x.EndDate == null ? "" : Convert.ToDateTime(x.EndDate).ToString("dd/MM/yyyy hh:mm tt")),                       
                    });
                }
            }
            return Result;
        }

    }
}
