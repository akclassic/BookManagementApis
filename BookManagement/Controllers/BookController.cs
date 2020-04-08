using BookManagement.BAL.Shared;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet]
        public async Task<IEnumerable<BookListModel>> Get()
        {
            return await _bookManager.GetBookList();
        }

        [HttpGet("{id}")]
        public async Task<BookListModel> Get(int id)
        {
            return await _bookManager.GetSingleBookDetail(id);
        }

        [HttpPost]
        public async Task<bool> Post([FromBody]SingleBookModel singleBookModel)
        {
            return await _bookManager.SaveBookDetail(singleBookModel);
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody]SingleBookModel singleBookModel)
        {
            return await _bookManager.UpdateBookDetail(id, singleBookModel);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _bookManager.DeleteBookDetail(id);
        }

        [HttpGet("groupby/{authorid}/{publisherid}")]
        public async Task<IActionResult> BookByGroup(int authorid, int publisherid)
        {
            var result = await _bookManager.GetBookByGroup(authorid, publisherid);
            if(result != null)
            {
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }
    }
}