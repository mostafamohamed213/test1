using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Time
    {
        public int id { get; set; }
        public string time { get; set; }

        public virtual ICollection<Sections> Sections { get; set; }
    }
}
