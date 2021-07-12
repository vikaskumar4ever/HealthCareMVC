using System;
using System.Text;
using System.Security.Cryptography;
using SI.Meditourism.AdminInfo.Model;

namespace SI.Meditourism.Encryption256AES
{
    public class KeyGenerator
    {
        public static string GetUniqueKey(int maxSize = 15)
        {
            try
            {
                char[] chars = new char[62];
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                byte[] data = new byte[1];
                using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                {
                    crypto.GetNonZeroBytes(data);
                    data = new byte[maxSize];
                    crypto.GetNonZeroBytes(data);
                }
                StringBuilder result = new StringBuilder(maxSize);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                return result.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GenerateToken(Admin objAdmin)
        {
            var IssuedOn = DateTime.Now;

            try
            {

                string randomnumber =
                   string.Join(":", new string[]
                   {
                     Convert.ToString(objAdmin.Id),
                     GetUniqueKey(),
                     Convert.ToString(objAdmin.AdminId),
                     Convert.ToString(IssuedOn.Ticks)
                   });

                return EncryptionLibrary.EncryptText(randomnumber);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

