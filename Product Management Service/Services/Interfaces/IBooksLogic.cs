using Product_Management_Service.Models.Product;

namespace Product_Management_Service.Services.Interfaces
{
    public interface IBooksLogic
    {
        IEnumerable<Books> GetBooks(int pageNumber, int pageSize);
        Books GetBooksById(int id);
        Books AddBook(BooksDTO book);
        Books UpdateBook(int id, BooksDTO book);
        string DeleteBook(int id);
    }
}
