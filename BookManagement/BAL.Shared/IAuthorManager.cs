using BookManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.BAL.Shared
{
    public interface IAuthorManager
    {
        public Task<IEnumerable<AuthorListModel>> GetAuthorList();
    }
}
