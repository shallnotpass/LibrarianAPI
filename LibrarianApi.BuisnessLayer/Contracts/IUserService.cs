using LibrarianApi.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.BuisnessLayer.Contracts
{
    public interface IUserService
    {
        void Add(IUserDto user);
        void Update(IUserDto user, int userId);
        void Delete(int id);
        void AddBook(int userId, int bookId);
        void ReturnBook(int userId, int bookId);
        IUserInfoDto GetUserInfo(int userId);
        IEnumerable<IUserDto> FindByFullName(string term);
    }
}
