using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShortProject.DatabaseContext;
using MvcShortProject.Models;
using System;

namespace MvcShortProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHostEnvironment _environment;
        public EmployeeController(ApplicationDbContext dbContext, IHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task< IActionResult> Index()
        {
            var em=  _dbContext.Employees.Include(e => e.City).Include(e => e.Country).Include(e => e.State);
            return View(await em.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_dbContext.Cities, "Id", "CityName");
            ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName");
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee,IFormFile pictureFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream= new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    _dbContext.Add(employee);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
                ViewData["CityId"] = new SelectList(_dbContext.Cities, "Id", "CityName",employee.CityId);
                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id", "CountryName", employee.CountryId);
                ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName", employee.StateId);
                return View(employee);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
             var em = await _dbContext.Employees.Include(x => x.Country).Include(c => c.City).Include(x => x.State).FirstOrDefaultAsync(m => m.Id == id);
            return View(em);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int  id)
        {
            ViewData["CityId"] = new SelectList(_dbContext.Cities, "Id", "CityName");
            ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id","CountryName");
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName");

            var em = await _dbContext.Employees.FindAsync(id);
            return View(em);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _dbContext.Employees.FindAsync(employee.Id);
                    if(pictureFile != null && pictureFile.Length > 0)
                    {
                        var path=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using(var stream=new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        employee.Picture=emp.Picture;
                    }
                    emp.Picture = employee.Picture;
                    emp.Name = employee.Name;
                    emp.Address=employee.Address;
                    emp.Gender=employee.Gender;
                    emp.Hsc=employee.Hsc;
                    emp.Ssc=employee.Ssc;
                    emp.Msc=employee.Msc;
                    emp.Bsc=employee.Bsc;
                    emp.CountryId=employee.CountryId;
                    emp.StateId = employee.StateId;
                    emp.CountryId = employee.CountryId;
                    _dbContext.Update(emp);
                    await _dbContext.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            ViewData["CityId"] = new SelectList(_dbContext.Cities, "Id", "CityName",
employee.CityId);
            ViewData["CountryId"] = new SelectList(_dbContext.Countries, "Id",
           "CountryName", employee.CountryId);
            ViewData["StateId"] = new SelectList(_dbContext.States, "Id", "StateName",
           employee.StateId);
            return View(employee);

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
