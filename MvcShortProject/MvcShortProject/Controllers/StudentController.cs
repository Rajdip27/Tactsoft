using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;
using MvcShortProject.Models;

namespace MvcShortProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment _environment;
        public StudentController(ApplicationDbContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _context.Students.Include(x=>x.Deperment).Include(x=>x.Country).Include(c=>c.City).Include(s=>s.State).ToListAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "CountryName");
            ViewData["DepermentId"] = new SelectList(_context.Deperments, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student,IFormFile pictureFile)
        {
            
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        student.Picture = $"{pictureFile.FileName}";
                    }
                    await _context.AddAsync(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

                }
                ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityName");
                ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "CountryName");
                ViewData["DepermentId"] = new SelectList(_context.Deperments, "Id", "Name");
                ViewData["StateId"] = new SelectList(_context.States, "Id", "StateName");
                return View(student);

          
        }
        
    }
}
