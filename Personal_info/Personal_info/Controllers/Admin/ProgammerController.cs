using Microsoft.AspNetCore.Mvc;
using Personal_info.Models;
using Personal_info.Repository;

namespace Personal_info.Controllers.Admin
{
    public class ProgammerController : Controller
    {
        private readonly IProgammerService _progammerService;
        public ProgammerController(IProgammerService progammerService)
        {
            _progammerService = progammerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var programmerList = _progammerService.ProgrammerList();
            return Json(new { data = programmerList });
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Progammer progammer)
        {
            if(ModelState.IsValid)
            {
                await _progammerService.InsertAsync(progammer);
                return RedirectToAction("Index");

            }
           
            return View(progammer);
        }
    }
}
