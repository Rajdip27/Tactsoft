using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;
using MvcShortProject.Models;

namespace MvcShortProject.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public   IActionResult Index()
        {
            var ct = _dbContext.Cities.Include(x => x.State);
            return View( ct .ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            try
            {
                if (city !=null)
                {
                    await _dbContext.AddAsync(city);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
                return View(city);


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
