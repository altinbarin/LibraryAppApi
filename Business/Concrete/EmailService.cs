using Business.Abstract;
using System.Net;
using System.Net.Mail;

namespace Business.Concrete
{
    public class EmailService : IEmailService
    {
        public int SendVerificationCode(string email)
        {
            int code = new Random().Next(100000, 999999);

            try
            {
                MailMessage mesaj = new MailMessage();
                SmtpClient client = new SmtpClient();

                // E-posta gönderimi için gerekli bilgiler
                client.Credentials = new NetworkCredential("fohmkaloritakip@gmail.com", "znyj ajxp mjyl vvyh");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;


                mesaj.From = new MailAddress("fohmkaloritakip@gmail.com");
                mesaj.Subject = "FA Kütüphanesi Onay Kodu";
                mesaj.Body = $"FA Kütüphanesine hoşgeldiniz! Onay kodunuz:  {code}";
                mesaj.To.Add(email);

                // E-posta gönderme
                client.Send(mesaj);

                return code;
            }
            catch (Exception)
            {
                return 0;
            }
           
        }
    }
}
