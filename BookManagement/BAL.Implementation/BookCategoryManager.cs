using BookManagement.BAL.Shared;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Implementation
{
    public class BookCategoryManager : IBookCategoryManager
    {
        public async Task<IEnumerable<CategoryListModel>> GetBookCategoryList()
        {
            using (var context = new BookManagementContext())
            {
                var authors = await context.BookCategory
                                .Select(a => new CategoryListModel()
                                {
                                    CategoryId = a.Id,
                                    CategoryName = a.Category
                                }).ToListAsync();

                return authors;
            }
        }
    }
}
