using Microsoft.AspNetCore.Mvc;
using Students_Mangmaent_With_Repostory_patten.Models;
using Students_Mangmaent_With_Repostory_patten.Services;

namespace Students_Mangmaent_With_Repostory_patten.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFaculty _faculty;
        public FacultyController(IFaculty faculty)
        {
            _faculty = faculty;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            return View(await _faculty.GetAllF());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Faculty>> Create(Faculty faculty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _faculty.Create(faculty);
                    await _faculty.Save();
                    return RedirectToAction(actionName: nameof(Index));
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return View(faculty);
        }
        [HttpGet]
        public async Task<ActionResult<Faculty>> Edit(int id)
        {
            try
            {
                var faculty = await _faculty.GetById(id);
                return View(faculty);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Faculty>> Edit(Faculty faculty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _faculty.Update(faculty);
                    await _faculty.Save();
                    return RedirectToAction(actionName: nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return View(faculty);
        }
        [HttpGet]
        public async Task<ActionResult<Faculty>> Details(int id)
        {
            try
            {
                var faculty = await _faculty.GetById(id);
                return View(faculty);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Faculty>> Delete(int id)
        {
            try
            {
                var faculty = await _faculty.GetById(id);
                return View(faculty);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult<Faculty>> DeleteCon(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();

                }
              
               await _faculty.Delete(id);
                await _faculty.Save();
                return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
