using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;

namespace MvcShortProject.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _dbContext.Cities.Include(x=>x.State).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
            return View();
        }

    }
}
