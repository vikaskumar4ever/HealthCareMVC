using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Master.Model;
using SI.Meditourism.Master.BAL;
using SI.Meditourism.Common;
using SI.Meditourism.Services.Model;

namespace SI.Meditourism.WebFrontEnd.Controllers
{
    public class ContactUsController : Controller
    {
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
        public ActionResult SubmitContactUs(ContactUs collection)
        {
            try
            {
               
                    DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
                    Guid ContactUsId ;
                    using (ContactUs_BAL objBAL = new ContactUs_BAL())
                    {
                        collection.ContactUsId = Guid.NewGuid();
                        collection.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                        collection.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                        ContactUsId = objBAL.InsertUpdateRecord(collection);

                    }
                    if (ContactUsId != null)
                    {
                        ViewBag.Message = "Thank You For Contacting Us. We will contact to you soon.";
                        return View("ContactUs");
                    }
                    else
                    {
                        return View("ContactUs");
                    }
               
            }
            catch(Exception ex)
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(ContactUs));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactUs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactUs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(ContactUs));
            }
            catch
            {
                return View();
            }
        }
    }
}