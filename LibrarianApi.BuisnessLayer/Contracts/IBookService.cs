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
        void Add(IBookExpanDto book);
        void Update(IBookExpanDto book, int bookId);
        void Delete(int bookId);
        IBookExpanDto GetInfoById(int bookId);
        IEnumerable<IBookDto> GetBooklistByUserId(int userId);
        IEnumerable<IBookDto> GetAvalableBooks();
        IEnumerable<IBookDto> FindBookByName(string name);
    }
}
