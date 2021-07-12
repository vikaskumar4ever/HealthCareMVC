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
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CustomerReg(Customer collection)
        //{
        //    try
        //    {
        //        DateTimeFormatToIST _objdateTimeFormatToIST = new DateTimeFormatToIST();
        //        if (collection != null)
        //        {
        //            collection.CustomerId = Guid.NewGuid();
        //            collection.IsDeleted = false;
        //            collection.IsActive = false;
        //            string hashPassword = Encryption256AES.EncryptionLibrary.EncryptText(collection.Password);
        //            collection.Password = hashPassword;
        //            collection.CreationDate = _objdateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //            collection.UpdatedDate = _objdateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //            using (Customer_BAL _objBAL = new Customer_BAL())
        //            {
        //                _objBAL.InsertUpdateRecord(collection);
        //            }
        //        }
              
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index","Home");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
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

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
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