using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Services;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;
using System.IO;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.Common;
using SI.Meditourism.WebForntEnd_Mvcnew.Models.ChatingServices;
//using SI.Meditourism.UploadDocument.Model;
//using SI.Meditourism.UploadDocument.BAL;
//using SI.Meditourism.UploadDocument.Interface;
using System.Web;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Controllers
{
    public class MessagingPanelController : Controller
    {
        ApiUrl _objAPIURL = new ApiUrl();
        // GET: MessagingPanel
        public ActionResult Messaging()
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


        // GET: MessagingPanel/Details/5
        //public JsonResult Details(int id)
        //{
        //    if (HttpContext.Session.GetString("CustomerId") != null)
        //    {
        //        using (AdminCustomerChat_BAL _objBAL = new AdminCustomerChat_BAL())
        //        {
        //            List<GetChatMessagelist> _objAdminCustomerChat = new List<GetChatMessagelist>();
        //            Guid CustomerId = new Guid(HttpContext.Session.GetString("CustomerId"));
        //            _objAdminCustomerChat = _objBAL.GetAllRecorod(CustomerId);
        //            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
        //            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        //            var result = Newtonsoft.Json.JsonConvert.SerializeObject(_objAdminCustomerChat, jsonSerializerSettings);
        //            return Json(result);
        //        }
        //    }
        //    else
        //    {
        //        return Json("");
        //    }
        //}

        // GET: MessagingPanel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessagingPanel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendMsg(AdminCustomerChat collection)
        {
            try
            {
                if (Session["CustomerId"] != null)
                {
                    // TODO: Add insert logic here
                    if (collection != null)
                    {
                        if (collection.Message != null)
                        {
                            DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
                            using (var _httpclient = new HttpClient())
                            {
                                _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                                _httpclient.DefaultRequestHeaders.Clear();
                                var content = new FormUrlEncodedContent(new[]
                                {
                                     new KeyValuePair<string,string>("Message",collection.Message),
                                     new KeyValuePair<string,string>("CustomerId",Session["CustomerId"].ToString())
                              });
                                _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                                HttpResponseMessage Res = await _httpclient.PostAsync("SendCustomerMessages", content);
                            }
                        }
                    }
                    return View("Messaging");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Messaging));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadDoc(HttpPostedFileBase files)
        {
            try
            {
                ViewData["FileExtensionMessage"] = null;
                if (Session["CustomerId"] != null)
                {
                    if (files != null)
                    {
                        var SupportedTypes = new[] { "jpg", "doc", "pdf", "png", "docx" };

                        if (files.ContentLength < 11010048)
                        {
                            var fileExt = System.IO.Path.GetExtension(files.FileName).Substring(1);
                            if (!SupportedTypes.Contains(fileExt))
                            {
                                ViewData["FileExtensionMessage"] = "File Extension Is Invalid - Only Upload .JPG, .PNG, DOC, .PDF, .docx";
                            }
                            else
                            {
                                string FileName = files.FileName.Replace(" ", "_");
                                Guid filenameguid = Guid.NewGuid();
                                var filePath = Path.Combine(Server.MapPath("~/Assets/ReportFile/"), filenameguid + FileName);
                                if (files.ContentLength > 0)
                                {
                                    using (var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        await files.InputStream.CopyToAsync(stream);
                                        //  await formFile.OpenReadStream.(stream);
                                        BinaryWriter Sw = new BinaryWriter(stream);
                                        Sw.Write(files.InputStream.CanWrite);
                                        Sw.Flush();
                                        Sw.Dispose();
                                        Sw.Close();
                                    }
                                    using (var _httpclient = new HttpClient())
                                    {
                                        _httpclient.BaseAddress = new Uri(_objAPIURL.BaseUrl);
                                        _httpclient.DefaultRequestHeaders.Clear();

                                    var content = new FormUrlEncodedContent(new[]
                                    {
                                                new KeyValuePair<string,string>("CustomerId",Session["CustomerId"].ToString()),
                                                new KeyValuePair<string,string>("ContentType",files.ContentType),
                                                 new KeyValuePair<string,string>("FullFileName",filenameguid + FileName),
                                                  new KeyValuePair<string,string>("FileSize",files.ContentLength.ToString()),
                                                   new KeyValuePair<string,string>("FileName",files.FileName)
                                           });
                                        _httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                                        HttpResponseMessage Res = await _httpclient.PostAsync("UploadReportDocument", content);
                                        if (Res.IsSuccessStatusCode)
                                        {
                                        }
                                    }
                                }
                            }

                        }

                        else
                        {
                            ViewData["FileExtensionMessage"] = "File exceeds the file maximum size 10MB";
                        }

                    }// process uploaded files // Don't rely on or trust the FileName property withoutvalidation.
                    return View("Messaging");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            catch (Exception ex)
            {
                ViewData["FileExtensionMessage"] = ex.Message;
                return RedirectToAction(nameof(Messaging));
            }
        }

        // POST: MessagingPanel/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Messaging));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessagingPanel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MessagingPanel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Messaging));
            }
            catch
            {
                return View();
            }
        }
    }
}