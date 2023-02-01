using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View(await _dbContext.Employees.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
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
                return View(employee);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
