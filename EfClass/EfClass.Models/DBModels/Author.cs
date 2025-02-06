using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Models.DBModels
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string  AuthorName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
