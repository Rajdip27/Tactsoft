using Microsoft.AspNetCore.Mvc;
using Students_Mangmaent_With_Repostory_patten.Models;
using Students_Mangmaent_With_Repostory_patten.Services;
using System.Data;

namespace Students_Mangmaent_With_Repostory_patten.Controllers
{
    public class CourceController : Controller
    {
        private readonly ICource _cource;
        public CourceController(ICource cource)
        {
            _cource = cource;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            return View(await _cource.GetAllCo());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Cource>> Create(Cource cource)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _cource.Create(cource);
                    await _cource.Save();
                    return RedirectToAction(actionName:nameof(Index));

                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(cource);
        }
        [HttpGet]
        public async Task<ActionResult<Cource>> Edit(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var cource = await _cource.GetById(id);
                if(cource == null)
                {
                    return NotFound();
                }
                return View(cource);

            }catch(Exception ex)
            {
                return NotFound(ex.Message);    
            }
        }
        [HttpPost]
        public async Task<ActionResult<Cource>> Edit(Cource cource)
        {
            try
            {
                await _cource.Update(cource);
                await _cource.Save();
                return RedirectToAction(actionName: nameof(Index));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Cource>> Details(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var cource = await _cource.GetById(id);
                if (cource == null)
                {
                    return NotFound();
                }
                return View(cource);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Cource>> Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var cource = await _cource.GetById(id);
                if (cource == null)
                {
                    return NotFound();
                }
                return View(cource);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult<Cource>> DeleteCon(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                await _cource.Delete(id);
                await _cource.Save();
                return RedirectToAction(actionName: nameof(Index));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
