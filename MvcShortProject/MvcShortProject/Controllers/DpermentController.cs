using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;
using MvcShortProject.Models;

namespace MvcShortProject.Controllers
{
    public class DpermentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DpermentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _context.Deperments.ToListAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Deperment deperment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(deperment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(deperment);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
