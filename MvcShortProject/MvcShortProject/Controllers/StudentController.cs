using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;

namespace MvcShortProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _context.Students.Include(x=>x.Deperment).Include(x=>x.Country).Include(c=>c.City).Include(s=>s.State).ToListAsync();
            return View(Result);
        }
        
    }
}
