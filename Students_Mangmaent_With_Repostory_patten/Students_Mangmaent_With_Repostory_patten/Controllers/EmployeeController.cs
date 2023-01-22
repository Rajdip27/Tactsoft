using Microsoft.AspNetCore.Mvc;
using Students_Mangmaent_With_Repostory_patten.Models;
using Students_Mangmaent_With_Repostory_patten.Services;

namespace Students_Mangmaent_With_Repostory_patten.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        public async Task< ActionResult<Employee>> Index()
        {
            return View(await _employee.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employee.Create(employee);
                    await _employee.Save();
                    return RedirectToAction(actionName:nameof(Index));
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return View(employee);
        }
    }
}
