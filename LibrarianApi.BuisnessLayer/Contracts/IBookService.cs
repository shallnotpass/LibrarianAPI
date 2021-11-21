using LibrarianApi.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.BuisnessLayer.Contracts
{
    public interface IBookService
    {
        Task<int> Add(IBookExpanDto book);
        Task<int> Update(IBookExpanDto book, int bookId);
        Task<int> Delete(int bookId);
        Task<IBookExpanDto> GetInfoById(int bookId);
        Task<IEnumerable<IBookDto>> GetBooklistByUserId(int userId);
        Task<IEnumerable<IBookDto>> GetAvalableBooks();
        Task<IEnumerable<IBookDto>> FindBookByName(string name);
    }
}
