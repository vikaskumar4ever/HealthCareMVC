using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebFrontEnd_Mvc.Models.Services;
using SI.Meditourism.WebFrontEnd_Mvc.Models.Common;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;
using System.IO;

namespace SI.Meditourism.WebFrontEnd_Mvc.Controllers
{
    public class UserDashboardController : Controller
    {
        // GET: UserDashboard
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult MessagingPanel()
        {
            return View();
        }

        // GET: UserDashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserDashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        // POST: UserDashboard/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SubmitChangePassword(ChangePassword collection)
        //{
        //    try
        //    {
        //        bool _return = false;
        //        // TODO: Add insert logic here
        //        using (Customer_BAL _objBAL = new Customer_BAL())
        //        {
                    
        //            string OldPassword = Encryption256AES.EncryptionLibrary.EncryptText(collection.OldPassword);
        //            string NewPassword = Encryption256AES.EncryptionLibrary.EncryptText(collection.NewPassword);
        //            _return = _objBAL.ChangePassword(OldPassword, NewPassword);
        //        }
              
        //            ViewBag.Message = _return;
                
        //        return View("ChangePassword");
        //    }
        //    catch
        //    {
        //        return View("ChangePassword");
        //    }
        //}

        // GET: UserDashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserDashboard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserDashboard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            try
            {
                // TODO: Add delete logic here
                HttpContext.Session.Clear();
                return RedirectToAction("Index","Home");
               
            }
            catch
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}