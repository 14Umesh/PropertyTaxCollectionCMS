using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropertyTaxCollectionCMS.Bll.Service.Services.AppService;

namespace PropertyTaxCollectionCMS.Bll.Service.Services
{
    //public class ScreenService : AppService,IScreenService

    //{

       
    //   // public List<PTCUserLocationMapView> GetUserAttenRoute(int daId)
    //  //  {
    //        //List<PTCUserLocationMapView> userLocation = new List<PTCUserLocationMapView>();
    //        //DateTime newdate = DateTime.Now.Date;
    //        //var datt = newdate;
          
    //        //var att = DBMain.EMPLOYEE_ATTENDANCE.Where(c => c.daID == daId).FirstOrDefault();
    //        //string Time = att.startTime;
    //        //DateTime date = DateTime.Parse(Time, System.Globalization.CultureInfo.CurrentCulture);
    //        //string t = date.ToString("hh:mm:ss tt");
    //        //string dt = Convert.ToDateTime(att.daDate).ToString("MM/dd/yyyy");
    //        //DateTime? fdate = Convert.ToDateTime(dt + " " + t);
    //        //DateTime? edate;
    //        //if (att.endTime == "" | att.endTime == null)
    //        //{
    //        //    edate = DateTime.Now;
    //        //}
    //        //else
    //        //{
    //        //    string Time2 = att.endTime;
    //        //    DateTime date2 = DateTime.Parse(Time2, System.Globalization.CultureInfo.CurrentCulture);
    //        //    string t2 = date2.ToString("hh:mm:ss tt");
    //        //    string dt2 = Convert.ToDateTime(att.daEndDate).ToString("MM/dd/yyyy");
    //        //    edate = Convert.ToDateTime(dt2 + " " + t2);
    //        //}
    //        //var data = db.Locations.Where(c => c.userId == att.userId & c.datetime >= fdate & c.datetime <= edate & c.type == null).ToList();


    //        //foreach (var x in data)
    //        //{

    //        //    string dat = Convert.ToDateTime(x.datetime).ToString("dd/MM/yyyy");
    //        //    string tim = Convert.ToDateTime(x.datetime).ToString("hh:mm tt");
    //        //    var userName = db.UserMasters.Where(c => c.userId == att.userId).FirstOrDefault();

    //        //    userLocation.Add(new PTCUserLocationMapView()
    //        //    {
    //        //        userId = userName.userId,
    //        //        userName = userName.userName,
    //        //        date = dat,
    //        //        time = tim,
    //        //        lat = x.lat,
    //        //        log = x.@long,
    //        //        address = checkNull(x.address).Replace("Unnamed Road, ", ""),
    //        //        vehcileNumber = att.vehicleNumber,
    //        //        userMobile = userName.userMobileNumber,
    //        //        // type = Convert.ToInt32(x.type),

    //        //    });

    //        //}

    //     //  return userLocation;
    //    }
    //}
}
