using Business.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Business.Concrete
{
    public class EmailService : IEmailService
    {
        readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int SendVerificationCode(string email)
        {
            int code = new Random().Next(100000, 999999);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                // E-posta gönderimi için gerekli bilgiler
                client.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
                client.Port = Convert.ToInt32(_configuration["Mail:Port"]);
                client.Host = _configuration["Mail:Host"];
                client.EnableSsl = true;


                mail.From = new MailAddress(_configuration["Mail:UserName"], "", System.Text.Encoding.UTF8);
                mail.Subject = "FA Kütüphanesi Onay Kodu";
                mail.Body = $"FA Kütüphanesine hoşgeldiniz! Onay kodunuz:  {code}";
                mail.To.Add(email);

                // E-posta gönderme
                client.Send(mail);

                return code;
            }
            catch (Exception)
            {
                return 0;
            }
           
        }
    }
}
