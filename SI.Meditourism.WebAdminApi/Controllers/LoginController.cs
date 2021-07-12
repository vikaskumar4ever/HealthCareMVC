using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.AdminInfo.BAL;
using SI.Meditourism.AdminInfo.Model;
using SI.Meditourism.Encryption256AES;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public LoginResponse Post([FromBody]Admin objAdmin)
        {
            LoginResponse loginresponse = new LoginResponse();
            try
            {

                Admin objAdminValid = new Admin();

                if (string.IsNullOrEmpty(objAdmin.EmailId) || string.IsNullOrEmpty(objAdmin.PasswordHash))
                {
                    loginresponse.AdminId = string.Empty;
                    //loginresponse.Token = string.Empty;
                    loginresponse.EmailId = string.Empty;
                    return loginresponse;
                }

                var encryptedPassword = EncryptionLibrary.EncryptText(objAdmin.PasswordHash);
                objAdmin.PasswordHash = encryptedPassword;

                //Validate Login
                using (AdminInfo_BAL objBAL = new AdminInfo_BAL())
                {
                    objAdminValid = objBAL.ValidateUser(objAdmin);
                }

                if (objAdminValid != null)
                {
                    //loginresponse.AdminId =  objAdminValid.AdminId.ToString();
                    //loginresponse.EmailId = objAdminValid.EmailId;
                    loginresponse = GenerateToken(objAdminValid);
                }
                return loginresponse;
            }
            catch (Exception ex)
            {
                loginresponse.message = ex.Message;
            }
            return loginresponse;
        }
        public LoginResponse GenerateToken(Admin objAdmin)
        {
            LoginResponse objReturn = new LoginResponse();
            try
            {
                var IssuedOn = DateTime.Now;
                var newToken = KeyGenerator.GenerateToken(objAdmin);

                TokenManagerAdmin token = new TokenManagerAdmin();
                token.TokenID = 0;
                token.TokenKey = newToken;
                token.IssuedOn = IssuedOn;
                token.ExpiresOn = DateTime.Now.AddMinutes(Convert.ToInt32(1));
                token.CreatedOn = DateTime.Now;
                token.AdminId = objAdmin.AdminId;
                token.IsDeleted = false;

                //using (TokenManagerAdmin_BAL objBAL = new TokenManagerAdmin_BAL())
                //{
                //    objBAL.DeleteRecord(objAdmin.AdminId);
                //    objBAL.InsertUpdateRecord(token);
                //}

                objReturn = new LoginResponse();
                objReturn.AdminId = objAdmin.AdminId.ToString();
                objReturn.EmailId = objAdmin.EmailId;
                objReturn.Username = objAdmin.Username;
                objReturn.Token = newToken;
            }
            catch (Exception)
            {
                throw;
            }

            return objReturn;
        }
        public bool CheckOldpwd(ChangePassword value)
        {
            bool objReturn = false;
            using (AdminInfo_BAL objDAL = new AdminInfo_BAL())
            {
                objReturn = objDAL.CheckOldpwd(value);
            }
            return objReturn;
        }

        public Admin ValidateUser(Admin objAdmin)
        {
            Admin objReturn = new Admin();
            try
            {
                using (AdminInfo_BAL objDAL = new AdminInfo_BAL())
                {
                    objReturn = objDAL.ValidateUser(objAdmin);
                }
            }
            catch { }

            return objReturn;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
