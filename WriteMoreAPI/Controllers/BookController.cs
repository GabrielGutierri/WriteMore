using Microsoft.AspNetCore.Mvc;
using WriteMoreAPI.DAL.Repository;
using WriteMoreAPI.Model;

namespace WriteMoreAPI.Controllers
{
    public class BookController: Controller
    {
        private readonly IRepository<Book> _bookRepository;

        public BookController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("/api/book")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("/api/book/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            return Ok(book);
        }

        [HttpPost("/api/book")]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
        {
            var bookAdded = await _bookRepository.CreateAsync(book);
            return Ok(bookAdded);
        }

        [HttpPost("/api/book/{id}")]
        public async Task RemoveBook(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
