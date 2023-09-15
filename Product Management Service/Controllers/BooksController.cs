using Microsoft.AspNetCore.Mvc;
using Product_Management_Service.Models.Product;
using Product_Management_Service.Services.BooksLogic;

namespace Product_Management_Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksLogic _booksLogic;

        public BooksController(BooksLogic booksLogic)
        {
            _booksLogic = booksLogic;
        }

        /// <summary>
        /// Get a paginated list of books.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of books per page.</param>
        /// <returns>A paginated list of books.</returns>
        /// <response code="200">Returns the paginated list of books.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Books>), 200)]
        [Produces("application/json")]
        public IEnumerable<Books> Get(int pageNumber, int pageSize)
        {
            var listOfBooks = _booksLogic.GetBooks(pageNumber, pageSize);
            return listOfBooks;
        }

        /// <summary>
        /// Get a book by ID
        /// </summary>
        /// <param name="Book ID">Book ID</param>
        /// <returns>Book by ID</returns>
        /// <response code="200">Returns the book by ID</response>
        /// <response code="404">Book not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Books), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [Produces("application/json")]
        public IActionResult Get(int id)
        {
            var book = _booksLogic.GetBooksById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound("Book not found");
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="book">Book data to create.</param>
        /// <returns>Created new book with ID</returns>
        /// <remarks>
        /// Sample request:
        ///     POST /Books
        ///     {
        ///         "title": "War and Peace",
        ///         "author": "Leo Tolstoy",
        ///         "genre": "Historical Novel",
        ///         "price": 500,
        ///         "quantity": 10
        ///     }
        /// </remarks>
        /// <response code="201">Returns the created book with ID</response>
        /// <response code="400">Some data is invalid</response>
        [ProducesResponseType(typeof(Books), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [Produces("application/json", "text/plain")]
        [HttpPost]
        public IActionResult Post([FromBody] BooksDTO book)
        {
            var newBook = _booksLogic.AddBook(book);
            if (newBook != null)
            {
                return Created($"https://localhost:5220/users/{newBook.Id}", newBook);
            }
            return BadRequest();

        }
        /// <summary>
        /// Update user data by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="body">User data to update.</param>
        /// <returns>Changed user data with id and without password</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /users/{id}
        ///     {
        ///        "userName": "Name",
        ///        "email": "example@mail.ru",
        ///        "password": "Example2)",
        ///        "age":25,
        ///        "location": "City"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated user data with ID and without the password</response>
        /// <response code="400">Some data is invalid</response>
        [ProducesResponseType(typeof(Books), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [Produces("application/json")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BooksDTO book)
        {
            var updatedBook = _booksLogic.UpdateBook(id, book);
            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _booksLogic.DeleteBook(id);
        }
    }
}
