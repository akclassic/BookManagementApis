using BookManagement.BAL.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherManager _publisherManager;

        public PublisherController(IPublisherManager publisherManager)
        {
            _publisherManager = publisherManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var publishers = await _publisherManager.GetPublisherList();
            if(publishers != null)
            {
                return StatusCode((int)HttpStatusCode.OK, publishers);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }
    }
}