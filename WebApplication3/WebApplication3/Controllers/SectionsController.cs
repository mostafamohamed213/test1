using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SectionsController : Controller
    {
        private readonly AppDBContext _context;

        public SectionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Sections.Include(s => s.ClassRooms).Include(s => s.Courses).Include(s => s.Days).Include(s => s.Professors).Include(s => s.Time);
            return View(await appDBContext.ToListAsync());
        }

  
        public IActionResult Create()
        {
            ViewData["ClassRoom"] = new SelectList(_context.ClassRooms, "id", "ClassRoom");
            ViewData["Course"] = new SelectList(_context.Courses, "id", "CourseName");
            ViewData["Day"] = new SelectList(_context.Days, "id", "Day");
            ViewData["Professor"] = new SelectList(_context.Professors, "id", "ProfessorName");
            ViewData["time"] = new SelectList(_context.Times, "id", "time");
            return View();
        }

        public JsonResult LoadProfessors(int Courseid)
        {
            List<Professors> data = new List<Professors>();

            var c = _context.Courses.Where(a => a.id == Courseid);
           data = _context.CoursesProfessors.Where(a => a.Course == Courseid).Select(a=>a.Professors).ToList();
         

            return Json(data);
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,SectionNumber,Course,Professor,ClassRoom,Day,time")] Sections sections)
        {
            Sections avilableclassroom = _context.Sections.FirstOrDefault(a => a.ClassRoom == sections.ClassRoom && a.Day == sections.Day && a.time == sections.time);
            int professorTeachLoad = _context.Professors.Find(sections.Professor).TeachLoad;
            int professorSectionCount = _context.Sections.Where(a => a.Professor == sections.Professor).Count();

            if (avilableclassroom == null && professorSectionCount < professorTeachLoad)
            {

                if (ModelState.IsValid)
                {

                    _context.Add(sections);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {

                ViewData["ClassRoom"] = new SelectList(_context.ClassRooms, "id", "ClassRoom", sections.ClassRoom);
                ViewData["Course"] = new SelectList(_context.Courses, "id", "CourseName", sections.Course);
                ViewData["Day"] = new SelectList(_context.Days, "id", "Day", sections.Day);
                ViewData["Professor"] = new SelectList(_context.Professors, "id", "ProfessorName", sections.Professor);
                ViewData["time"] = new SelectList(_context.Times, "id", "time", sections.time);
                if (avilableclassroom != null)
                {
                    ModelState.AddModelError(string.Empty, "This Class room is not available at this time of the day , because another section will be present at this time of the day");
                }
                if (professorSectionCount >= professorTeachLoad)
                {
                    ModelState.AddModelError(string.Empty, "Cann't Assign this Section to this Professor because this Proffessor Exceeding Teaching Load");
                }
                return View(sections);
            }
            ViewData["ClassRoom"] = new SelectList(_context.ClassRooms, "id", "ClassRoom", sections.ClassRoom);
            ViewData["Course"] = new SelectList(_context.Courses, "id", "CourseName", sections.Course);
            ViewData["Day"] = new SelectList(_context.Days, "id", "Day", sections.Day);
            ViewData["Professor"] = new SelectList(_context.Professors, "id", "ProfessorName", sections.Professor);
            ViewData["time"] = new SelectList(_context.Times, "id", "time", sections.time);

            return View(sections);
        }

    
    }
}
