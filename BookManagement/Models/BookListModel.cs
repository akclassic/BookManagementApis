namespace BookManagement.Models
{
    public class BookListModel
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

    }
}
