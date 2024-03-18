using Business.Abstract;
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
    }
}
