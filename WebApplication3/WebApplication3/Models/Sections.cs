using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Sections
    {
        public int id { get; set; }
        public int SectionNumber { get; set; }

        public int Course { get; set; }

        public int Professor { get; set; }

        public int ClassRoom { get; set; }

        public int Day { get; set; }

        public int time { get; set; }

  

        [ForeignKey("Course")]
        public virtual Courses Courses { get; set; }

        [ForeignKey("Professor")]
        public virtual Professors Professors { get; set; }

        [ForeignKey("ClassRoom")]
        public virtual ClassRooms ClassRooms { get; set; }

        [ForeignKey("Day")]
        public virtual Days Days { get; set; }

        [ForeignKey("time")]
        public virtual Time Time  { get; set; }
    }
}
