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

                return publisherauthors.GroupBy(publisherGroup => new { publisherGroup.PublisherId, publisherGroup.PublisherName })
                                        .OrderBy(publisherGroup => publisherGroup.Key.PublisherId)
                                        .Select(publisher => new PublisherAuthorBookModel()
                                        {
                                            Publisher = new PublisherModel()
                                            {
                                                Id = publisher.Key.PublisherId,
                                                PublisherName = publisher.Key.PublisherName
                                            },
                                            AuthorBook = publisher.GroupBy(authorGroup => new { authorGroup.AuthorId, authorGroup.AuthorName })
                                                        .OrderBy(authorGroup => authorGroup.Key.AuthorId)
                                                        .Select(author => new AuthorBookModel()
                                                        {
                                                            Id = author.Key.AuthorId,
                                                            AuthorName = author.Key.AuthorName,
                                                            Books = author.Select(book => new BookModel()
                                                            {
                                                                Isbn = book.Isbn,
                                                                BookId = book.BookId,
                                                                BookName = book.BookName,
                                                                BookDescription = book.BookDescription,
                                                                BookCategoryId = book.BookCategoryId,
                                                                Quantity = book.BookQuantity,
                                                                Price = book.BookPrice
                                                            }).OrderBy(book => book.BookId)
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
