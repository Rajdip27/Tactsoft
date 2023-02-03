using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;
using MvcShortProject.Models;

namespace MvcShortProject.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _dbContext.Countries.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.Countries.AddAsync(country);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(country);
                

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
