using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;

namespace IsraaJournals.Services.Email
{
    public class MailHelper : IMailHelper
    {
     

        public async Task SendEmailAsync(InputEmailMessage mailRequest)
        {
            var message = new MailMessage();

            message.To.Add(new MailAddress(mailRequest.ToEmail));
            message.From = new MailAddress("alaa199903@gmail.com", "Israa Jornal");
            message.Subject = mailRequest.Subject;
            message.IsBodyHtml = true;
            message.Body = mailRequest.Body;
            using var emailClient = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,

                UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential("alaahashour@gmail.com", "rcyugjzmzntulvit")
                Credentials = new NetworkCredential("alaa199903@gmail.com", "njjmshjtaorogrrf")
            };
            await emailClient.SendMailAsync(message);
        }
    }
}
