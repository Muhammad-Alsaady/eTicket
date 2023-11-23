using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Producer: Base
    {
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
