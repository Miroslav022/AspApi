using System.Net;
using System.Net.Mail;

namespace watchShopApi.Core
{
    public class EmailSender : ISendEmail
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("asp.net.ict@gmail.com", "Aspnetict02")
            };

            return client.SendMailAsync(
                new MailMessage(from: "asp.net.ict@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
