using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SI.Meditourism.PaymentServices.BAL;
using SI.Meditourism.PaymentServices.Model;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
{
    public class PaymentHistoryController : Controller
    {
        // GET: PaymentHistory
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<TreatmentPagelst> treatmentPagelsts = new List<TreatmentPagelst>();
                Guid CustomerId = new Guid(Session["CustomerId"].ToString());
                using (TreatmentPaymentDetails_BAL _objbAL = new TreatmentPaymentDetails_BAL())
                {
                    treatmentPagelsts = _objbAL.GetTreatmentPaymentDetaillist(CustomerId);
                }
                return View(treatmentPagelsts);
            }

        }

        // GET: PaymentHistory/Details/5
        public ActionResult Details(Guid? id)
        {
            TreatmentPagelst _treatmentPagelst = new TreatmentPagelst();
            using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
            {
                _treatmentPagelst = _objBAL.GetTreatmentDetailsById(id);
            }
            return View(_treatmentPagelst);
        }

        // GET: PaymentHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentHistory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentHistory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentHistory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
