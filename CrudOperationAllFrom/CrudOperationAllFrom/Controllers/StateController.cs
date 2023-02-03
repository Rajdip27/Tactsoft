using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Controllers
{
    public class StateController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StateController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task< ActionResult<State>> Index()
        {
            var result =  _dbContext.States.Include(e => e.Country);
            return View(await result.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(State state)
        {
           
                    await _dbContext.AddAsync(state);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
               

            
        }
    }
}
