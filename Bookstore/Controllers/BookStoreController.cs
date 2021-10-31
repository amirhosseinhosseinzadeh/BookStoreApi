using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bookstore.Models;
using Bookstore.Services.Books;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookStoreController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public async Task<IList<Book>> GetBooks()
            => await _bookService.GetAsync();

        [HttpPost]
        public async Task AddBook(Book book)
            => await _bookService.CreateAsync(book);

    }
}
