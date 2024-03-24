using Business.Abstract;
using Entities.Dtos.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("allpublishers")]
        public IActionResult GetAll()
        {
            var result = _publisherService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getpublisherbyid")]
        public IActionResult GetById(int id)
        {
            var result = _publisherService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("createpublisher")]
        public IActionResult Create([FromBody] PublisherCreateDTO publisherCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _publisherService.Create(publisherCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("updatepublisher")]
        public IActionResult Update([FromBody] PublisherUpdateDTO publisherUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _publisherService.Update(publisherUpdateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
