using Product_Management_Service.Models.Product;

namespace Product_Management_Service.Services.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllBooks(int pageNumber, int pageSize);
        TEntity GetBookById(int id);
        void AddBook(BooksDTO book);
        void UpdateBook(int id, BooksDTO book);
        Books ReturnCreatedBook(BooksDTO book);
        void RemoveBook(int id);
    }
}
