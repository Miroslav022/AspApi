using System.Net;
using System.Net.Mail;

namespace watchShopApi.Core
{
    public class EmailSender : ISendEmail
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient(_configuration["Email:SmtpServer"], int.Parse(_configuration["Email:Port"]))
            {
                Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
                EnableSsl = bool.Parse(_configuration["Email:EnableSsl"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(""),
                Subject = subject,
                Body = body,
            };

            mailMessage.To.Add(to);

            smtpClient.Send(mailMessage);
        }
    }
}
