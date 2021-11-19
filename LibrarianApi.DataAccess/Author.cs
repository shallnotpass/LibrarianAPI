using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.DataAccess
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
}
