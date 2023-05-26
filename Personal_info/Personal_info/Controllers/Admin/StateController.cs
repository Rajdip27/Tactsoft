using Microsoft.AspNetCore.Mvc;
using Personal_info.Models;
using Personal_info.Repository;
using System.Diagnostics.Metrics;

namespace Personal_info.Controllers.Admin
{
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        public StateController(IStateService stateService,ICountryService countryService)
        {
            _stateService = stateService;
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data= await _stateService.GetAllAsync(x=>x.Country);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddorEdit(int id = 0)
        {
            if(id == 0)
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                return View(new State());
            }
            else
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                var data=await _stateService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(int id, State state)
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
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", state) });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var data = await _stateService.FindAsync(id);
                await _stateService.DeleteAsync(data);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _stateService.GetAllAsync(x => x.Country)) });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
