using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.DataAccess
{
    public class BaseEntity : IKey, IDeleted
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public interface IKey
    {
        int Id { get; set; }
    }
    public interface IDeleted
    {
        bool IsDeleted { get; set; }
    }
}
