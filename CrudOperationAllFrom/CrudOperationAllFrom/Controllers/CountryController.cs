using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< ActionResult<Country>> Index()
        {
            return View(await _dbContext.Countries.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Country>> Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(country);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(actionName:nameof(Index));
                }
                return View(country);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
