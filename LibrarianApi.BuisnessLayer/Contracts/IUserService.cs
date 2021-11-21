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
        Task<int> Add(IUserDto user);
        Task<int> Update(IUserDto user, int userId);
        Task<int> Delete(int id);
        Task<int> AddBook(int userId, int bookId);
        Task<int> ReturnBook(int userId, int bookId);
        Task<IUserInfoDto> GetUserInfo(int userId);
        Task<IEnumerable<IUserDto>> FindByFullName(string term);
    }
}
