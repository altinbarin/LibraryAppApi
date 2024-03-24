using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Business.Notifications
{
    public class EMailSender
    {
        readonly IConfiguration _configuration;

        public EMailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendSuccesfulBorrowingEmail(string emailAddress, string memberFullName, string bookName)
        {

            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            // E-posta gönderimi için gerekli bilgiler
            client.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            client.Port = Convert.ToInt32(_configuration["Mail:Port"]);
            client.Host = _configuration["Mail:Host"];
            client.EnableSsl = true;

            //Mesaj oluşturma
            mail.From = new MailAddress(_configuration["Mail:UserName"],"",System.Text.Encoding.UTF8);
            mail.Subject = "FA Library Hatırlatma";
            mail.Body = $"Sayın {memberFullName}, {bookName} adlı kitabı ödünç alma işleminiz başarıyla gerçekleşti. Kitabı en geç 30 gün içerisinde iade etmeniz gerekmektedir.";
            mail.To.Add(emailAddress);

            // E-posta gönderme
            client.Send(mail);

        }

        public void Send25WarningEmail(string emailAddress, string memberFullName, string bookName)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            // E-posta gönderimi için gerekli bilgiler
            client.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            client.Port = Convert.ToInt32(_configuration["Mail:Port"]);
            client.Host = _configuration["Mail:Host"];
            client.EnableSsl = true;

            //Mesaj oluşturma
            mail.From = new MailAddress(_configuration["Mail:UserName"], "", System.Text.Encoding.UTF8);
            mail.Subject = "FA Library Hatırlatma";
            mail.Body = $"Sayın {memberFullName}, {bookName} adlı kitabı iade tarihinize 5 gün kaldı. Lütfen bu kitabı en yakın zamanda iade ediniz. Eğer kitabı iade ettiyseniz bu mesajı dikkate almayın.";
            mail.To.Add(emailAddress);

            // E-posta gönderme
            client.Send(mail);
        }

        public void Send30DaysWarningEmail(string emailAddress, string memberFullName, string bookName)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            // E-posta gönderimi için gerekli bilgiler
            client.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            client.Port = Convert.ToInt32(_configuration["Mail:Port"]);
            client.Host = _configuration["Mail:Host"];
            client.EnableSsl = true;

            //Mesaj oluşturma
            mail.From = new MailAddress(_configuration["Mail:UserName"], "", System.Text.Encoding.UTF8);
            mail.Subject = "FA Library Hatırlatma";
            mail.Body = $"Sayın {memberFullName}, {bookName} adlı kitabı iade tarihiniz geçti. Lütfen en yakın zamanda iade ediniz. Eğer kitabı iade ettiyseniz bu mesajı dikkate almayın.";
            mail.To.Add(emailAddress);

            // E-posta gönderme
            client.Send(mail);
        }

    }
}
