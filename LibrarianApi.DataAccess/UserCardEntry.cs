using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.DataAccess
{
    public class UserCardEntry : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
