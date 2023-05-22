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
        public async Task<IActionResult> AddorEdit(long id=0)
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
                ViewData["ItemId"] = _itemService.Dropdown();
                ViewData["SupplierId"] = _supplierService.Dropdown();
                var data =await _purchaseService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]

    }
}
