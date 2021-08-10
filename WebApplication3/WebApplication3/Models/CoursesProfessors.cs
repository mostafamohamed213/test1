using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CoursesProfessors
    {
        public int id { get; set; }
        public int Course { get; set; }

        public int Professor { get; set; }

        [ForeignKey("Course")]
        public virtual Courses Courses { get; set; }


        [ForeignKey("Professor")]
        public virtual Professors Professors{ get; set; }
    }
}
