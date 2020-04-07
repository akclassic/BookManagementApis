using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Shared
{
    public interface IPublisherManager
    {
        public Task<IEnumerable<PublisherListModel>> GetPublisherList();
    }
}
