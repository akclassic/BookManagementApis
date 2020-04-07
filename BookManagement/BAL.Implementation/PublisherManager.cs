using BookManagement.BAL.Shared;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Implementation
{
    public class PublisherManager : IPublisherManager
    {
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
