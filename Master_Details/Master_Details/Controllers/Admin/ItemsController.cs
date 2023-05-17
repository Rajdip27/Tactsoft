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
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            var Result = await _itemService.GetAllAsync();
            return View(Result);
        }


        public async Task<IActionResult> Details(int id)
        {
            var Result = await _itemService.FindAsync(id);
            return View(Result);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item  item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _itemService.InsertAsync(item);
                    TempData["successAlert"] = "Item Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(item);

            }
            catch
            {
                return View("Create", item);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Result = await _itemService.FindAsync(id);
            return View(Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Country country)
        {
            try
            {
                var Result = await _itemService.FindAsync(country.Id);
                if (Result != null)
                {
                    await _itemService.UpdateAsync(Result);
                    TempData["successAlert"] = "Item Update Successfull.";
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
            var Result = await _itemService.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _itemService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _itemService.DeleteAsync(Result);
                TempData["successAlert"] = "Item Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
