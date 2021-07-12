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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(CustomerLogin collection)
        //{
        //    //ViewBag["Message"] = null;
        //    try
        //    {
        //        if (collection != null)
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
        //                    HttpContext.Session.SetString("Username", _objCustomer.Name.ToString());
        //                    HttpContext.Session.SetString("EmailId", _objCustomer.Email.ToString());
        //                    HttpContext.Session.SetString("Country", _objCustomer.Country.ToString());
        //                    HttpContext.Session.SetString("CustomerId", _objCustomer.CustomerId.ToString());
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("", "The Username  or password provided is incorrect.");
        //                    return View("Index",collection);
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "The Username  or password provided is incorrect.");
        //                return View("Index",collection);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag["Message"] = ex.Message;
        //    }
        //    return View("Index", collection);
        //}

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
    }
}