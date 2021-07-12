using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.WebFrontEnd.Models;
using SI.Meditourism.Master.Model;
using SI.Meditourism.Services.Model;
using SI.Meditourism.Services.BAL;
using SI.Meditourism.Encryption256AES;
using SI.Meditourism.Common;
using SI.Meditourism.CustomerInfo.Model;
using SI.Meditourism.CustomerInfo.BAL;
using SI.Meditourism.Master.BAL;
using SI.Meditourism.FAQInfo.Model;
using SI.Meditourism.FAQInfo.BAL;

namespace SI.Meditourism.WebFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = null;
            if (HttpContext.Session.GetString("Username") != null)
            {
                ViewData["Username"] = HttpContext.Session.GetString("Username");
                ViewData["EmailId"] = HttpContext.Session.GetString("EmailId");
                ViewData["Country"] = HttpContext.Session.GetString("Country");
                ViewData["CustomerId"] = HttpContext.Session.GetString("CustomerId");
            }
           
            return View();         
        }                          
                                   
        public IActionResult About()
        {
            ViewData["Message"] = "AboutUs";

            return View();
        }

        public IActionResult ContactUs()
        {
            ViewData["Message"] = "ContactUs";
            return View();
        }
        public IActionResult FAQ()
        {
            FAQlistFrntEnd _objFAQlistFrntEnd = new FAQlistFrntEnd();
            using (FAQ_BAL _objBAL = new FAQ_BAL())
            {
                _objFAQlistFrntEnd = _objBAL.GetFAQListFrntEnd();
            }
            return View(_objFAQlistFrntEnd);

        }

        [HttpGet]
        public ActionResult Services()
        {
            List<Serviceslist> service = new List<Serviceslist>();
            using (Service_BAL objBAL = new Service_BAL())
            {
                service = objBAL.GetServicelists();
            }
            return View("Services", service);
        }

        [HttpPost]
        public ActionResult GetQuotation(ContactUs collection)
        {
            try
            {
                if (collection.ServiceId != null && collection.EmailId != null && collection.Country != null)
                {
                    DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
                    Service _objServices = new Service();
                    using (ContactUs_BAL objBAL = new ContactUs_BAL())
                    {
                        collection.ContactUsId = Guid.NewGuid();
                        collection.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                        collection.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                        _objServices = objBAL.GetQuotation(collection);

                    }
                    if (_objServices != null)
                    {
                        HttpContext.Session.SetString("ServiceName", _objServices.Name);
                        HttpContext.Session.SetString("ServicePrice", _objServices.Price);
                        HttpContext.Session.SetString("VisaCharge", _objServices.VisaCharge);
                        HttpContext.Session.SetString("Accommodation", _objServices.Accommodation);
                        HttpContext.Session.SetString("TreatmentCharge", _objServices.TreatmentCharge);
                        return RedirectToAction("services", "Home");
                    }
                    else
                    {
                        return RedirectToAction("services", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("services", "Home");
                }
            }
            catch
            {
                return RedirectToAction("services", "Home");
            }
        }
        public JsonResult List(int Id)
        {
            GetServicedetail objReturn = new GetServicedetail();
            using (Service_BAL objBAL = new Service_BAL())
            {
                objReturn = objBAL.GetTreatMentDetails(Id);
            }
            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(objReturn, jsonSerializerSettings);
            return Json(result);
        }
        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLogin collection)
        {
            //ViewBag["Message"] = null;
            try
            {
                if (collection.Email != null && collection.Password != null)
                {
                    Customer _objCustomer = new Customer();
                    string HashPassword = Encryption256AES.EncryptionLibrary.EncryptText(collection.Password);
                    collection.Password = HashPassword;

                    using (Customer_BAL _objBAL = new Customer_BAL())
                    {
                        _objCustomer = _objBAL.ValidateUser(collection);
                    }
                    if (_objCustomer != null)
                    {
                        if (_objCustomer.CustomerId != null)
                        {
                            HttpContext.Session.SetString("Username", _objCustomer.Name.ToString());
                            HttpContext.Session.SetString("EmailId", _objCustomer.Email.ToString());
                            HttpContext.Session.SetString("Country", _objCustomer.Country.ToString());
                            HttpContext.Session.SetString("CustomerId", _objCustomer.CustomerId.ToString());
                        }
                        else
                        {
                            ModelState.AddModelError("", "The Username or password provided is incorrect.");
                            ViewBag.Message = "Incorrect Username or password.";
                            return View("Index", collection);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Username or password provided is incorrect.");
                        ViewBag.Message = "Incorrect Username or password.";
                        return View("Index", collection);
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag["Message"] = ex.Message;
            }
            return RedirectToAction("Index"); 
        }

        public IActionResult Process()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitContactUs(ContactUs collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
