using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students_Mangmaent_With_Repostory_patten.Models;
using Students_Mangmaent_With_Repostory_patten.Services;

namespace Students_Mangmaent_With_Repostory_patten.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistration _registration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RegistrationController(IRegistration registration, IWebHostEnvironment webHostEnvironment)
        {
            _registration = registration;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task< ActionResult<Registrion>> Index()
        {
            return View( await _registration.GetAllSt());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Registrion>> Create(Registrion registrion,IFormFile pictureFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(pictureFile != null && pictureFile.Length > 0)
                    {
                        var path= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images",pictureFile.Name);
                        using(var stream=new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        registrion.Picture = $"{pictureFile.FileName}";
                    }
                   await _registration.Create(registrion);
                    await _registration.Save();
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(registrion);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
