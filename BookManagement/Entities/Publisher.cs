using System;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string PublisherName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
