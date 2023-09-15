using Microsoft.EntityFrameworkCore;
using Product_Management_Service.Models.Product;
using Product_Management_Service.Services.Interfaces;

namespace Product_Management_Service.Services.DataBase
{
    public class BooksRepository : IRepository<Books>
    {

        private readonly DataBaseContext _context;

        public BooksRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Books> GetAllBooks(int pageNumber, int pageSize)
        {
            var books = _context.Books.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return books;
        }

        public Books GetBookById(int id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        public void AddBook(BooksDTO book)
        {
            var bookToAdd = new Books
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price,
                Quantity = book.Quantity
            };

            _context.Books.Add(bookToAdd);
            _context.SaveChanges();
        }

        public void UpdateBook(int id, BooksDTO book)
        {
            var updateBook = _context.Books.FirstOrDefault(a => a.Id == id);
            
            if (updateBook != null) 
            {
                updateBook.Title = book.Title;
                updateBook.Author = book.Author;
                updateBook.Genre = book.Genre;
                updateBook.Price = book.Price;
                updateBook.Quantity = book.Quantity;
                _context.SaveChanges();
            }

        }

        public Books ReturnCreatedBook(BooksDTO book)
        {
            var newBook = _context.Books.AsNoTracking().FirstOrDefault(a => a.Title == book.Title && a.Author == book.Author);
            return newBook;
        }

        public void RemoveBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
