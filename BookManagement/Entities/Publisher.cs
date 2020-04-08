using System;
using System.Collections.Generic;

namespace BookManagement.Entities
{
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
            PublisherAuthor = new HashSet<PublisherAuthor>();
        }

        public int Id { get; set; }
        public string PublisherName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<PublisherAuthor> PublisherAuthor { get; set; }
    }
}
