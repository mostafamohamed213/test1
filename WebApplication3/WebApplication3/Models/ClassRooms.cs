using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ClassRooms
    {
        public int id { get; set; }
        public string ClassRoom { get; set; }

        public virtual ICollection<Sections> Sections { get; set; }
    }
}
