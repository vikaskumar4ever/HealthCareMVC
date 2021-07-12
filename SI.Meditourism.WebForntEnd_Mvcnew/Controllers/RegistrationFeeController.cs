using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SI.Meditourism.PaymentServices.BAL;
using SI.Meditourism.PaymentServices.Model;
using SI.Meditourism.FrntMailer.BAL;
using SI.Meditourism.FrntMailer;
using SI.Meditourism.FrntMailer.Model;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Customer;
using System.Text;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Encryption256AES;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
{
    public class RegistrationFeeController : Controller
    {
        // GET: RegistrationFee
        public ActionResult Index()
        {
            string customerId = Request.Params["customerId"];
            Session["ParamCustomerId"] = customerId;
            return View();
        }

        // GET: RegistrationFee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationFee/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult FailureView()
        {
            return View();
        }
        public ActionResult SuccessView()
        {
            try
            {
                using (RegistrationFeePaymentDetails_BAL _objBAL = new RegistrationFeePaymentDetails_BAL())
                {
                    if (Session["PAYIdCustomerId"] != null)
                    {
                        Guid? CustomerId = new Guid(Session["PAYIdCustomerId"].ToString());
                        PaymentServices.Model.Customer _objcustomer = new PaymentServices.Model.Customer();
                        _objcustomer = _objBAL.GetCustomerDetails(CustomerId);
                        EmailTemplate objEmailTemplate = new EmailTemplate();
                        using (EmailTemplate_BAL objBAL = new EmailTemplate_BAL())
                        {
                            Guid TemplateId = new Guid("8ACC1EFD-BC7B-4035-A150-A4763C01F583");
                            // objEmailTemplate = objBAL.GetRecorodById(TemplateId);
                            var EmailContent = new StringBuilder();
                            objEmailTemplate.TemplateContent = "<table border='0'cellspacing='0'cellpadding='0'style='max-width:600px'><tbody><tr><td><table width='100%'border='0'cellspacing='0'cellpadding='0'><tbody><tr><td align='left'><img src='http://www.meditourism.morepower.com/assets/FrontEndScript/img/logo.png' style='display:block;width:250px;height:51px;margin-top:24px'></td></tr></tbody></table></td></tr><tr height='16'></tr><tr><td><table width='100%'border='0'cellspacing='0'cellpadding='0'style='background-color:#4b8aa9;min-width:332px;max-width:600px;border:1px solid #e0e0e0;border-bottom:0;border-top-left-radius:3px;border-top-right-radius:3px'><tbody><tr><td height='30px'colspan='3'></td></tr><tr><td width='32px'></td><td style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:24px;color:#ffffff;line-height:1.25'>ThankYou For Join With Us</td><td width='32px'></td></tr><tr><td height='18px'colspan='3'></td></tr></tbody></table></td></tr><tr><td><table bgcolor='#FAFAFA'width='100%'border='0'cellspacing='0'cellpadding='0'style='min-width:332px;max-width:600px;border:1px solid #f0f0f0;border-bottom:1px solid #c0c0c0;border-top:0;border-bottom-left-radius:3px;border-bottom-right-radius:3px'><tbody><tr height='16px'><td width='32px' rowspan='3'></td><td></td><td width='32px'rowspan='3'></td></tr><tr><td><span class='im'><p>Dear, <span style='color:#659cef'dir='ltr'><a style='color:#659cef'target='_blank'> $username$</a></span></p></span><div style='text-align:center'><p dir='ltr'>Your Username is $emailId$ and Password is $password$ for My Samaritanz MediTourism. You are advised to login at <a href='http://meditourism.morepower.com'traget='_blank'>www.meditourism.morepower.com</a>.</p></div><span class='im'><p>Sincerely,<br>The My Samaritanz MediTourism Accounts Team</p><p></p><p></p></span></td></tr><tr height='32px'></tr></tbody></table></td></tr><tr height='16'></tr><tr><td style='max-width:600px;font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:10px;color:#bcbcbc;line-height:1.5'></td></tr><tr><td><table style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:10px;color:#666666;line-height:18px;padding-bottom:10px'><tbody><tr><td>This email can't receive replies. For more information, visit the <a style='text-decoration:none;color:#4d90fe'target='_blank' href='http://meditourism.morepower.com/ContactUs/ContactUs'>My Samaritanz MediTourism Help Center</a>.<br></td></tr></tbody></table></td></tr></tbody></table>";
                            GMailer mailer = new GMailer();
                            mailer.ToEmail = _objcustomer.Email;
                            mailer.Subject = "Thank you For Connecting With Us";
                            string Bodyobj = objEmailTemplate.TemplateContent.Replace("$username$", _objcustomer.Name);
                            Bodyobj = Bodyobj.Replace("$password$", EncryptionLibrary.DecryptText(_objcustomer.Password));
                            Bodyobj = Bodyobj.Replace("$emailId$", " " + _objcustomer.Email);
                            mailer.Body = Bodyobj;
                            mailer.IsHtml = true;
                            string strMsg = mailer.Send();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Session["PaymentMessage"] = "Error: " + ex.ToString() + "Erro2:" + ex.Message + " Message:" + ex.StackTrace + "<br/> ";
                return RedirectToAction("Default");
            }

            return View();
        }
      
        public ActionResult Default()
        {

            return View();
        }
        RegistrationFeePaymentDetails _registrationFeePaymentDetails = new RegistrationFeePaymentDetails();
        
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            string customerId = null;
            if (Session["ParamCustomerId"] != null)
            {
                customerId = Session["ParamCustomerId"].ToString();
            }
            else
            {
                customerId = Request.Params["customerId"].ToString();
            }

            bool IsCustomerExists = false;
            bool IsPaymentAlreadyComplete = false;
            if (string.IsNullOrEmpty(Request.Params["customerId"]))
            {
                using (RegistrationFeePaymentDetails_BAL _objBAL = new RegistrationFeePaymentDetails_BAL())
                {
                    Guid? CustomerId = new Guid(customerId);
                    IsCustomerExists = _objBAL.ChkCustomerIdExistOrNot(CustomerId);
                    if (IsCustomerExists == true)
                    {
                        IsPaymentAlreadyComplete = _objBAL.ChkCustomerIdExistInRegistationPayment(CustomerId);
                    }
                    else
                    {
                        Session["PaymentMessage"] = "Invalid PaymentLink, Please Try Again Later";
                    }
                }
            }
            if (IsPaymentAlreadyComplete == false)
            {
                if (IsCustomerExists == true || Request.Params["customerId"] != null)
                {

                    try
                    {
                        //A resource representing a Payer that funds a payment Payment Method as paypal
                        //Payer Id will be returned when payment proceeds or click to pay
                        string payerId = Request.Params["PayerID"];

                        if (string.IsNullOrEmpty(payerId))
                        {
                            //this section will be executed first because PayerID doesn't exist
                            //it is returned by the create function call of the payment class

                            // Creating a payment
                            // baseURL is the url on which paypal sendsback the data.
                            string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                        "/RegistrationFee/PaymentWithPayPal?";

                            //here we are generating guid for storing the paymentID received in session
                            //which will be used in the payment execution

                            var guid = Convert.ToString((new Random()).Next(100000));

                            //CreatePayment function gives us the payment approval url
                            //on which payer is redirected for paypal account payment

                            var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid + "&customerId=" + customerId, customerId);

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

                            //If executed payment failed then we will show payment failure message to user
                            if (executedPayment.state.ToLower() != "approved")
                            {
                                return View("FailureView");
                            }
                            else
                            {
                                try
                                {

                                    _registrationFeePaymentDetails.PaymentId = Guid.NewGuid();
                                    _registrationFeePaymentDetails.CustomerId = new Guid(Request.Params["customerid"].ToString());
                                    Session["PAYIdCustomerId"] = _registrationFeePaymentDetails.CustomerId;
                                    _registrationFeePaymentDetails.PAYId = executedPayment.id;
                                    Session["PAYId"] = executedPayment.id;
                                    _registrationFeePaymentDetails.Intent = executedPayment.intent;
                                    _registrationFeePaymentDetails.State = executedPayment.state;
                                    _registrationFeePaymentDetails.Paymentmethod = executedPayment.payer.payment_method;

                                    _registrationFeePaymentDetails.Payer_firstname = executedPayment.payer.payer_info.first_name;
                                    _registrationFeePaymentDetails.Payer_email = executedPayment.payer.payer_info.email;
                                    _registrationFeePaymentDetails.Payer_payerId = executedPayment.payer.payer_info.payer_id;
                                    _registrationFeePaymentDetails.CreationDate = executedPayment.create_time;
                                    _registrationFeePaymentDetails.UpdatedDate = executedPayment.update_time;
                                    //if (executedPayment.transactions.Count > 0)
                                    //{
                                    //    Amount = executedPayment.transactions[0].amount.total;
                                    //    Currency = executedPayment.transactions[0].amount.currency;
                                    //    Tax = executedPayment.transactions[0].amount.details.tax;
                                    //    Description = executedPayment.transactions[0].description.ToString();
                                    //}
                                    //if (executedPayment.failed_transactions.Count > 0)
                                    //{
                                    //    _registrationFeePaymentDetails.failedName = executedPayment.failed_transactions[0].name.ToString();
                                    //    _registrationFeePaymentDetails.failedMessage = executedPayment.failed_transactions[0].message.ToString();
                                    //    _registrationFeePaymentDetails.failedIssue = executedPayment.failed_transactions[0].details[0].issue.ToString();
                                    //}
                                    _registrationFeePaymentDetails.IsActive = true;
                                    _registrationFeePaymentDetails.IsDeleted = false;
                                    using (RegistrationFeePaymentDetails_BAL _objBAL = new RegistrationFeePaymentDetails_BAL())
                                    {
                                        _objBAL.InsertUpdateRecord(_registrationFeePaymentDetails, executedPayment.transactions[0].amount.total, executedPayment.transactions[0].amount.currency, executedPayment.transactions[0].amount.details.tax, executedPayment.transactions[0].description);
                                    }
                                }
                                catch (Exception ex)
                                {

                                    Session["PaymentMessage"] = executedPayment.transactions[0].description.ToString() + "Error: " + ex.ToString() + "Erro2:" + ex.Message + " Message:" + ex.StackTrace + "<br/> " + executedPayment;
                                    return View("Default");
                                }
                                //on successful payment, show success page to user.
                                return RedirectToAction("SuccessView");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Session["exception"] = ex.ToString();
                        //return View("FailureView");
                        return RedirectToAction("FailureView", "RegistrationFee");
                    }
                }
                else
                {
                    Session["PaymentMessage"] = "Invalid PaymentLink, Please Try Again Later";
                    return View("Default");
                }
            }
            else
            {
                Session["PaymentMessage"] = "Your Registration Payment is Already Done.";
                return View("Default");
            }
        }

        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string customerId)
        {

            //create itemlist and add item objects to it
            var itemList = new ItemList() { items = new List<Item>() };
            RegistrationFee _RegistrationFee = new RegistrationFee();
            using (RegistrationFeePaymentDetails_BAL _objBAL = new RegistrationFeePaymentDetails_BAL())
            {
                _RegistrationFee = _objBAL.RegistrationFeeDetails();
            }
            //Adding Item Details like name, currency, price etc
            itemList.items.Add(new Item()
            {
                name = _RegistrationFee.Name,
                currency = "USD",
                price = Convert.ToString(_RegistrationFee.Fee),
                quantity = "1"
            });

            var payer = new Payer() { payment_method = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/RegistrationFee/PaymentWithPayPal?" + "customerId=" + customerId,
                return_url = redirectUrl
            };

            // Adding Tax, shipping and Subtotal details
            var details = new Details()
            {
                tax = "0",
                subtotal = Convert.ToString(_RegistrationFee.Fee)
            };

            //Final amount with details
            var amount = new Amount()
            {
                currency = "USD",
                total = Convert.ToString(_RegistrationFee.Fee), // Total must be equal to sum of tax, shipping and subtotal.
                details = details
            };

            var transactionList = new List<Transaction>();
            Random rm = new Random();
            // Adding description about the transaction
            transactionList.Add(new Transaction()
            {
                description = Convert.ToString(_RegistrationFee.Decription),
                invoice_number = "INVRG" + rm.Next(1000), //Generate an Invoice No
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


        // GET: RegistrationFee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationFee/Edit/5
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

        // GET: RegistrationFee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationFee/Delete/5
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
