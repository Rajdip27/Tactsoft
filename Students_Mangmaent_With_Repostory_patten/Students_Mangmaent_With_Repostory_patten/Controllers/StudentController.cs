using Microsoft.AspNetCore.Mvc;
using Students_Mangmaent_With_Repostory_patten.Models;
using Students_Mangmaent_With_Repostory_patten.Services;
using System.Data;

namespace Students_Mangmaent_With_Repostory_patten.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }
        public async Task<IActionResult> Index()
        {
            var st = await _student.GetAllSt();
            return View(st);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _student.Create(student);
                    await _student.Save();
                    return RedirectToAction(actionName: nameof(Index));
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);

        }
        [HttpGet]
        public async Task<ActionResult<Student>> Edit(int id)
        {
            try
            {
                var st = await _student.GetById(id);
                return View(st);

            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Student>> Edit(Student student)
        {
            try
            {
               await _student.Update(student);
                await _student.Save();
                return RedirectToAction(actionName: nameof(Index));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Student>> Details(int id)
        {
            try
            {
                var st = await _student.GetById(id);
                return View(st);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            try
            {
                var st = await _student.GetById(id);
                return View(st);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]

        public async Task<ActionResult<Student>> DeleteConfirm(int id)
        {
            try
            {
                await _student.Delete(id);
                await _student.Save();
                return RedirectToAction(actionName: nameof(Index));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
