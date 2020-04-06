using System;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
