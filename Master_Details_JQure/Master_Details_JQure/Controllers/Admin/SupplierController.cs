using Master_Details_JQure.Models;
using Master_Details_JQure.Service;
using Microsoft.AspNetCore.Mvc;
using static Master_Details_JQure.Helper;

namespace Master_Details_JQure.Controllers.Admin
{
    public class SupplierController : Controller
    {
       private readonly ISupplierService _supplierService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        public SupplierController(ISupplierService supplierService, ICountryService countryService, ICityService cityService, IStateService stateService)
        {
            _supplierService = supplierService;
            _countryService = countryService;
            _cityService = cityService;
            _stateService = stateService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data= await _supplierService.GetAllAsync(x => x.Country, x => x.City, x => x.State);
            return View(data);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddorEdit(long id=0)
        {
            if (id == 0)
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                ViewData["StateId"] = _stateService.Dropdown();
                ViewData["CityId"] = _cityService.Dropdown();

                return View( new Supplier());
            }
            else
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                ViewData["StateId"] = _stateService.Dropdown();
                ViewData["CityId"] = _cityService.Dropdown();
                var data= await _supplierService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(long id, Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                   
                        await _supplierService.InsertAsync(supplier);
                   
                }
                else
                {
                        await _supplierService.UpdateAsync(supplier);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _supplierService.GetAllAsync(x => x.Country, x => x.City, x => x.State)) });
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", supplier) });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var data = await _supplierService.FindAsync(id);
                if (data == null)
                {
                    return NotFound();
                }
                await _supplierService.DeleteAsync(data);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _supplierService.GetAllAsync(x => x.State, x => x.City, x => x.Country)) });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
