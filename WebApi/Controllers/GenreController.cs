using Business.Abstract;
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
    }
}
