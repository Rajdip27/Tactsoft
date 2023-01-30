using Microsoft.AspNetCore.Mvc;
using Students_Mangmaent_With_Repostory_patten.Services;

namespace Students_Mangmaent_With_Repostory_patten.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task< IActionResult> Index()
        {
            return View( await _customer.GetAll());
        }
    }
}
