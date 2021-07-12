using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebFrontEnd_Mvc.Models.Services;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;

namespace SI.Meditourism.WebFrontEnd_Mvc.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        //public ActionResult Index()
        //{
        //    FAQlistFrntEnd _objFAQlistFrntEnd = new FAQlistFrntEnd();
        //    List<FAQList> _objfaqlist = new List<FAQList>();
        //    using (FAQ_BAL _objBAL = new FAQ_BAL())
        //    {
        //        _objFAQlistFrntEnd = _objBAL.GetFAQListFrntEnd();
        //        if (_objFAQlistFrntEnd.GetFAQCategories != null)
        //        {
        //            ViewBag.Heading1 = _objFAQlistFrntEnd.GetFAQCategories[0].FaqCategoryName;
        //            ViewBag.Heading2 = _objFAQlistFrntEnd.GetFAQCategories[1].FaqCategoryName;
        //            ViewBag.Heading3 = _objFAQlistFrntEnd.GetFAQCategories[2].FaqCategoryName;
        //            ViewBag.Heading4 = _objFAQlistFrntEnd.GetFAQCategories[3].FaqCategoryName;
        //            ViewBag.Heading5 = _objFAQlistFrntEnd.GetFAQCategories[4].FaqCategoryName;
        //        }
        //    }
        //    return View(_objFAQlistFrntEnd);
        //}

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