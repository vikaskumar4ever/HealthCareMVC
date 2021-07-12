using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.FrntMailer
{
    public class GMailer
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public string AttachmentFilename { get; set; }

        static GMailer()
        {
            GmailHost = "mail.shrewdinfotech.com";//"smtp.gmail.com"
            GmailPort = 25; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment. noreply@yoonikcreations.com
            GmailSSL = false;
            GmailUsername = "laxman.negi@shrewdinfotech.com";
            GmailPassword = "laxman_123";
        }

        public string Send()
        {
            string strMsg = string.Empty;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);
                smtp.Port = GmailPort;
                smtp.Host = GmailHost;
                smtp.EnableSsl = GmailSSL;
                //smtp.TargetName = "STARTTLS/smtp.gmail.com";

                using (MailMessage message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    if (AttachmentFilename != null && AttachmentFilename != "")
                    {
                        message.Attachments.Add(new Attachment(AttachmentFilename));
                    }
                    smtp.Send(message);
                }
                strMsg = "Success";
            }
            catch (Exception ex)
            {
                strMsg = "Fail : " + ex.ToString();
            }

            return strMsg;
        }

    }
}
