using Business.Abstract;
using Entities.Dtos.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("allbooks")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbookbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbookdetails")]
        public IActionResult GetBookDetails(int id)
        {
            var result = _bookService.GetBookDetails(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("createbook")]
        public IActionResult Create([FromBody] BookCreateDTO bookCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _bookService.Create(bookCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("updatebook")]
        public IActionResult Update([FromBody] BookUpdateDTO bookUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _bookService.Update(bookUpdateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


    }
}
