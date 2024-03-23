using System.Net;
using System.Net.Mail;

namespace Business.Notifications
{
    public class EMailSender
    {
 

        public void SendSuccesfulBorrowingEmail(string emailAddress, string memberFullName, string bookName)
        {

            MailMessage mesaj = new MailMessage();
            SmtpClient client = new SmtpClient();

            // E-posta gönderimi için gerekli bilgiler
            client.Credentials = new NetworkCredential("fohmkaloritakip@gmail.com", "znyj ajxp mjyl vvyh");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            //Mesaj oluşturma
            mesaj.From = new MailAddress("fohmkaloritakip@gmail.com");
            mesaj.Subject = "FA Library Hatırlatma";
            mesaj.Body = $"Sayın {memberFullName}, {bookName} adlı kitabı ödünç alma işleminiz başarıyla gerçekleşti. Kitabı en geç 30 gün içerisinde iade etmeniz gerekmektedir.";
            mesaj.To.Add(emailAddress);

            // E-posta gönderme
            client.Send(mesaj);

        }

        public void Send25WarningEmail(string emailAddress, string memberFullName, string bookName)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient client = new SmtpClient();

            // E-posta gönderimi için gerekli bilgiler
            client.Credentials = new NetworkCredential("fohmkaloritakip@gmail.com", "znyj ajxp mjyl vvyh");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            //Mesaj oluşturma
            mesaj.From = new MailAddress("fohmkaloritakip@gmail.com");
            mesaj.Subject = "FA Library Hatırlatma";
            mesaj.Body = $"Sayın {memberFullName}, {bookName} adlı kitabı iade tarihinize 5 gün kaldı. Lütfen bu kitabı en yakın zamanda iade ediniz. Eğer kitabı iade ettiyseniz bu mesajı dikkate almayın.";
            mesaj.To.Add(emailAddress);

            // E-posta gönderme
            client.Send(mesaj);
        }

        public void Send30DaysWarningEmail(string emailAddress, string memberFullName, string bookName)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient client = new SmtpClient();

            // E-posta gönderimi için gerekli bilgiler
            client.Credentials = new NetworkCredential("fohmkaloritakip@gmail.com", "znyj ajxp mjyl vvyh");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            //Mesaj oluşturma
            mesaj.From = new MailAddress("fohmkaloritakip@gmail.com");
            mesaj.Subject = "FA Library Hatırlatma";
            mesaj.Body = $"Sayın {memberFullName}, {bookName} adlı kitabı iade tarihiniz geçti. Lütfen en yakın zamanda iade ediniz. Eğer kitabı iade ettiyseniz bu mesajı dikkate almayın.";
            mesaj.To.Add(emailAddress);

            // E-posta gönderme
            client.Send(mesaj);
        }

    }
}
