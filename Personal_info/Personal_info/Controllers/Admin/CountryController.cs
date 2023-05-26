using Microsoft.AspNetCore.Mvc;
using Personal_info.Models;
using Personal_info.Repository;

namespace Personal_info.Controllers.Admin
{
    public class CountryController : Controller
    {
       private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var data=await _countryService.GetAllAsync();
            return View(data);

        }
        [HttpGet]
        public async Task<IActionResult>AddorEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Country());
            }
            else
            {
                var data= await _countryService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(int id ,Country country)
        {
            if(ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        await _countryService.InsertAsync(country);
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
                        await _countryService.UpdateAsync(country);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new {isValid=true,html=Helper.RenderRazorViewToString(this,"_ViewAll",await _countryService.GetAllAsync())});
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this,"AddorEdit",country) });
        }
        [HttpPost]
        public async Task<IActionResult>Delete(long id)
        {
            try
            {
                var data=await _countryService.FindAsync(id);
                await _countryService.DeleteAsync(data);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _countryService.GetAllAsync()) });

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
