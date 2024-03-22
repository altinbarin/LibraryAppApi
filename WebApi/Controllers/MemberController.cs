using Business.Abstract;
using Entities.Dtos.Member;
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

        [HttpGet("allmembersdeleted")]
        public IActionResult GetAllDeleted()
        {
            var result = _memberService.GetAllDeleted();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("getmemberbyid")]
        public IActionResult GetById(int id)
        {
            var result = _memberService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("createmember")]
        public IActionResult Create([FromBody] MemberCreateDTO memberCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _memberService.Create(memberCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("updatemember")]
        public IActionResult Update([FromBody] MemberUpdateDTO memberUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _memberService.Update(memberUpdateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("deletemember")]
        public IActionResult Delete(int id)
        {
            var result = _memberService.Delete(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("activatemember")]
        public IActionResult Activate(int id)
        {
            var result = _memberService.Activate(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
