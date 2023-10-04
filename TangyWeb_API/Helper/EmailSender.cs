using System;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace TangyWeb_API.Helper
{
    public class EmailSender : IEmailSender
    {
        //public string EmailSecret { get; set; }
        private IConfiguration _configuration { get; set; }

        public EmailSender(IConfiguration _config)
        {
            _configuration = _config;
            //EmailSecret = _config.GetValue<string>("Email:SecretKey");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                //string emailSecret = _configuration.GetValue<string>("Email:SecretKey");
                //string emailAcc = _configuration.GetValue<string>("Email:EmailAcc");
                //var emailToSend = new MimeMessage();
                //emailToSend.From.Add(MailboxAddress.Parse("smirkyuk2021@gmail.com"));
                //emailToSend.To.Add(MailboxAddress.Parse(email));
                //emailToSend.Subject = subject;
                //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

                ////send email
                //using var emailClient = new SmtpClient();
                //emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                //emailClient.Authenticate(emailAcc, emailSecret);
                //emailClient.Send(emailToSend);
                //emailClient.Disconnect(true);


                var emailAcc = _configuration.GetValue<string>("Email:EmailAcc");
                using var smtpClient = new System.Net.Mail.SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(emailAcc, _configuration.GetValue<string>("Email:SecretKey"));

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailAcc);
                mailMessage.To.Add(email);
                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

