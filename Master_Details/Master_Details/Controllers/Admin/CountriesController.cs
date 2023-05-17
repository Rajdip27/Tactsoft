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
    public class CountriesController : Controller
    {
        private readonly ICountryService  _countryService;
        public CountriesController(ICountryService  countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            var Result = await _countryService.GetAllAsync();
            return View(Result);
        }


        public async Task<IActionResult> Details(int id)
        {
            var Result = await _countryService.FindAsync(id);
            return View(Result);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country  country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _countryService.InsertAsync(country);
                    TempData["successAlert"] = "Country Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(country);

            }
            catch
            {
                return View("Create", country);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Result = await _countryService.FindAsync(id);
            return View(Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Country country)
        {
            try
            {
                var Result = await _countryService.FindAsync(country.Id);
                if (Result != null)
                {
                    await _countryService.UpdateAsync(Result);
                    TempData["successAlert"] = "Country Update Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View(country);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Result = await _countryService.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _countryService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _countryService.DeleteAsync(Result);
                TempData["successAlert"] = "Country Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

