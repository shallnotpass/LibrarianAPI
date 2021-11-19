using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.BuisnessLayer.Models
{
    public class UserInfoDto : UserDto, IUserInfoDto
    {
        public IEnumerable<IBookDto> Books { get; set; }
    }
    public interface IUserInfoDto : IUserDto
    {
        IEnumerable<IBookDto> Books { get; set; }
    }
    public class UserDto : IUserDto
    {
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
    public interface IUserDto
    {
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
}
