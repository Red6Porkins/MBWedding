using MattAndBrittneyWedding.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace MattAndBrittneyWedding.Services
{
    public class EmailService : IDisposable
    {
        public EmailService()
        {
            CarbonCopy = new List<String>();
            BlindCarbonCopy = new List<String>();
            Replacements = new ListDictionary();
        }

        public String EmailTo { get; set; }

        public String EmailFrom { get; set; }

        public String Name { get; set; }

        public String Subject { get; set; }

        public String Message { get; set; }

        public List<String> CarbonCopy { get; set; }

        public List<String> BlindCarbonCopy { get; set; }

        public ListDictionary Replacements { get; set; }

        public bool Send ()
        {
            if (EmailTo == null || EmailFrom == null || Message == null)
                return false;

            MailDefinition md = new MailDefinition();
            md.From = EmailFrom;
            md.Subject = Subject;            

            var PlainText = Regex.Replace(Message, "<.*?>", String.Empty);

            MailMessage msg = md.CreateMailMessage(EmailTo, Replacements, PlainText, new System.Web.UI.Control());
            msg.BodyEncoding = Encoding.UTF8;
            msg.SubjectEncoding = Encoding.UTF8;            
            msg.From = new MailAddress(EmailFrom, "MB Wedding Mailbot");     //redunant, but mail headers are wonky
            msg.Sender = new MailAddress(EmailFrom, "MB Wedding Mailbot");    //redunant, but mail headers are wonky
            

            foreach (var Item in CarbonCopy)
            {
                msg.CC.Add(new MailAddress(Item.ToString()));
            }

            foreach (var Item in BlindCarbonCopy)
            {
                msg.Bcc.Add(new MailAddress(Item.ToString()));
            }

            //var MailClient = new SmtpClient();            
            //MailClient.PickupDirectoryLocation = @"C:\inetpub\mailroot\Pickup";

            var MailClient = new SmtpClient();
            MailClient.Host = "email-smtp.us-east-1.amazonaws.com";
            MailClient.Port = 587;
            MailClient.EnableSsl = true;
            MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            var Credentials = new NetworkCredential();
            Credentials.UserName = "";
            Credentials.Password = "";

            MailClient.UseDefaultCredentials = false;
            MailClient.Credentials = Credentials;

            try
            {
                MailClient.Send(msg);
                MailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                using (var GRepo = new GuestBookRepository())
                {
                    GRepo.WriteLog(ex, "From Email Service");
                }
                MailClient.Dispose();
                return false;
            }
        }

        public void Dispose ()
        {
            
        }
    }
}