using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using ServerBook.Models.Dtos;
using ServerBook.Services.Interfaces;

namespace ServerBook.Services.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _config;
        public EmailRepository(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.For));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Content
            };
            using var smtp = new SmtpClient();
            smtp.Connect(
                _config.GetSection("Email:Host").Value,
              Convert.ToInt32(_config.GetSection("Email:Port").Value),
              SecureSocketOptions.StartTls
            );

            smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}