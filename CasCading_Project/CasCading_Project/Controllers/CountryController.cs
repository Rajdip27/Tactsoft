using CasCading_Project.DatabaseContext;
using CasCading_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasCading_Project.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data =_context.Countries.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            if(ModelState.IsValid)
            {
                await _context.AddAsync(country);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }return View(country);

        }
    }
}
