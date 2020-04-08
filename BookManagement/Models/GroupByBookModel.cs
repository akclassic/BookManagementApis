using System.Collections.Generic;

namespace BookManagement.Models
{
    public class GroupByBookModel
    {
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int NumberOfBooks { get; set; }

        public string BookName { get; set; }
        public IEnumerable<SingleBookModel> Books { get; set; }
    }
}
