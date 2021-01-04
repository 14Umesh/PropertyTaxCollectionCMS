using PropertyTaxCollectionCMS.Bll.ViewModels;
using PropertyTaxCollectionCMS.Bll.ViewModels.Master;
using PropertyTaxCollectionCMS.Dal.DataContexts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropertyTaxCollectionCMS.Bll.Service.Services.AppService;


namespace PropertyTaxCollectionCMS.Bll.Service.Services
{
  public class ScreenService : AppService,IScreenService

    {



        private int AppID;
        public ScreenService(int AppId) : base(AppId)
        {
            AppID = AppId;
        }
        public DashBoardVM GetHouseOnMapDetails(int AppId)
        {
            DashBoardVM model = new DashBoardVM();
            try
            {
             
                using (var db = new PropertyTaxCollectionCMSChild_Entities(AppId))
                {

                    //DevSwachhBharatMainEntities dbm = new DevSwachhBharatMainEntities();
                    //var appdetails = dbm.AppDetails.Where(c => c.AppId == AppID).FirstOrDefault();
                    //List<ComplaintVM> obj = new List<ComplaintVM>();
                    //if (AppID == 1)
                    //{
                    //    string json = new WebClient().DownloadString(appdetails.Grampanchayat_Pro + "/api/Get/Complaint?appId=1");
                    //    obj = JsonConvert.DeserializeObject<List<ComplaintVM>>(json).Where(c => Convert.ToDateTime(c.createdDate2).ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy")).ToList();
                    //}


                    var data = db.SP_HouseTaxCollection_Count().First();

                    //var date = DateTime.Today;
                    //var houseCount = db.SP_TotalHouseCollection_Count(date).FirstOrDefault();
                    if (data != null)
                    {

                        model.TotalHouseCount = data.TotalHouseCount;
                        model.HouseCollection = data.TotalHouseLatLongCount;
                        //   model.TotalScanHouseCount = data.TotalScanHouseCount;
                        model.TaxPaymentCount = data.TaxPaymentCount;
                        model.TaxReceiptCount = data.TaxReceiptCount;
                        model.TaxReminderCount = data.TaxReminderCount;
                        //   model.NotSpecified = data.NotSpecified;
                        return model;
                    }

                    // String.Format("{0:0.00}", 123.4567); 

                    else
                    {
                        return model;
                    }
                }
            }
            catch (Exception ex)
            {
                return model;
            }
        }


        public List<PTCUserLocationMapView> GetAllHouseLocation(string date, int userid, string SearchString, int? GarbageType, int FilterType)
        {

            List<PTCUserLocationMapView> houseLocation = new List<PTCUserLocationMapView>();
            var zoneId = 0;
            DateTime dt1 = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);
            var data = db.SP_HouseOnMapDetailsForTax(Convert.ToDateTime(dt1), userid == -1 ? 0 : userid, GarbageType, FilterType).ToList();
            foreach (var x in data)
            {

                DateTime dt = DateTime.Parse(x.PAYMENT_DATE == null ? DateTime.Now.ToString() : x.PAYMENT_DATE.ToString());
                //string gcTime = x.gcDate.ToString();
                houseLocation.Add(new PTCUserLocationMapView()
                {
                   // HouseId = Convert.ToInt32(x.houseId),
                    HouseId = x.ReferanceId,
                    HouseOwnerName = (x.houseOwner == null ? "" : x.houseOwner),
                    OwnerMobileNo = (x.houseOwnerMobile == null ? "" : x.houseOwnerMobile),
                    HouseAddress = checkNull(x.houseAddress).Replace("Unnamed Road, ", ""),
                    date = dt.ToString("dd-MM-yyyy"),
                   // gcTime = dt.ToString("h:mm tt"), // 7:00 AM // 12 hour clock
                    //string gcTime = x.gcDate.ToString(),
                    //gcTime = x.gcDate.ToString("hh:mm tt"),
                    //myDateTime.ToString("HH:mm:ss")
                    ///date = Convert.ToDateTime(x.datt).ToString("dd/MM/yyyy"),
                    //time = Convert.ToDateTime(x.datt).ToString("hh:mm:ss tt"),
                    lat = x.houseLat,
                    log = x.houseLong,
                    // address = x.houseAddress,
                    //vehcileNumber = x.v,
                    //userMobile = x.mobile,
                  // TCAT_ID = x.TCAT_ID
                });
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                // var abc = db.HouseMasters.ToList();
                var model = houseLocation.Where(c => c.HouseOwnerName.Contains(SearchString) || c.HouseId.Contains(SearchString)
                                                     || c.HouseOwnerName.ToLower().Contains(SearchString) || c.HouseId.ToLower().Contains(SearchString)).ToList();

                //var model = houseLocation.Where(c => ((string.IsNullOrEmpty(c.ReferanceId) ? " " : c.houseOwnerName) + " " +
                //                                     (string.IsNullOrEmpty(c.houseOwnerName) ? " " : c.houseOwnerName) + " " +
                //                                     (string.IsNullOrEmpty(c.houseOwnerMobile) ? " " : c.houseOwnerMobile) + " " +
                //                                     (string.IsNullOrEmpty(c.houseAddress) ? " " : c.houseAddress)).ToLower().Contains(SearchString)).ToList();

                houseLocation = model.ToList();

                //var model = data.Where(c => ((string.IsNullOrEmpty(c.WardNo) ? " " : c.WardNo) + " " +
                //                        (string.IsNullOrEmpty(c.zone) ? " " : c.zone) + " " +
                //                        (string.IsNullOrEmpty(c.Area) ? " " : c.Area) + " " +
                //                        (string.IsNullOrEmpty(c.Name) ? " " : c.Name) + " " +
                //                        (string.IsNullOrEmpty(c.houseNo) ? " " : c.houseNo) + " " +
                //                        (string.IsNullOrEmpty(c.Mobile) ? " " : c.Mobile) + " " +
                //                        (string.IsNullOrEmpty(c.Address) ? " " : c.Address) + " " +
                //                        (string.IsNullOrEmpty(c.ReferanceId) ? " " : c.ReferanceId) + " " +
                //                        (string.IsNullOrEmpty(c.QRCode) ? " " : c.QRCode)).ToUpper().Contains(SearchString.ToUpper())).ToList();

            }

            return houseLocation;
        }


        public string checkNull(string str)
        {
            string result = "";
            if (str == null || str == "")
            {
                result = "";
                return result;
            }
            else
            {
                result = str;
                return result;
            }
        }

    }
}
