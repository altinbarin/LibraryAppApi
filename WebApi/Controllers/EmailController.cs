using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendverificationcode")]
        public IActionResult SendVerificationCode(string email)
        {
            var result = _emailService.SendVerificationCode(email);

            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest(Messages.EmailCanNotBeSend);
        }
    }
}
