using System;
using System.Collections.Generic;

namespace BookManagement.Entities
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
            PublisherAuthor = new HashSet<PublisherAuthor>();
        }

        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<PublisherAuthor> PublisherAuthor { get; set; }
    }
}
