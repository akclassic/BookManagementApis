using BookManagement.BAL.Shared;
using BookManagement.Entities;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Implementation
{
    public class BookManager : IBookManager
    {
        public async Task<IEnumerable<BookListModel>> GetBookList()
        {
            using (var context = new BookManagementContext())
            {
                var bookList = await context.Book
                                .Include(b => b.Author)
                                .Include(b => b.Pulisher)
                                .Include(b => b.BookCategory)
                                .Select(b => new BookListModel()
                                {
                                    BookId = b.BookId,
                                    Isbn = b.Isbn,
                                    BookName = b.BookName,
                                    BookDescription = b.BookDescription,
                                    Price = b.Price,
                                    Quantity = b.Quantity,
                                    AuthorId = b.Author.Id,
                                    PulisherId = b.Pulisher.Id,
                                    BookCategoryId = b.BookCategory.Id
                                })
                                .OrderBy(b => b.BookId)
                                .ToListAsync();

                return bookList;
            }
        }

        public async Task<BookListModel> GetSingleBookDetail(int id)
        {
            using (var context = new BookManagementContext())
            {
                var book = await context.Book
                                .Where(b => b.BookId == id)
                                .Include(b => b.Author)
                                .Include(b => b.Pulisher)
                                .Include(b => b.BookCategory)
                                .Select(b => new BookListModel()
                                {
                                    BookId = b.BookId,
                                    Isbn = b.Isbn,
                                    BookName = b.BookName,
                                    BookDescription = b.BookDescription,
                                    Price = b.Price,
                                    Quantity = b.Quantity,
                                    AuthorId = b.Author.Id,
                                    PulisherId = b.Pulisher.Id,
                                    BookCategoryId = b.BookCategory.Id
                                }).ToListAsync();

                return book[0];
            }
        }

        public async Task<bool> SaveBookDetail(SingleBookModel singleBookModel)
        {
            bool isSuccess = false;

            using (var context = new BookManagementContext())
            {
                var book = new Book()
                {
                    Isbn = singleBookModel.Isbn,
                    BookId = singleBookModel.BookId,
                    BookName = singleBookModel.BookName,
                    BookDescription = singleBookModel.BookName,
                    BookCategoryId = singleBookModel.BookCategoryId,
                    Price = singleBookModel.Price,
                    AuthorId = singleBookModel.AuthorId,
                    PulisherId = singleBookModel.PulisherId,
                    Quantity = singleBookModel.Quantity
                };

                context.Book.Add(book);
                context.SaveChanges();
                isSuccess = true;
            }

            return isSuccess;
        }

        public async Task<bool> UpdateBookDetail(int id, SingleBookModel singleBookModel)
        {
            bool isSuccess = false;

            using (var context = new BookManagementContext())
            {
                var book = context.Book.FirstOrDefault(b => b.BookId == id);

                book.Isbn = singleBookModel.Isbn;
                book.BookId = singleBookModel.BookId;
                book.BookName = singleBookModel.BookName;
                book.BookDescription = singleBookModel.BookDescription;
                book.BookCategoryId = singleBookModel.BookCategoryId;
                book.Price = singleBookModel.Price;
                book.AuthorId = singleBookModel.AuthorId;
                book.PulisherId = singleBookModel.PulisherId;
                book.Quantity = singleBookModel.Quantity;

                context.SaveChanges();
                isSuccess = true;
            }

            return isSuccess;
        }

        public async Task<bool> DeleteBookDetail(int id)
        {
            bool isSuccess = false;
            using (var context = new BookManagementContext())
            {
                var book = context.Book.FirstOrDefault(b => b.BookId == id);

                context.Book.Remove(book);
                context.SaveChanges();
                isSuccess = true;
            }

            return isSuccess;
        }

        public async Task<IEnumerable<GroupByBookModel>> GetBookByGroup(int authorid, int publisherid)
        {
            using (var context = new BookManagementContext())
            {
                var books = context.Book
                           .Where(b => b.AuthorId == authorid && b.PulisherId == publisherid)
                           .Select(b => new SingleBookModel()
                           {
                               Isbn = b.Isbn,
                               BookId = b.BookId,
                               BookName = b.BookName,
                               BookDescription = b.BookDescription,
                               Price = b.Price,
                               BookCategoryId = b.BookCategoryId,
                               Quantity = b.Quantity,
                               AuthorId = b.AuthorId,
                               PulisherId = b.PulisherId
                           }).ToList();

                var bookscount = await context.Book
                            .Where(b => b.AuthorId == authorid && b.PulisherId == publisherid)
                            .GroupBy(b => new { b.PulisherId, b.AuthorId })
                            .Select(g => new GroupByBookModel()
                            {
                                AuthorId = g.Key.AuthorId,
                                PublisherId = g.Key.PulisherId,
                                NumberOfBooks = g.Count(),
                                
                                //BookName = g.AsEnumerable().FirstOrDefault(b => b.AuthorId == g.Key.AuthorId && b.PulisherId == g.Key.PulisherId).BookName
                                Books = books
                            })
                            .ToListAsync();

               

                return bookscount;
            }
        }
    }
}
