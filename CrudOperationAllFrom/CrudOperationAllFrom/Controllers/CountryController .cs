using CrudOperation.Models;
using CrudOperationAllFrom.Service;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationAllFrom.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountry  _country;
        public CountryController(ICountry country)
        {
            _country = country;
        }
        [HttpGet]
        public async Task< ActionResult<Country>> Index()
        {
            return View(await _country.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Country>> Create(Country city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _country.Create(city);
                    await _country.Save();
                    return RedirectToAction("Index");
                }

                return View(city);

               

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
