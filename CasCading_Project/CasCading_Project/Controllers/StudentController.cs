using CasCading_Project.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace CasCading_Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult GetCountry() 
        {
            var countrys=_context.Countries.ToList();
            return Json(countrys);
        
        }
        public IActionResult GetState(int Id)
        {
            var states=_context.States.Where(f=>f.CountryId==Id).ToList();
            return Json(states);
        }
    }
}
