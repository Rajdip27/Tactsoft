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
            return View(await _dbContext.Cities.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
            return View();
        }
    }
}
