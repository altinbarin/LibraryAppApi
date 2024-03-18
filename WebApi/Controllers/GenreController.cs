using Business.Abstract;
using Entities.Dtos.Genre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("allgenres")]
        public IActionResult GetAll()
        {
            var result = _genreService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getgenrebyid")]
        public IActionResult GetById(int id)
        {
            var result = _genreService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("creategenre")]
        public IActionResult Create([FromBody] GenreCreateDTO genreCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _genreService.Create(genreCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("updategenre")]
        public IActionResult Update([FromBody] GenreUpdateDTO genreUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _genreService.Update(genreUpdateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
