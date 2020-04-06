﻿using BookManagement.BAL.Shared;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
                                    AuthorName = b.Author.AuthorName,
                                    PulisherName = b.Pulisher.PublisherName,
                                    BookCategoryName = b.BookCategory.Category
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
                                    AuthorName = b.Author.AuthorName,
                                    PulisherName = b.Pulisher.PublisherName,
                                    BookCategoryName = b.BookCategory.Category
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
    }
}