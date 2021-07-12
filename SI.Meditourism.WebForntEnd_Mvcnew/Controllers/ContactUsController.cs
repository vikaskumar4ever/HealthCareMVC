using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Services;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.ContactUs;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
{
    public class ContactUsController : Controller
    {
        ApiUrl _objAPIURL = new ApiUrl();
        // GET: ContactUs
        public ActionResult ContactUs()
        {
            return View();
        }

        // GET: ContactUs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitContactUs(ContactUs collection)
        {
            try
            {
                var contactus = new ContactUs();
                Guid? ContactUsId = null;
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
                             new KeyValuePair<string,string>("AltMobile",collection.AltMobile),
                     });
                    _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await _httpclient.PostAsync("SubmitContactUs", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        ContactUsId = JsonConvert.DeserializeObject<Guid>(Response);
                    }
                }
                if (ContactUsId != null)
                {
                    ViewBag.Message = "Thank You For Contacting Us. We will contact to you soon.";
                    return View("ContactUs", contactus);
                }
                else
                {
                    return View("ContactUs");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("ContactUs");
            }
        }

        // GET: ContactUs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactUs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(ContactUs));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ContactUs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactUs/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(ContactUs));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}