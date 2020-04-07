using BookManagement.BAL.Shared;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Implementation
{
    public class AuthorManager : IAuthorManager
    {
        public async Task<IEnumerable<AuthorListModel>> GetAuthorList()
        {
            using (var context = new BookManagementContext())
            {
                var authors = await context.Author
                                .Select(a => new AuthorListModel()
                                {
                                    AuthorId= a.Id,
                                    AuthorName = a.AuthorName,
                                    AuthorEmail = a.Email
                                }).ToListAsync();

                return authors;
            }
        }
    }
}
