using BookManagement.BAL.Shared;
using BookManagement.Entities;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Implementation
{
    public class PublisherManager : IPublisherManager
    {
        public async Task<IEnumerable<PublisherAuthorBookModel>> GetPublisherDetails()
        {
            using (var context = new BookManagementContext())
            {

                var publisherauthors = (from publisherauthor in context.PublisherAuthor
                                        join publisher in context.Publisher
                                        on publisherauthor.PublisherId equals publisher.Id
                                        join author in context.Author
                                        on publisherauthor.AuthorId equals author.Id
                                        join books in context.Book
                                        on author.Id equals books.AuthorId
                                        select new
                                        {
                                            PublisherId = publisher.Id,
                                            PublisherName = publisher.PublisherName,
                                            AuthorId = author.Id,
                                            AuthorName = author.AuthorName,
                                            Isbn = books.Isbn,
                                            BookId = books.BookId,
                                            BookName = books.BookName,
                                            BookDescription = books.BookDescription,
                                            BookQuantity = books.Quantity,
                                            BookPrice = books.Price,
                                            BookCategoryId = books.BookCategoryId
                                        })
                                        .ToList();

                return publisherauthors.GroupBy(g => new { g.PublisherId, g.PublisherName })
                                        .OrderBy(g => g.Key.PublisherId)
                                        .Select(a => new PublisherAuthorBookModel()
                                        {
                                            Publisher = new SinglePublisherModel()
                                            {
                                                Id = a.Key.PublisherId,
                                                PublisherName = a.Key.PublisherName
                                            },
                                            AuthorBook = a.GroupBy(x => new { x.AuthorId, x.AuthorName })
                                                        .OrderBy(x => x.Key.AuthorId)
                                                        .Select(y => new AuthorBookModel()
                                                        {
                                                            Id = y.Key.AuthorId,
                                                            AuthorName = y.Key.AuthorName,
                                                            Books = y.Select(z => new SingleBookModel()
                                                            {
                                                                Isbn = z.Isbn,
                                                                BookId = z.BookId,
                                                                BookName = z.BookName,
                                                                BookDescription = z.BookDescription,
                                                                BookCategoryId = z.BookCategoryId,
                                                                Quantity = z.BookQuantity,
                                                                Price = z.BookPrice
                                                            }).OrderBy(z => z.BookId)
                                                        })
                                        });
                                        

                //var authorbooks = (from author in context.Author
                //                   join book in context.Book
                //                   on author.Id equals book.AuthorId
                //                   select new
                //                   {
                //                       AuthorId = author.Id,
                //                       AuthorName = author.AuthorName,
                //                       //Isbn = book.Isbn,
                //                       //BookId =book.BookId,
                //                       //Price = book.Price,
                //                       //Quantity = book.Quantity,
                //                       //CategoryId = book.BookCategoryId
                //                       Book = book
                //                   }).ToList();

                //var publishers = await context.Publisher
                //                        .Select(p => new PublisherAuthorBookModel()
                //                        {
                //                            Publisher = new SinglePublisherModel()
                //                            {
                //                                Id = p.Id,
                //                                PublisherName = p.PublisherName,
                //                                Email = p.Email
                //                            },
                //                            AuthorBook = authorbooks.Select(ab => new AuthorBook()
                //                            {
                //                                Author = new SingleAuthorModel()
                //                                {
                //                                    Id = ab.AuthorId,
                //                                    AuthorName = ab.AuthorName,
                //                                },
                //                                Books = ab.Book
                //                            }).ToList()
                //                        })
                //                        .ToListAsync();
            }
        }

        public async Task<IEnumerable<PublisherListModel>> GetPublisherList()
        {
            using (var context = new BookManagementContext())
            {
                var publishers = await context.Publisher
                                .Select(p => new PublisherListModel()
                                {
                                    PublisherId = p.Id,
                                    PublisherName = p.PublisherName,
                                    PublisherEmail = p.PublisherName
                                }).ToListAsync();

                return publishers;
            }
        }
    }
}
