using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CrudOperationAllFrom.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly  IHostEnvironment _environment;
        public EmployeeController(ApplicationDbContext dbContext, IHostEnvironment environment)
        {
          
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task< ActionResult <Employee>> Index()
        {
            var appDbContext = _dbContext.Employees.Include(e => e.City).Include(e => e.Country).Include(e => e.State);
            return View(await appDbContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["CityId"] = new SelectList(_dbContext.Cities, "Id", "CityName");
            ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName");
            //ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee,IFormFile pictureFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwroote/images", pictureFile.Name);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    await _dbContext.AddAsync(employee);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName",employee.Country);
                ViewData["CityId"] = new SelectList(_dbContext.Cities, "Id", "CityName",employee.City);

                ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName",employee.State);

                return View(employee);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public JsonResult GetStatesByCountryId(int countryId)
        {
            List<State> statesList = new List<State>();
            statesList = (from state in _dbContext.States
                          where state.CountryId == countryId
                          select state).ToList();
            return Json(statesList);
        }
        public JsonResult GetCitiesByStateId(int stateId)
        {
            List<City> citiesList = new List<City>();
            citiesList = (from city in _dbContext.Cities
                          where city.StateId == stateId
                          select city).ToList();
            return Json(citiesList);
        }
    }
}
