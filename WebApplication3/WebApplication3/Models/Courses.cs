using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Courses
    {
        public int id { get; set; }

        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Hours { get; set; }

        public virtual ICollection<CoursesProfessors> CoursesProfessors { get; set; }
        public virtual ICollection<Sections> Sections { get; set; }
    }
}
