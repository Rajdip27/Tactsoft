using CasCading_Project.DatabaseContext;
using CasCading_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CasCading_Project.Controllers
{
    public class StateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var data= _context.States.Include(c=>c.Country).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var data = _context.Countries.ToList();
            ViewData["Country"] = data.Select(data => new SelectListItem { Text = data.CountryName, Value = data.Id.ToString() });
            return View();
        }
        public async Task<IActionResult> Create(State state)
        {
            if(ModelState.IsValid)
            {
              await  _context.AddAsync(state);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
