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
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;

        public StatesController(IStateService stateService, ICountryService countryService)
        {
            _stateService = stateService;
            _countryService = countryService;

        }
        public async Task<IActionResult> Index()
        {
            var Result = await _stateService.GetAllAsync(x=>x.Country);
            return View(Result);
        }


        public async Task<IActionResult> Details(int id)
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            var Result = await _stateService.FindAsync(x=>x.Id==id,x=>x.Country);
            return View(Result);
        }


        public ActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State  state)
        {
            try { 
                    await _stateService.InsertAsync(state);
                    TempData["successAlert"] = "Country Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
            }
            catch
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                return View("Create", state);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            var Result = await _stateService.FindAsync(id);
            return View(Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(State  state)
        {
            try
            {
                var Result = await _stateService.FindAsync(state.Id);
                if (Result != null)
                {
                    await _stateService.UpdateAsync(Result);
                    TempData["successAlert"] = "Country Update Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                else
                {
                    ViewData["CountryId"] = _countryService.Dropdown();
                    return NotFound();
                }
            }
            catch
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                return View(state);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            var Result = await _stateService.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _stateService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _stateService.DeleteAsync(Result);
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
