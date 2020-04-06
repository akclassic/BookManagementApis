using System;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public partial class Book
    {
        public string Isbn { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int BookCategoryId { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public int PulisherId { get; set; }
        public int Quantity { get; set; }

        public virtual Author Author { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public virtual Publisher Pulisher { get; set; }
    }
}
