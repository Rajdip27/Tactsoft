using Master_Details_JQure.Models;
using Master_Details_JQure.Service;
using Microsoft.AspNetCore.Mvc;
using static Master_Details_JQure.Helper;

namespace Master_Details_JQure.Controllers.Admin
{
    public class CityController : Controller
    {

        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        public CityController(ICityService cityService, IStateService stateService)
        {
            _cityService = cityService;
            _stateService = stateService;

        }
        public async Task<IActionResult> Index()
        {
            var data =await _cityService.GetAllAsync(x=>x.State);
            return View(data);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddorEdit(long id = 0)
        {
            if(id == 0)
            {
                ViewData["StateId"] = _stateService.Dropdown();
                return View(new City());
            }
            else
            {
                ViewData["StateId"] = _stateService.Dropdown();
                var data = await _cityService.FindAsync(id);
                return View(data);  
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(long id, City  city)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        await _cityService.InsertAsync(city);
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
                        await _cityService.UpdateAsync(city);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _cityService.GetAllAsync(x=>x.State)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", city) });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var data = await _cityService.FindAsync(id);
                if(data == null)
                {
                    return NotFound();
                }
                await _cityService.DeleteAsync(data);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _cityService.GetAllAsync(x => x.State))});

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
