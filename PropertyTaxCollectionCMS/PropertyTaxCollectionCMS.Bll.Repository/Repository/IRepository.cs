using PropertyTaxCollectionCMS.Bll.ViewModels;
using PropertyTaxCollectionCMS.Bll.ViewModels.Admin;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PropertyTaxCollectionCMS.Bll.Repository.Repository
{
    public interface IRepository
    {
        #region Common
        DashBoardVM DashBoardDetails(int AppId);
        List<SelectListItem> GetStateList();
        List<SelectListItem> GetTehsilList();
        List<SelectListItem> GetDistrictList();
        //List<SelectListItem> GetLanguageList();
        #endregion
        List<EmployeeVM> getEmployeeDetails();
        Result EmployeeSave(EmployeeVM _Employee);
        EmployeeVM getEmployeeDetailsByID(int q);
        Result ClientSave(ClientVM _client);
        List<ClientVM> getClientDetails();
        ClientVM getClientDetailsByID(int q);
        List<DashBoardVM> getAttendenceDetailsOnMap(int AppID);
        List<AttendanceDetailsVM> getAttendenceDetails();
        List<TaxReceiptDetailsVM> getTaxReceiptDetails(int q);
        List<TaxReceiptDetailsVM> getTaxReminderDetails(int q);
        EmployeeVM Login(EmployeeVM _userinfo);
        AppDetailsVM GetApplicationDetails(int AppId);
        List<TaxReceiptDetailsVM> getTaxPaymentReport(int q,string fromDate, string toDate);
        List<TaxReceiptDetailsVM> getTaxReceiptReport(int q, string fromDate, string toDate,int AppId);
        List<TaxReceiptDetailsVM> getTaxReminderReport(int q, string fromDate, string toDate);
        List<AttendanceDetailsVM> getAttendenceReport(string fromDate, string toDate);

        List<PTCUserLocationMapView> GetUserAttenRoute(int id);

        List<PTCUserLocationMapView> GetHouseAttenRoute(int id,int Appid);

    }
}
