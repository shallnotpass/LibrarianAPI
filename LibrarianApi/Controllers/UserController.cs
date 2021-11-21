using LibrarianApi.BuisnessLayer.Contracts;
using LibrarianApi.BuisnessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarianApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; set; }
        public UserController(IUserService UserService) 
        {
            this.UserService = UserService ?? throw new ArgumentNullException();
        }
        [HttpPost("Add")]
        public async Task<int> Add(UserDto user)
        {
            return await UserService.Add(user);
        }

        [HttpPost("Update")]
        public async Task<int> Update(UserDto user, int userId)
        {
            return await UserService.Update(user, userId);
        }

        [HttpPost("Delete")]
        public async Task<int> Delete(int id)
        {
            return await UserService.Delete(id);
        }

        [HttpPost("AddBook")]
        public async Task<int> AddBook(int userId, int bookId)
        {
            return await UserService.AddBook(userId, bookId);
        }

        [HttpPost("ReturnBook")]
        public async Task<int> ReturnBook(int userId, int bookId)
        {
            return await UserService.ReturnBook(userId, bookId);
        }

        [HttpPost("GetUserInfo")]
        public async Task <IUserInfoDto> GetUserInfo(int userId)
        {
            return await UserService.GetUserInfo(userId);
        }

        [HttpPost("FindByFullname")]
        public async Task <IEnumerable<IUserDto>> FindByFullname(string term)
        {
            return await UserService.FindByFullName(term);
        }
    }
}
