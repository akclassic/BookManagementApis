using System.Collections.Generic;

namespace BookManagement.Models
{
    public class PublisherAuthorBookModel
    {
        public SinglePublisherModel Publisher { get; set; }

        public IEnumerable<AuthorBookModel> AuthorBook { get; set; }
    }

    public class AuthorBookModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public IEnumerable<SingleBookModel> Books { get; set; }
    }

    
}
