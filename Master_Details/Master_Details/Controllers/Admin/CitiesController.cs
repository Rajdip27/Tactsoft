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
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        public CitiesController(ICityService cityService, IStateService stateService)
        {
            _cityService = cityService;
            _stateService = stateService;

        }
        public async Task<IActionResult> Index()
        {
            var Result = await _cityService.GetAllAsync(x=>x.State);
            return View(Result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var Result = await _cityService.FindAsync(x=>x.Id==id,x=>x.State);
            return View(Result);
        }
        public ActionResult Create()
        {
            ViewData["StateId"] = _stateService.Dropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City  city)
        {
            try
            {
                    await _cityService.InsertAsync(city);
                    TempData["successAlert"] = "Country Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
            }
            catch

            {
                ViewData["StateId"] = _stateService.Dropdown();
                return View("Create", city);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewData["StateId"] = _stateService.Dropdown();
            var Result = await _cityService.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(City  city)
        {
            try
            {
                var Result = await _cityService.FindAsync(city.Id);
                if (Result != null)
                {
                    await _cityService.UpdateAsync(Result);
                    TempData["successAlert"] = "Country Update Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                else
                {
                    ViewData["StateId"] = _stateService.Dropdown();
                    return NotFound();
                }
            }
            catch
            {
                ViewData["StateId"] = _stateService.Dropdown();
                return View(city);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewData["StateId"] = _stateService.Dropdown();
            var Result = await _cityService.FindAsync(x=>x.Id==id,x=>x.State);
            return View(Result);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _cityService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _cityService.DeleteAsync(Result);
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
