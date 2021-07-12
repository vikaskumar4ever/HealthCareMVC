using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.FAQ;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
{
    public class FAQController : Controller
    {
        ApiUrl _objAPIURL = new ApiUrl();
        // GET: FAQ
        public async Task<ActionResult> Index()
        {
            FAQlistFrntEnd _objFAQlistFrntEnd = new FAQlistFrntEnd();
            List<FAQList> _objfaqlist = new List<FAQList>();
            using (var _httpclient = new HttpClient())
            {
                _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                _httpclient.DefaultRequestHeaders.Clear();
                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await _httpclient.GetAsync("GetFAQListFrntEnd");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    _objFAQlistFrntEnd = JsonConvert.DeserializeObject<FAQlistFrntEnd>(Response);
                }
            }
            if (_objFAQlistFrntEnd != null)
            {
                if (_objFAQlistFrntEnd.GetFAQCategories != null)
                {
                    for (int i = 0; i < _objFAQlistFrntEnd.GetFAQCategories.Count; i++)
                    {
                        if (i == 0)
                        {
                            ViewBag.Heading1 = _objFAQlistFrntEnd.GetFAQCategories[0].FaqCategoryName;
                        }
                        else if (i == 1)
                        {
                            ViewBag.Heading2 = _objFAQlistFrntEnd.GetFAQCategories[1].FaqCategoryName;
                        }
                        else if ( i == 2)
                        {
                            ViewBag.Heading3 = _objFAQlistFrntEnd.GetFAQCategories[2].FaqCategoryName;
                        }
                        else if (i == 3)
                        {
                            ViewBag.Heading4 = _objFAQlistFrntEnd.GetFAQCategories[3].FaqCategoryName;
                        }
                        else if (i == 4)
                        {
                            ViewBag.Heading5 = _objFAQlistFrntEnd.GetFAQCategories[4].FaqCategoryName;
                        }
                    }

                }
            }
            return View(_objFAQlistFrntEnd);
        }

        // GET: FAQ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAQ/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
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

        // GET: FAQ/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FAQ/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: FAQ/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FAQ/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}