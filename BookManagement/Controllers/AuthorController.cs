using BookManagement.BAL.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _authorManager.GetAuthorList();
            if (categories != null)
            {
                return StatusCode((int)HttpStatusCode.OK, categories);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }
    }
}