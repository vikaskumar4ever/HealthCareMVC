using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using SI.Meditourism.WebFrontEnd_Mvc.Models.Services;
using SI.Meditourism.BaseUrl;
using Newtonsoft.Json;
using System.IO;

namespace SI.Meditourism.WebFrontEnd_Mvc.Controllers
{
    public class MessagingPanelController : Controller
    {
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
        //public ActionResult SendMsg(AdminCustomerChat collection)
        //{
        //    try
        //    {
        //        if (HttpContext.Session.GetString("CustomerId") != null)
        //        {
        //            // TODO: Add insert logic here
        //            if (collection != null)
        //            {
        //                if (collection.Message != null)
        //                {
        //                    DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
        //                    collection.AdminCustomerChatId = Guid.NewGuid();
        //                    collection.IsAdmin = false;
        //                    collection.IsActive = true;
        //                    collection.IsDeleted = false;
        //                    Guid CustomerId = new Guid(HttpContext.Session.GetString("CustomerId"));
        //                    collection.CreatedBy = CustomerId;
        //                    collection.UpdatedBy = CustomerId;
        //                    collection.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //                    collection.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //                    collection.CustomerId = CustomerId;
        //                    using (AdminCustomerChat_BAL objBAL = new AdminCustomerChat_BAL())
        //                    {
        //                        objBAL.InsertUpdateRecord(collection);
        //                    }
        //                }
        //            }

        //            return RedirectToAction(nameof(Messaging));
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["ErrorMessage"] = ex.Message;
        //        return RedirectToAction(nameof(Messaging));
        //    }
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> UploadDoc(List<IFormFile> files)
        //{
        //    try
        //    {
        //        ViewData["FileExtensionMessage"] = null;
        //        if (HttpContext.Session.GetString("CustomerId") != null)
        //        {
        //            if (files.Count != 0)
        //            {
        //                var SupportedTypes = new[] { "jpg", "doc", "pdf", "png", "docx" };
        //                foreach (var formFile in files)
        //                {
        //                    if (formFile.Length < 11010048)
        //                    {
        //                        var fileExt = System.IO.Path.GetExtension(formFile.FileName).Substring(1);
        //                        if (!SupportedTypes.Contains(fileExt))
        //                        {
        //                            ViewData["FileExtensionMessage"] = "File Extension Is Invalid - Only Upload .JPG, .PNG, DOC, .PDF, .docx";
        //                        }
        //                        else
        //                        {
        //                            string FileName = formFile.FileName.Replace(" ", "_");
        //                            Guid filenameguid = Guid.NewGuid();
        //                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ReportFile/", filenameguid + FileName);
        //                            if (formFile.Length > 0)
        //                            {
        //                                using (var stream = new FileStream(filePath, FileMode.Create))
        //                                {
        //                                    await formFile.CopyToAsync(stream);
        //                                }
        //                                DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
        //                                using (Report_BAL _objBAL = new Report_BAL())
        //                                {
        //                                    Report _objReport = new Report();
        //                                    Guid CustomerId = new Guid(HttpContext.Session.GetString("CustomerId"));
        //                                    _objReport.ReportId = Guid.NewGuid();
        //                                    _objReport.CustomerId = CustomerId;
        //                                    _objReport.FileType = formFile.ContentType;
        //                                    _objReport.FileName = filenameguid + FileName;
        //                                    _objReport.FileSize = formFile.Length.ToString();
        //                                    _objReport.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //                                    _objReport.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
        //                                    _objReport.UpdatedBy = CustomerId;
        //                                    _objReport.CreatedBy = CustomerId;
        //                                    _objReport.IsActive = true;
        //                                    _objReport.IsDeleted = false;
        //                                    _objReport.Name = FileName;
        //                                    _objReport.FileNameByCode = formFile.ContentDisposition;
        //                                    _objBAL.InsertUpdateRecord(_objReport);
        //                                }
        //                            }

        //                        }
        //                    }
        //                    else
        //                    {
        //                        ViewData["FileExtensionMessage"] = "File exceeds the file maximum size 10MB";
        //                    }
        //                }
        //            }// process uploaded files // Don't rely on or trust the FileName property withoutvalidation.
        //            return View("Messaging");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        ViewData["FileExtensionMessage"] = ex.Message;
        //        return RedirectToAction(nameof(Messaging));
        //    }
        //}

        //public JsonResult GetAllDocument(int id)
        //{
        //    if (HttpContext.Session.GetString("CustomerId") != null)
        //    {
        //        using (Report_BAL _objBAL = new Report_BAL())
        //        {
        //            List<Reportlist> _objReport = new List<Reportlist>();
        //            Guid CustomerId = new Guid(HttpContext.Session.GetString("CustomerId"));
        //            _objReport = _objBAL.GetRecorodById(CustomerId);
        //            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
        //            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        //            var result = Newtonsoft.Json.JsonConvert.SerializeObject(_objReport, jsonSerializerSettings);
        //            return Json(result);
        //        }
        //    }
        //    else
        //    {
        //        return Json("");
        //    }
        //}
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