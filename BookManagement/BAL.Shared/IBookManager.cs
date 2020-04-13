using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Shared
{
    public interface IBookManager
    {
        public Task<IEnumerable<BookListModel>> GetBookList();

        public Task<BookListModel> GetSingleBookDetail(int id);

        public Task<bool> SaveBookDetail(BookModel singleBookModel);

        public Task<bool> UpdateBookDetail(int id, BookModel singleBookModel);

        public Task<bool> DeleteBookDetail(int id);

        public Task<IEnumerable<GroupByBookModel>> GetBookByGroup(int authorid, int publisherid);
    }
}
