using Product_Management_Service.Models.Product;
using Product_Management_Service.Services.Interfaces;
using System.Text;

namespace Product_Management_Service.Services
{
    public class Validation
    {
        private readonly IRepository<Books> _booksRepository;
        
        public Validation(IRepository<Books> booksTepository) => _booksRepository = booksTepository;
        
        public readonly string errorTitle = "Field \"Title\" is empty or contains less than 3 characters";
        public readonly string errorAuthor = "Field \"Author\" is empty or contains less than 4 characters";
        public readonly string errorGenre = "Field \"Genre\" is empty or contains less than 5 characters";
        public readonly string errorPrice = "The \"Price\" field cannot contain the number 0 or less";
        public readonly string errorQuantity = "The \"Quantity\" field cannot contain the number 0 or less";
        public readonly string errorBookExist = "The book doesn't exist";

        public string ValidationData(BooksDTO book)
        {
            string validInfo = string.Empty;

            if (string.IsNullOrWhiteSpace(book.Title) || book.Title.Length < 3)
                validInfo += errorTitle;

            if (string.IsNullOrWhiteSpace(book.Author) || book.Author.Length < 4)
                validInfo += errorAuthor;

            if (string.IsNullOrWhiteSpace(book.Genre) || book.Genre.Length < 5)
                validInfo += errorGenre;

            if (book.Price <= 0)
                validInfo += errorPrice;

            if (book.Quantity <= 0)
                validInfo += errorQuantity;

            string resultOfValid = validInfo.ToString();

            if (string.IsNullOrWhiteSpace(resultOfValid))
                return "correct";
            else
                return resultOfValid.ToString();
        }

        public string ValidationData(int id, BooksDTO book)
        {
            StringBuilder validInfo = new();

            var isBookExist = _booksRepository.GetBookById(id);

            if (isBookExist == null)
                return errorBookExist;

            if (string.IsNullOrWhiteSpace(book.Title) || book.Title.Length < 3)
                validInfo.Append(errorTitle);

            if (string.IsNullOrWhiteSpace(book.Author) || book.Author.Length < 4)
                validInfo.Append(errorAuthor);

            if (string.IsNullOrWhiteSpace(book.Genre) || book.Genre.Length < 5)
                validInfo.Append(errorGenre);

            if (book.Price <= 0)
                validInfo.Append(errorPrice);

            if (book.Quantity <= 0)
                validInfo.Append(errorQuantity);

            string resultOfValid = validInfo.ToString();

            if (string.IsNullOrWhiteSpace(resultOfValid))
                return "correct";
            else
                return resultOfValid.ToString();
        }
    }
}
