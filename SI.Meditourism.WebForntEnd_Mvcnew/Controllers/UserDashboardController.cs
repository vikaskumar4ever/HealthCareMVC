using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Services;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Common;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;
using System.IO;
using SI.Meditourism.PaymentServices.Model;
using SI.Meditourism.PaymentServices.BAL;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Customer;
using PayPal.Api;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
{
    public class UserDashboardController : Controller
    {
        ApiUrl _objAPIURL = new ApiUrl();
        // GET: UserDashboard
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
                {
                    TreatmentPagelst _treatmentPaymentDetails = new TreatmentPagelst();
                    string CustomerId = Session["CustomerId"].ToString();
                    Guid CustId = new Guid(CustomerId);
                    ViewBag.PaymentRequest = _objBAL.IsPaymentRequestExist(CustId);
                    if (ViewBag.PaymentRequest == true)
                    {
                        Session["PaymentId"] = null;
                        Session["PKId"] = null;
                        _treatmentPaymentDetails = _objBAL.GetRecorodById(CustId);
                        if (_treatmentPaymentDetails != null)
                        {
                            Session["PaymentId"] = _treatmentPaymentDetails.PaymentId;
                            Session["PKId"] = _treatmentPaymentDetails.Id;
                        }
                    }
                }
                return View();
            }
        }
        TreatmentPaymentDetails _TreatmentPaymentDetails = new TreatmentPaymentDetails();
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext
            string payerId = Request.Params["PayerID"];
            if (Session["Username"] != null || (payerId != null || payerId != ""))
            {
                if (Session["PaymentId"] != null)
                {
                    APIContext apiContext = PaypalConfiguration.GetAPIContext();
                    try
                    {
                        //A resource representing a Payer that funds a payment Payment Method as paypal
                        //Payer Id will be returned when payment proceeds or click to pay
                        //string payerId = Request.Params["PayerID"];

                        if (string.IsNullOrEmpty(payerId))
                        {
                            //this section will be executed first because PayerID doesn't exist
                            //it is returned by the create function call of the payment class

                            // Creating a payment
                            // baseURL is the url on which paypal sendsback the data.
                            string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                        "/UserDashboard/PaymentWithPayPal?";

                            //here we are generating guid for storing the paymentID received in session
                            //which will be used in the payment execution

                            var guid = Convert.ToString((new Random()).Next(100000));

                            //CreatePayment function gives us the payment approval url
                            //on which payer is redirected for paypal account payment

                            var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);

                            //get links returned from paypal in response to Create function call

                            var links = createdPayment.links.GetEnumerator();

                            string paypalRedirectUrl = null;

                            while (links.MoveNext())
                            {
                                Links lnk = links.Current;

                                if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                                {
                                    //saving the payapalredirect URL to which user will be redirected for payment
                                    paypalRedirectUrl = lnk.href;
                                }
                            }

                            // saving the paymentID in the key guid
                            Session.Add(guid, createdPayment.id);

                            return Redirect(paypalRedirectUrl);
                        }
                        else
                        {

                            // This function exectues after receving all parameters for the payment

                            var guid = Request.Params["guid"];

                            var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                            if (executedPayment.state.ToLower() != "approved")
                            {
                                return View("FailureView");
                            }
                            else
                            {
                                TreatmentPagelst _TreatmentPagelst = (TreatmentPagelst)Session["_TreatmentPagelst"];
                                _TreatmentPaymentDetails.CustomerId = _TreatmentPagelst.CustomerId;
                                _TreatmentPaymentDetails.Id = _TreatmentPagelst.Id;
                                _TreatmentPaymentDetails.ServiceId = _TreatmentPagelst.ServiceId;
                                _TreatmentPaymentDetails.CreationDate = _TreatmentPagelst.CreationDate;
                                _TreatmentPaymentDetails.PaymentId = _TreatmentPagelst.PaymentId;
                                _TreatmentPaymentDetails.Price = _TreatmentPagelst.Price;
                                _TreatmentPaymentDetails.PAYId = executedPayment.id;
                                 Session["PAYId"] = executedPayment.id;
                                _TreatmentPaymentDetails.Intent = executedPayment.intent;
                                _TreatmentPaymentDetails.State = executedPayment.state;
                                _TreatmentPaymentDetails.Paymentmethod = executedPayment.payer.payment_method;

                                _TreatmentPaymentDetails.Payer_firstname = executedPayment.payer.payer_info.first_name;
                                _TreatmentPaymentDetails.Payer_email = executedPayment.payer.payer_info.email;
                                _TreatmentPaymentDetails.Payer_payerId = executedPayment.payer.payer_info.payer_id;
                                _TreatmentPaymentDetails.UpdatedDate = executedPayment.update_time;
                                //if (executedPayment.transactions.Count > 0)
                                //{
                                //    _TreatmentPaymentDetails.Amount = ;
                                //    _TreatmentPaymentDetails.Currency = ;
                                //    _TreatmentPaymentDetails.Tax = ;
                                //    _TreatmentPaymentDetails.Description = ;
                                //}
                                //if (executedPayment.failed_transactions.Count > 0)
                                //{
                                //    _TreatmentPaymentDetails.failedErrorName = executedPayment.failed_transactions[0].name;
                                //    _TreatmentPaymentDetails.failedMessage = executedPayment.failed_transactions[0].message;
                                //    _TreatmentPaymentDetails.failedIssue = executedPayment.failed_transactions[0].details[0].issue;
                                //}
                                _TreatmentPaymentDetails.IsActive = true;
                                _TreatmentPaymentDetails.IsDeleted = false;
                                using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
                                {
                                    _objBAL.InsertUpdateRecord(_TreatmentPaymentDetails, executedPayment.transactions[0].amount.total, executedPayment.transactions[0].amount.currency,
                                        executedPayment.transactions[0].amount.details.tax, executedPayment.transactions[0].description);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Session["exception"] = ex.Message;
                        return View("FailureView");
                    }
                    //on successful payment, show success page to user.
                    return View("SuccessView");
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {

            //create itemlist and add item objects to it
            var itemList = new ItemList() { items = new List<Item>() };
            TreatmentPagelst _TreatmentPaymentDetails = new TreatmentPagelst();
            string CustomerId = Session["CustomerId"].ToString();
            Guid CustId = new Guid(CustomerId);
            using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
            {
                _TreatmentPaymentDetails = _objBAL.GetRecorodById(CustId);
                if (_TreatmentPaymentDetails.Id != 0)
                {
                    Session["_TreatmentPagelst"] = _TreatmentPaymentDetails;
                }
            }
            //Adding Item Details like name, currency, price etc
            itemList.items.Add(new Item()
            {
                name = "Treatment Amount : " + _TreatmentPaymentDetails.ServiceName,
                currency = "USD",
                price = _TreatmentPaymentDetails.Price,
                quantity = "1"
            });

            var payer = new Payer() { payment_method = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                //  cancel_url = redirectUrl + "&Cancel=true",
                cancel_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/UserDashboard/Index",
                return_url = redirectUrl
            };

            // Adding Tax, shipping and Subtotal details
            var details = new Details()
            {
                tax = _TreatmentPaymentDetails.Tax,
                subtotal = _TreatmentPaymentDetails.Price
            };

            //Final amount with details
            var amount = new Amount()
            {
                currency = "USD",
                total = _TreatmentPaymentDetails.Amount, // Total must be equal to sum of tax, shipping and subtotal.
                details = details
            };

            var transactionList = new List<Transaction>();
            // Adding description about the transaction
            Random rm = new Random();
            transactionList.Add(new Transaction()
            {
                description = _TreatmentPaymentDetails.Description,
                invoice_number = "INVTM/" + rm.Next(100000), //Generate an Invoice No
                amount = amount,
                item_list = itemList
            });


            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext
            return this.payment.Create(apiContext);
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
        public ActionResult SuccessView()
        {
            return View();
        }


        public ActionResult FailureView()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            if (Session["CustomerId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // POST: UserDashboard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitChangePassword(ChangePassword collection)
        {
            try
            {
                bool _return = false;
                string OldPassword = Models.Encryption256AES.EncryptionLibrary.EncryptText(collection.OldPassword);
                string NewPassword = Models.Encryption256AES.EncryptionLibrary.EncryptText(collection.NewPassword);
                using (var _httpclient = new HttpClient())
                {
                    _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                    _httpclient.DefaultRequestHeaders.Clear();
                    var content = new FormUrlEncodedContent(new[]
                     {
                          new KeyValuePair<string,string>("oldPassword",OldPassword),
                          new KeyValuePair<string,string>("NewPassword",NewPassword)
                     });
                    _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await _httpclient.PostAsync("ChangeCustomerPassword", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        _return = JsonConvert.DeserializeObject<bool>(Response);
                    }
                }
                ViewBag.Message = _return;

                return View("ChangePassword");
            }
            catch
            {
                return View("ChangePassword");
            }
        }

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
                return RedirectToAction("Index", "Home");

            }
            catch
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}