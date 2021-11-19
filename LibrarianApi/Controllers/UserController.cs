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
        public void Add(UserDto user)
        {
            UserService.Add(user);
        }

        [HttpPost("Update")]
        public void Update(UserDto user, int userId)
        {
            UserService.Update(user, userId);
        }

        [HttpPost("Delete")]
        public void Delete(int id)
        {
            UserService.Delete(id);
        }

        [HttpPost("AddBook")]
        public void AddBook(int userId, int bookId)
        {
            UserService.AddBook(userId, bookId);
        }

        [HttpPost("ReturnBook")]
        public void ReturnBook(int userId, int bookId)
        {
            UserService.ReturnBook(userId, bookId);
        }

        [HttpPost("GetUserInfo")]
        public IUserInfoDto GetUserInfo(int userId)
        {
            return UserService.GetUserInfo(userId);
        }

        [HttpPost("FindByFullname")]
        public IEnumerable<IUserDto> FindByFullname(string term)
        {
            return UserService.FindByFullName(term);
        }
    }
}
