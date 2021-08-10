using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Professors
    {
        public int id { get; set; }
        public string ProfessorName { get; set; }
       
        public int TeachLoad { get; set; }

        public virtual ICollection<CoursesProfessors> CoursesProfessors { get; set; }

        public virtual ICollection<Sections> Sections { get; set; }
    }
}
