using System.ComponentModel.DataAnnotations;

namespace Product_Management_Service.Models.Product
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class BooksDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}