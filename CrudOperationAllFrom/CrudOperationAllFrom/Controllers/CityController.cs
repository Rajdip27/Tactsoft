using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< ActionResult<City>> Index()
        {
            var result = _dbContext.Cities.Include(e => e.State);
            return View(await result.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<City>> Create(City city)
        {
            await _dbContext.AddAsync(city);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
