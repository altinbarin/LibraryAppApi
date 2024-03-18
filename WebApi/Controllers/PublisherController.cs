using Business.Abstract;
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
    }
}
