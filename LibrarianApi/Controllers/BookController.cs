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
        public async Task<int> Add(BookExpanDto book)
        {
            return await bookService.Add(book);
        }

        [HttpPost("Update")]
        public async Task<int> Update(BookExpanDto book, int bookId)
        {
            return await bookService.Update(book, bookId);
        }

        [HttpPost("Delete")]
        public async Task<int> Delete(int bookId)
        {
            return await bookService.Delete(bookId);
        }

        [HttpPost("GetInfo")]
        public async Task<IBookExpanDto> GetInfoById(int bookId)
        {
            return await bookService.GetInfoById(bookId);
        }

        [HttpPost("GetBooksByUser")]
        public async Task<IEnumerable<IBookDto>> GetBookListByUserId(int userId)
        {
            return await bookService.GetBooklistByUserId(userId);
        }

        [HttpPost("GetAvalableBooks")]
        public async Task<IEnumerable<IBookDto>> GetAvalableBooks()
        {
            return await bookService.GetAvalableBooks();
        }

        [HttpPost("FindBooksByName")]
        public async Task<IEnumerable<IBookDto>> FindBookByName(string name)
        {
            return await bookService.FindBookByName(name);
        }
    }
}
