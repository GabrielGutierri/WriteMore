using Microsoft.AspNetCore.Mvc;
using WriteMore.Domain.Interfaces.Repository;
using WriteMore.Domain.Interfaces.Services;
using WriteMore.Domain.Models;

namespace WriteMoreAPI.Controllers
{
    public class BookController: Controller
    {
        private readonly IService<Book> _bookService;

        public BookController(IService<Book> bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("/api/book")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("/api/book/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetAsync(id);
            return Ok(book);
        }

        [HttpPost("/api/book")]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
        {
            var bookAdded = await _bookService.CreateAsync(book);
            return Ok(bookAdded);
        }

        [HttpPost("/api/book/{id}")]
        public async Task RemoveBook(int id)
        {
            await _bookService.DeleteAsync(id);
        }
    }
}
