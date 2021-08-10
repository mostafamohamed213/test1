using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Days
    {
        public int id { get; set; }
        public string Day { get; set; }

        public virtual ICollection<Sections> Sections { get; set; }
    }
}
