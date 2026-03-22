using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("v1/books")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _service;

        public BooksController(ILibraryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _service.AddBookAsync(book);
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _service.GetBooksAsync();
            return Ok(books);
        }
    }
}