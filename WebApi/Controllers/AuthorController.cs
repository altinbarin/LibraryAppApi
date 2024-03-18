using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("allauthors")]
        public IActionResult GetAll()
        {
            var result = _authorService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
