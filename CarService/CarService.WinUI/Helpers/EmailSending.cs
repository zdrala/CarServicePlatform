using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarService.WinUI.Helpers
{
    public class EmailSending
    {
        public static void SendMail_ScheduleFinished(string NameLastName, string CarServiceName, string toMail, string date)
        {
            var fromEmail = new MailAddress("seminarskirs1test@gmail.com", "Seminarski RS2");
            var toEmail = new MailAddress(toMail);
            string subject = "";
            string body = "";
            var fromEmailPassword = "TestTestRS1";
            subject = "Termin servisiranja završen";
            body = "Poštovani/na " + NameLastName + ",<br/>Vaš termin servisiranja u auto servisu " + CarServiceName + " datuma: "+date+" administrator je označio završenim.";
                
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);

        }
    }
}
