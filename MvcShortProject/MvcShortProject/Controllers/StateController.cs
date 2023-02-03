using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;
using MvcShortProject.Models;

namespace MvcShortProject.Controllers
{
    public class StateController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StateController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _dbContext.States.Include(x=>x.Country).ToListAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(State state)
        {
            try
            {
                if(state != null)
                {
                    await _dbContext.AddAsync(state);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(actionName: nameof(Index));
                }
                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName");
                return  View(state);



            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
