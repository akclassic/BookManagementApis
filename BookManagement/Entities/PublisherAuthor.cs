using System;
using System.Collections.Generic;

namespace BookManagement.Entities
{
    public partial class PublisherAuthor
    {
        public int Id { get; set; }
        public int? PublisherId { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
