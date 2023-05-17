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
    public class PurchasesController : Controller
    {
        private readonly IPurchaseSerivce _purchaseSerivce;
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;
        public PurchasesController(IPurchaseSerivce purchaseSerivce,ISupplierService supplierService,IItemService itemService)
        {
            _purchaseSerivce = purchaseSerivce;
            _itemService = itemService;
            _supplierService = supplierService;
        }
        public async Task<IActionResult> Index()
        {
            var Result = await _purchaseSerivce.GetAllAsync();
            return View(Result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var Result = await _purchaseSerivce.FindAsync(id);
            return View(Result);
        }
        public ActionResult Create()
        {
            ViewData["SupplierId"] = _supplierService.Dropdown();
            ViewData["ItemId"] = _itemService.Dropdown();
            Purchase purchase = new Purchase();
            purchase.PurchaseItems.Add(new PurchaseItem() { Id = 1 });
            return View(purchase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase  purchase)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _purchaseSerivce.InsertAsync(purchase);
                    TempData["successAlert"] = "Purchase Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(purchase);
            }
            catch
            {
                return View("Create", purchase);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Result = await _purchaseSerivce.FindAsync(id);
            return View(Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Purchase  purchase)
        {
            try
            {
                var Result = await _purchaseSerivce.FindAsync(purchase.Id);
                if (Result != null)
                {
                    await _purchaseSerivce.UpdateAsync(Result);
                    TempData["successAlert"] = "Purchase Update Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View(purchase);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Result = await _purchaseSerivce.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _purchaseSerivce.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _purchaseSerivce.DeleteAsync(Result);
                TempData["successAlert"] = "Purchase Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
