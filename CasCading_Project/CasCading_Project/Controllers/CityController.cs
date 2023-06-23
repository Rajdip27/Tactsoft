using CasCading_Project.DatabaseContext;
using CasCading_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CasCading_Project.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data =_context.Cities.Include(s=>s.State).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var data = _context.States.ToList();
            ViewData["State"]= data.Select(x => new SelectListItem { Text = x.StateName, Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if(ModelState.IsValid)
            {
                await _context.AddAsync(city);
               await _context.SaveChangesAsync();
                return RedirectToAction("Index");


            }
            return View();

        }
    }
}
