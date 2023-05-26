using Microsoft.AspNetCore.Mvc;
using Personal_info.Models;
using Personal_info.Repository;

namespace Personal_info.Controllers.Admin
{
    public class EmployeeController : Controller
    {
       private readonly IEmployeeService _employeeService;
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        public EmployeeController(IEmployeeService employeeService, ICityService cityService, IStateService stateService, ICountryService countryService)
        {
            _employeeService = employeeService;
            _cityService = cityService;
            _stateService = stateService;
            _countryService = countryService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data= await _employeeService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                ViewData["StateId"] = _stateService.Dropdown();
                ViewData["CityId"] = _cityService.Dropdown();
                return View(new Employee());
            }
            else
            {
                ViewData["CountryId"] = _countryService.Dropdown();
                ViewData["StateId"] = _stateService.Dropdown();
                ViewData["CityId"] = _cityService.Dropdown();
                var data = await _employeeService.FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(int id, Employee  employee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        if (pictureFile != null && pictureFile.Length > 0)
                        {
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Employee", pictureFile.FileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                pictureFile.CopyTo(stream);
                            }
                            employee.Picture = $"{pictureFile.FileName}";
                        }

                        await _employeeService.InsertAsync(employee);
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
                        if (pictureFile != null && pictureFile.Length > 0)
                        {
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Employee", pictureFile.FileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                pictureFile.CopyTo(stream);
                            }
                            employee.Picture = $"{pictureFile.FileName}";
                        }
                        await _employeeService.UpdateAsync(employee);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _employeeService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", employee) });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var data = await _employeeService.FindAsync(id);
                await _employeeService.DeleteAsync(data);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _employeeService.GetAllAsync()) });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
