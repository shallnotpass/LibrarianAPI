using LibrarianApi.BuisnessLayer.Contracts;
using LibrarianApi.BuisnessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarianApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpPost("Add")]
        public void Add(BookExpanDto book)
        {
            bookService.Add(book);
        }

        [HttpPost("Update")]
        public void Update(BookExpanDto book, int bookId)
        {
            bookService.Update(book, bookId);
        }

        [HttpPost("Delete")]
        public void Delete(int bookId)
        {
            bookService.Delete(bookId);
        }

        [HttpPost("GetInfo")]
        public IBookExpanDto GetInfoById(int bookId)
        {
            return bookService.GetInfoById(bookId);
        }

        [HttpPost("GetBooksByUser")]
        public IEnumerable<IBookDto> GetBookListByUserId(int userId)
        {
            return bookService.GetBooklistByUserId(userId);
        }

        [HttpPost("GetAvalableBooks")]
        public IEnumerable<IBookDto> GetAvalableBooks()
        {
            return bookService.GetAvalableBooks();
        }

        [HttpPost("FindBooksByName")]
        public IEnumerable<IBookDto> FindBookByName(string name)
        {
            return bookService.FindBookByName(name);
        }
    }
}
