using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Services;
using SI.Meditourism.BaseUrl;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Common;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.ContactUs;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Customer;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Encryption256AES;
using SI.Meditourism.FrntMailer.Model;
using SI.Meditourism.FrntMailer.BAL;
using SI.Meditourism.FrntMailer;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.HospitalsDetails;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
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

        [HttpPost]
        public async Task<ActionResult> GetQuotation(ContactUs collection)
        {
            try
            {
                // TODO: Add insert logic here

                DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
                Service _objServices = new Service();
                using (var _httpclient = new HttpClient())
                {
                    _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                    _httpclient.DefaultRequestHeaders.Clear();
                    var content = new FormUrlEncodedContent(new[]
                     {
                          new KeyValuePair<string,string>("Name",collection.Name),
                          new KeyValuePair<string,string>("MobileNo",collection.MobileNo),
                           new KeyValuePair<string,string>("EmailId",collection.EmailId),
                            new KeyValuePair<string,string>("Message",collection.Message),
                             new KeyValuePair<string,string>("Country",collection.Country),
                              new KeyValuePair<string,string>("ServiceId",collection.ServiceId.ToString()),
                     });
                    _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await _httpclient.PostAsync("GetQuotation", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        _objServices = JsonConvert.DeserializeObject<Service>(Response);
                    }
                }
                if (_objServices != null)
                {
                    Session["ServiceName"] = _objServices.Name;
                    Session["ServicePrice"] = _objServices.Price;
                    Session["VisaCharge"] = _objServices.VisaCharge;
                    Session["Accommodation"] = _objServices.Accommodation;
                    Session["TreatmentCharge"] = _objServices.TreatmentCharge;
                    return RedirectToAction("services");
                }
                else
                {
                    return RedirectToAction("services", "Home");
                }
                //  return View("services", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public JsonResult List(int Id)
        {
            Task<GetServicedetail> objReturn = GetTreatmentDetails(Id);
            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(objReturn, jsonSerializerSettings);

            return Json(result);
        }

        public async Task<GetServicedetail> GetTreatmentDetails(int Id)
        {
            GetServicedetail objReturn = new GetServicedetail();
            using (var _httpclient = new HttpClient())
            {
                _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                _httpclient.DefaultRequestHeaders.Clear();
                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await _httpclient.GetAsync("GetTreatMentDetails/" + Id);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    objReturn = JsonConvert.DeserializeObject<GetServicedetail>(Response);

                }
            }
            return objReturn;
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> Login(CustomerLogin collection)
        {
            //ViewBag["Message"] = null;
            try
            {
                if (collection.Email != null && collection.Password != null)
                {
                    Customer _objCustomer = new Customer();
                    string HashPassword = Models.Encryption256AES.EncryptionLibrary.EncryptText(collection.Password);
                    collection.Password = HashPassword;
                    using (var _httpclient = new HttpClient())
                    {
                        _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                        _httpclient.DefaultRequestHeaders.Clear();
                        var content = new FormUrlEncodedContent(new[]
                         {
                          new KeyValuePair<string,string>("Username",collection.Email),
                          new KeyValuePair<string,string>("Password",collection.Password)

                     });
                        _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage Res = await _httpclient.PostAsync("CustomerLogin", content);
                        if (Res.IsSuccessStatusCode)
                        {
                            var Response = Res.Content.ReadAsStringAsync().Result;
                            _objCustomer = JsonConvert.DeserializeObject<Customer>(Response);
                        }
                    }
                    if (_objCustomer != null)
                    {
                        if (_objCustomer.CustomerId != null)
                        {
                            Session["Username"] = _objCustomer.Name.ToString();
                            Session["EmailId"] = _objCustomer.Email.ToString();
                            Session["Country"] = _objCustomer.Country.ToString();
                            Session["CustomerId"] = _objCustomer.CustomerId.ToString();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signup(Customer collection)
        {
            try
            {
                DateTimeFormatToIST _objdateTimeFormatToIST = new DateTimeFormatToIST();
                if (collection != null)
                {
                    bool IsEmailIdExists = false;

                    if (collection.Email != null)
                    {
                        using (var _httpclient = new HttpClient())
                        {
                            _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                            _httpclient.DefaultRequestHeaders.Clear();
                            _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            HttpResponseMessage Res = await _httpclient.GetAsync("RegistationCustomer/" + collection.Email);
                            if (Res.IsSuccessStatusCode)
                            {
                                var Response = Res.Content.ReadAsStringAsync().Result;
                                IsEmailIdExists = JsonConvert.DeserializeObject<bool>(Response);
                            }
                        }
                        if (IsEmailIdExists == true)
                        {
                            ViewData["IsEmailIdExists"] = collection.Email + " Emaild is already exists";
                            return View("Index", collection);
                        }
                    }
                    if (IsEmailIdExists == false)
                    {
                        using (var _httpclient = new HttpClient())
                        {
                            _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                            _httpclient.DefaultRequestHeaders.Clear();
                            string CustomerId = Guid.NewGuid().ToString();
                            var content = new FormUrlEncodedContent(new[]
                             {
                          new KeyValuePair<string,string>("Name",collection.Name),
                            new KeyValuePair<string,string>("PhoneNo",collection.PhoneNo),
                            new KeyValuePair<string,string>("EmailId",collection.Email),
                             new KeyValuePair<string,string>("Country",collection.Country),
                              new KeyValuePair<string,string>("CustomerId",CustomerId)
                     });
                            _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            HttpResponseMessage Res = await _httpclient.PostAsync("RegistationCustomer", content);
                            if (Res.IsSuccessStatusCode)
                            {
                                var Response = Res.Content.ReadAsStringAsync().Result;
                                //  return RedirectToAction("Index", "RegistrationFee&customerId=" + CustomerId);
                              
                                try
                                {
                                    EmailTemplate objEmailTemplate = new EmailTemplate();
                                    using (EmailTemplate_BAL objBAL = new EmailTemplate_BAL())
                                    {
                                        Guid TemplateId = new Guid("834A932B-3F14-458D-8C6D-5437CADB3F4D");
                                        objEmailTemplate = objBAL.GetRecorodById(TemplateId);
                                        GMailer mailer = new GMailer();
                                        mailer.ToEmail = collection.Email;
                                        mailer.Subject = objEmailTemplate.Title;
                                        string Bodyobj = objEmailTemplate.TemplateContent.Replace("$username$", collection.Name);
                                        Bodyobj = Bodyobj.Replace("$emailId$", " " + collection.Email + " ");
                                        mailer.Body = Bodyobj;
                                        mailer.IsHtml = true;
                                        string strMsg = mailer.Send();
                                    }
                                    using (EmailTemplate_BAL objBAL = new EmailTemplate_BAL())
                                    {
                                        Guid TemplateId = new Guid("E197E82E-F8B7-4248-BBB5-CCED28E41FDD");
                                        objEmailTemplate = objBAL.GetRecorodById(TemplateId);
                                        GMailer mailer = new GMailer();
                                        mailer.ToEmail = collection.Email;
                                        mailer.Subject = objEmailTemplate.Title;
                                        string Bodyobj = objEmailTemplate.TemplateContent.Replace("$username$", collection.Name);
                                        Bodyobj = Bodyobj.Replace("$paymentlink$", "http://www.mysamaritanz.com/RegistrationFee?customerId=" + CustomerId);
                                        Bodyobj = Bodyobj.Replace("$emailId$", " " + collection.Email + " ");
                                        mailer.Body = Bodyobj;
                                        mailer.IsHtml = true;
                                        string strMsg = mailer.Send();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ViewBag.errormessage = ex.Message;
                                }

                                return RedirectToAction("Index", "RegistrationFee", new { customerId = CustomerId });
                            }
                        }
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Process()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetUserTreatmentlist(string terms)
        {
            Serviceslist objReturn = new Serviceslist();
            try
            {
                if (terms != null && terms != "")
                {
                    using (var _httpclient = new HttpClient())
                    {
                        _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                        _httpclient.DefaultRequestHeaders.Clear();
                        _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage Res = await _httpclient.GetAsync("AutoCompleteTreatmentlist/" + terms);
                        if (Res.IsSuccessStatusCode)
                        {
                            var Response = Res.Content.ReadAsStringAsync().Result;
                            objReturn = JsonConvert.DeserializeObject<Serviceslist>(Response);
                        }
                        return Json(objReturn);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objReturn);
        }

        [HttpGet]
        public async Task<ActionResult> Hospitals()
        {
            List<HospitalDetails> HospitalDetails = new List<HospitalDetails>();
            using (var _httpclient = new HttpClient())
            {
                _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                _httpclient.DefaultRequestHeaders.Clear();
                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await _httpclient.GetAsync("GetHospitalDetailsFrntEnd");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    HospitalDetails = JsonConvert.DeserializeObject<List<HospitalDetails>>(Response);
                }
            }

            return View("Hospitals", HospitalDetails);
        }

        [HttpGet]
        public ActionResult ClearQuotSession()
        {
            Session["ServiceName"] = null;
            Session["ServicePrice"] = null;
            Session["VisaCharge"] = null;
            Session["Accommodation"] = null;
            Session["TreatmentCharge"] = null;
            return RedirectToAction("services", "Home");
        }
        //public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
