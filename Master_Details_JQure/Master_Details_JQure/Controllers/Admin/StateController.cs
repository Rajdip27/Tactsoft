using Master_Details_JQure.Models;
using Master_Details_JQure.Service;
using Microsoft.AspNetCore.Mvc;
using static Master_Details_JQure.Helper;

namespace Master_Details_JQure.Controllers.Admin
{
    public class StateController : Controller
    {
       private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        public StateController(IStateService stateService, ICountryService countryService)
        {
            _stateService = stateService;
            _countryService = countryService;

        }
        public async Task<IActionResult> Index()
        {
            var data =await _stateService.GetAllAsync(x=>x.Country);
            return View(data);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddorEdit(long id=0)
        {
            if(id == 0)
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                return View(new State());
            }
            else
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                var data= await _stateService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(long id,State state)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        await _stateService.InsertAsync(state);
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
                        await _stateService.UpdateAsync(state);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _stateService.GetAllAsync(x=>x.Country)) });
            }
            return Json(new { isVaild = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", state) });
           
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var data = await _stateService.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            await _stateService.DeleteAsync(data);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _stateService.GetAllAsync(x=>x.Country)) });

        }
    }
}
