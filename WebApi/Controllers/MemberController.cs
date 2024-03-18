using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("allmembers")]
        public IActionResult GetAll()
        {
            var result = _memberService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
