using Master_Details_JQure.Models;
using Master_Details_JQure.Service;
using Microsoft.AspNetCore.Mvc;
using static Master_Details_JQure.Helper;

namespace Master_Details_JQure.Controllers.Admin
{
    public class ItemController : Controller
    {
       private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _itemService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddorEdit(long id = 0)
        {
            if (id == 0)
            {
                return View(new Item());
            }
            else
            {
                var data =await _itemService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(long id,Item item)
        {
            if(ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        await _itemService.InsertAsync(item);
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
                        await _itemService.UpdateAsync(item);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new {isValid=true,html=Helper.RenderRazorViewToString(this,"_ViewAll",await _itemService.GetAllAsync())});
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this,"AddorEdit", item) });
            
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var data = await _itemService.FindAsync(id);
                if(data == null)
                {
                    return NotFound();
                }
                await _itemService.DeleteAsync(data);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _itemService.GetAllAsync()) });

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
