namespace BookManagement.Models
{
    public class BookListModel
    {
        public string Isbn { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookCategoryName { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string PulisherName { get; set; }
        public int Quantity { get; set; }

    }
}
