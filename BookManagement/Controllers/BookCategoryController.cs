using BookManagement.BAL.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryManager _bookCategoryManager;

        public BookCategoryController(IBookCategoryManager bookCategoryManager)
        {
            _bookCategoryManager = bookCategoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _bookCategoryManager.GetBookCategoryList();
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