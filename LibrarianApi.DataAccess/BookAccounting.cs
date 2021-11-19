using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.DataAccess
{
    public class BookAccounting : BaseEntity
    {
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }
    }
}
