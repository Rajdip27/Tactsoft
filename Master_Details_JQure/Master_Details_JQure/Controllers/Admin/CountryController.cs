using Master_Details_JQure.Models;
using Master_Details_JQure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Master_Details_JQure.Helper;

namespace Master_Details_JQure.Controllers.Admin
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _countryService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddorEdit(long id = 0)
        {
            if(id == 0)
            {
                return View(new Country());
            }
            else
            {
                var data =await _countryService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(long id, Country country)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _countryService.InsertAsync(country);
                }
                else
                {
                    try
                    {
                        await _countryService.UpdateAsync(country);
                    } catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _countryService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", country) });
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var data =await _countryService.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            await _countryService.DeleteAsync(data);
            return Json(new { isValid = true,html=Helper.RenderRazorViewToString(this,"_ViewAll",await _countryService.GetAllAsync())});

        }

    }
}
