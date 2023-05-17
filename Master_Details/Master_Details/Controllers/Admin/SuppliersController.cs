using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service;

namespace Master_Details.Controllers.Admin
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        public SuppliersController(ISupplierService supplierService, ICountryService countryService, IStateService stateService, ICityService cityService)
        {
            _supplierService = supplierService;
            _countryService = countryService;
            _stateService = stateService;
            _cityService = cityService;

        }
        public async Task<IActionResult> Index()
        {
            var Result = await _supplierService.GetAllAsync(x=>x.Country, x => x.City, x => x.State);
            return View(Result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var Result = await _supplierService.FindAsync(x=>x.Id==id, x => x.Country, x => x.City, x => x.State);
            return View(Result);
        }
        public ActionResult Create()
        {
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CountryId"] =_countryService.Dropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier  supplier)
        {
            try
            {
                    await _supplierService.InsertAsync(supplier);
                    TempData["successAlert"] = "Supplier Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                
            }
            catch
            {
                ViewData["CityId"] = _cityService.Dropdown();
                ViewData["StateId"] = _stateService.Dropdown();
                ViewData["CountryId"] = _countryService.Dropdown();
                return View("Create", supplier);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            var Result = await _supplierService.FindAsync(x => x.Id == id, x => x.Country, x => x.City, x => x.State);
            return View(Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier  supplier)
        {
            try
            {
                await _supplierService.UpdateAsync(supplier);
                    TempData["successAlert"] = "Supplier Update Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
               
            }
            catch
            {
                ViewData["CityId"] = _cityService.Dropdown();
                ViewData["StateId"] = _stateService.Dropdown();
                ViewData["CountryId"] = _countryService.Dropdown();
                return View(supplier);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            var Result = await _supplierService.FindAsync(x => x.Id == id, x => x.Country, x => x.City, x => x.State);
            return View(Result);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _supplierService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _supplierService.DeleteAsync(Result);
                TempData["successAlert"] = "Supplier Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
