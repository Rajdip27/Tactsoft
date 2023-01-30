using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMVCProject.DatabaseContext;
using MyMVCProject.Models;
using MyMVCProject.Serivce;

namespace MyMVCProject.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IRegistrion _registrion;
        public RegistrationController(IRegistrion registrion )
        {

            _registrion = registrion;
        }
        [HttpGet]
        public async Task <ActionResult<Registration>> Index()
        {
            
            return View(await _registrion.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registration registration)
        {
            try
            {
                await _registrion.Create(registration);
                await _registrion.Save();
                return RedirectToAction(actionName: (nameof(Index)));

            }
            catch
            {
                return View(registration);
            }
           // return View(registration);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var Result = await  _registrion.GetById(id);
            if (Result == null)
            {
                return NotFound();

            }
            return View(Result);

        }

        [HttpPost]
        public async Task<IActionResult> Edit( Registration registration)
        {
            await _registrion.Update(registration);
            await _registrion.Save();
            return RedirectToAction(actionName: (nameof(Index)));
        }
        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var Result = await _registrion.GetById(id);
            if (Result == null)
            {
                return NotFound();

            }
            return View(Result);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var Result = await _registrion.GetById(id); 
            if (Result == null)
            {
                return NotFound();

            }
            return View(Result);

        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConf(int id)
        {
        
            await _registrion.DeleteById(id);
            await _registrion.Save();
            return RedirectToAction(actionName: (nameof(Index)));


        }
    }
}
