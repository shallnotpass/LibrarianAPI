using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.DataAccess
{
    public class Book : BaseEntity
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public BookAccounting BookAccounting { get; set; }
        public int BookAccountingId { get; set; }

        public List<UserCardEntry> UserCardEntries = new List<UserCardEntry>();
    }
}
