using Master_Details_JQure.Models;
using Master_Details_JQure.Service;
using Microsoft.AspNetCore.Mvc;
using static Master_Details_JQure.Helper;

namespace Master_Details_JQure.Controllers.Admin
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;
        public PurchaseController(IPurchaseService purchaseService, ISupplierService supplierService, IItemService itemService)
        {
            _purchaseService = purchaseService;
            _supplierService = supplierService;
            _itemService = itemService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data= await _purchaseService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        [NoDirectAccess]
        public IActionResult AddorEdit(long id=0)
        {
            if (id == 0)
            {
                ViewData["ItemId"] = _itemService.Dropdown();
                ViewData["SupplierId"] = _supplierService.Dropdown();
                Purchase purchase=new Purchase();
                purchase.PurchaseItems.Add(new PurchaseItem() { Id = 1 });
              
                return View(purchase);
            }
            else
            {
                Purchase purchase = _purchaseService.GetItems(id);

                ViewData["SupplierId"] = _supplierService.Dropdown();
                ViewData["ItemId"] = _itemService.Dropdown();

                return View(purchase);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddorEdit(long id,Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        if (purchase.SupplierId == 0)
                        {
                            return View(purchase);
                        }

                        purchase.PurchaseItems.RemoveAll(x => x.Quantity == 0);
                        await _purchaseService.InsertAsync(purchase);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        purchase.PurchaseItems.RemoveAll(x => x.Quantity == 0);
                        await _purchaseService.UpdateRangeAsync(purchase);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new { isVaild = true, html = Helper.RenderRazorViewToString(this, "_Viewall", await _purchaseService.GetAllAsync()) });
            }
            return Json(new { isVaild = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", purchase) });
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id,Purchase purchase)
        {

            purchase.PurchaseItems.RemoveAll(x => x.Quantity == 0);
            var data=  _purchaseService.GetItems(id);
            await _purchaseService.DeleteRangeAsync(data);
            return Json(new { isVaild = true, html = Helper.RenderRazorViewToString(this, "_Viewall", await _purchaseService.GetAllAsync()) });



        }

    }
}
