using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebFrontEnd_Mvc.Models.Services;
using SI.Meditourism.BaseUrl;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SI.Meditourism.WebFrontEnd_Mvc.Models.Common;
namespace SI.Meditourism.WebFrontEnd_Mvc.Controllers
{
    public class HomeController : Controller
    {
        ApiUrl _objAPIURL = new ApiUrl();

        public ActionResult Index()
        {
            ViewBag.Message = null;
            if (Session["Username"] != null)
            {
                ViewData["Username"] = Session["Username"];
                ViewData["EmailId"] = Session["EmailId"];
                ViewData["Country"] = Session["Country"];
                ViewData["CustomerId"] = Session["CustomerId"];
            }

            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "AboutUs";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewData["Message"] = "ContactUs";
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Services()
        {
            List<Serviceslist> service = new List<Serviceslist>();
            using (var _httpclient = new HttpClient())
            {
                _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                _httpclient.DefaultRequestHeaders.Clear();
                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await _httpclient.GetAsync("FrontEndServicelist");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    service = JsonConvert.DeserializeObject<List<Serviceslist>>(Response);
                }
            }

            return View("Services", service);
        }

        //[HttpPost]
        //public ActionResult GetQuotation(ContactUs collection)
        //{
        //    try
        //    {
        //        if (collection.ServiceId != null && collection.EmailId != null && collection.Country != null)
        //        {
        //            DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
        //            Service _objServices = new Service();
        //            using (ContactUs_BAL objBAL = new ContactUs_BAL())
        //            {
        //                collection.ContactUsId = Guid.NewGuid();
        //                collection.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //                collection.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //                _objServices = objBAL.GetQuotation(collection);

        //            }
        //            if (_objServices != null)
        //            {
        //                HttpContext.Session.SetString("ServiceName", _objServices.Name);
        //                HttpContext.Session.SetString("ServicePrice", _objServices.Price);
        //                HttpContext.Session.SetString("VisaCharge", _objServices.VisaCharge);
        //                HttpContext.Session.SetString("Accommodation", _objServices.Accommodation);
        //                HttpContext.Session.SetString("TreatmentCharge", _objServices.TreatmentCharge);
        //                return RedirectToAction("services", "Home");
        //            }
        //            else
        //            {
        //                return RedirectToAction("services", "Home");
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("services", "Home");
        //        }
        //    }
        //    catch
        //    {
        //        return RedirectToAction("services", "Home");
        //    }
        //}
        public async Task<JsonResult> List(int Id)
        {
            GetServicedetail objReturn = new GetServicedetail();
            using (var _httpclient = new HttpClient())
            {
                _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                _httpclient.DefaultRequestHeaders.Clear();
                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await _httpclient.GetAsync("/FrontEndServicelist/" + Id);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    objReturn = JsonConvert.DeserializeObject<GetServicedetail>(Response);
                }
            }
           
            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(objReturn, jsonSerializerSettings);
            return Json(result);
        }
        
        // POST: Login/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(CustomerLogin collection)
        //{
        //    //ViewBag["Message"] = null;
        //    try
        //    {
        //        if (collection.Email != null && collection.Password != null)
        //        {
        //            Customer _objCustomer = new Customer();
        //            string HashPassword = Encryption256AES.EncryptionLibrary.EncryptText(collection.Password);
        //            collection.Password = HashPassword;

        //            using (Customer_BAL _objBAL = new Customer_BAL())
        //            {
        //                _objCustomer = _objBAL.ValidateUser(collection);
        //            }
        //            if (_objCustomer != null)
        //            {
        //                if (_objCustomer.CustomerId != null)
        //                {
        //                    Session["Username"] =  _objCustomer.Name.ToString();
        //                    Session["EmailId"] = _objCustomer.Email.ToString());
        //                    Session["Country"] =  _objCustomer.Country.ToString());
        //                    Session["CustomerId"] = _objCustomer.CustomerId.ToString());
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("", "The Username or password provided is incorrect.");
        //                    ViewBag.Message = "Incorrect Username or password.";
        //                    return View("Index", collection);
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "The Username or password provided is incorrect.");
        //                ViewBag.Message = "Incorrect Username or password.";
        //                return View("Index", collection);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag["Message"] = ex.Message;
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult Process()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SubmitContactUs(ContactUs collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpGet]
        public ActionResult ClearQuotSession()
        {
            HttpContext.Session.Remove("ServiceName");
            HttpContext.Session.Remove("ServicePrice");
            HttpContext.Session.Remove("VisaCharge");
            HttpContext.Session.Remove("Accommodation");
            HttpContext.Session.Remove("TreatmentCharge");
            return RedirectToAction("services", "Home");
        }
        //public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
