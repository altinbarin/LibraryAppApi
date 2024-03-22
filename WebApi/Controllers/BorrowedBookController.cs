using Business.Abstract;
using Entities.Dtos.BorrowedBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedBookService;

        public BorrowedBookController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }

        [HttpGet("allborrowedbooks")]
        public IActionResult GetAll()
        {
            var result = _borrowedBookService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("allbooksreturned")]
        public IActionResult GetAllBooksReturned()
        {
            var result = _borrowedBookService.GetAllBooksReturned();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getborrowedbookbyid")]
        public IActionResult GetById(int id)
        {
            var result = _borrowedBookService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("createborrowedbook")]
        public IActionResult Create(BorrowedBookCreateDTO borrowedBookCreateDto)
        {
            var result = _borrowedBookService.Create(borrowedBookCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("bookreturn")]
        public IActionResult BookReturn(int borrowedBookId)
        {
            var result = _borrowedBookService.BookReturn(borrowedBookId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
