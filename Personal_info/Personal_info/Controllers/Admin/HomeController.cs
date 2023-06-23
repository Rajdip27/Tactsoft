using Microsoft.AspNetCore.Mvc;
using Personal_info.Repository;

namespace Personal_info.Controllers.Admin
{
    public class HomeController : Controller
    {
        private readonly ICountryService _countryService;

        public HomeController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            var data=_countryService.GetAllAsync();
            ViewBag["data"] = data;
            return View();
        }
    }
}
