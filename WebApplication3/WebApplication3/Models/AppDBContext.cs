using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<ClassRooms> ClassRooms { get; set; }

        public DbSet<Professors> Professors { get; set; }

        public DbSet<Days> Days { get; set; }

        public DbSet<Time> Times { get; set; }

        public DbSet<Sections> Sections { get; set; }
        public DbSet<CoursesProfessors> CoursesProfessors { get; set; }
       

    }

}
