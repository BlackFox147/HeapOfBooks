using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Model
{
    class Commit
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public DateTime DateСreation { get; set; }
        public DateTime DateLastChange { get; set; }
        public int? DocumentId { get; set; }
        public virtual Document Document { get; set; }
    }
}
