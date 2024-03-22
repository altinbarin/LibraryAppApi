using Business.Abstract;
using Entities.Dtos.Author;
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

        [HttpGet("getauthorbyid")]
        public IActionResult GetById(int id)
        {
            var result = _authorService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("createauthor")]
        public IActionResult Create([FromBody] AuthorCreateDTO authorCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _authorService.Create(authorCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("updateauthor")]
        public IActionResult Update([FromBody] AuthorUpdateDTO authorUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _authorService.Update(authorUpdateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
