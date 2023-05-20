using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ssController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
