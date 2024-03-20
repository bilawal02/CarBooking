using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingUtility
{
    public class EmailSender:IEmailSender
    {
        public string SendGridSecretKey { get; set; }

        public EmailSender(IConfiguration _configuration)
        {
            SendGridSecretKey = _configuration.GetValue<string>("SendGrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var emailToBeSend = new MimeMessage();
            //emailToBeSend.From.Add(MailboxAddress.Parse("bilawalali21222@gmail.com"));
            //emailToBeSend.To.Add(MailboxAddress.Parse(email));
            //emailToBeSend.Subject = subject;
            //emailToBeSend.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

            //using (var clientEmail = new SmtpClient())
            //{
            //    clientEmail.Connect("smtp.gmail.com", 587,SecureSocketOptions.StartTls);
            //    clientEmail.Authenticate("bilawalali21222@gmail.com", "MyPasswordIsHere");
            //    clientEmail.Send(emailToBeSend);
            //    clientEmail.Disconnect(true);
            //}
            //return Task.CompletedTask;

            var emailToClient = new SendGridClient(SendGridSecretKey);
            var from = new EmailAddress("bilawalali21222@gmail.com", "Confirm Email from Bulky Book");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            return emailToClient.SendEmailAsync(msg);
        }
    }
}
