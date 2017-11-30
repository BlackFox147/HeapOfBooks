using Code.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class UserContext : DbContext
    {
        public UserContext()
               : base("HeapOfBooksContext")
        { }

        public DbSet<Collection> Collections { get; set; }
    }
}
