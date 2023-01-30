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
        [HttpGet]
        public async Task<ActionResult<Employee>> Edit(int id)
        {
            try
            {
                var employee = await _employee.GetById(id);
                return View(employee);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Edit(Employee employee)
        {
            try
            {
                await _employee.Update(employee);
                await _employee.Save();
                return RedirectToAction(actionName: nameof(Index));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Employee>> Details(int id)
        {
            try
            {
                var employee = await _employee.GetById(id);
                return View(employee);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var employee = await _employee.GetById(id);
                return View(employee);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult<Employee>> DeleteCon(int id)
        {
            try
            {
                //var result = await _employee.GetById(id);
                if (id == null)
                {
                    return NotFound();
                }
                await _employee.Delete(id);
                await _employee.Save();
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
