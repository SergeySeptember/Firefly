using Product_Management_Service.Models.Product;
using Product_Management_Service.Services.Interfaces;

namespace Product_Management_Service.Services.BooksLogic
{
    public class BooksLogic : IBooksLogic
    {
        private readonly IRepository<Books> _booksRepository;

        public BooksLogic(IRepository<Books> booksTepository) => _booksRepository = booksTepository;

        public IEnumerable<Books> GetBooks(int pageNumber, int pageSize)
        {
            var listOfBooks = _booksRepository.GetAllBooks(pageNumber, pageSize);
            return listOfBooks;
        }

        public Books GetBooksById(int id)
        {
            var book = _booksRepository.GetBookById(id);
            return book;
        }

        public Books AddBook(BooksDTO book)
        {
            _booksRepository.AddBook(book);
            var newBook = _booksRepository.ReturnCreatedBook(book);
            return newBook;
        }

        public Books UpdateBook(int id, BooksDTO book)
        {
            _booksRepository.UpdateBook(id, book);
            var updatedBook = _booksRepository.GetBookById(id);
            return updatedBook;
        }
        public string DeleteBook(int id)
        {
            string response = _booksRepository.RemoveBook(id);
            return response;
        }
    }
}
