namespace Business.Abstract
{
    public interface IEmailService
    {
        int SendVerificationCode(string email);
    }
}
