using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMVCProject.DatabaseContext;
using MyMVCProject.Models;

namespace MyMVCProject.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RegistrationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 

        }
        public async Task <IActionResult> Index()
        {
            var Reg = await _dbContext.Registrations.ToListAsync();
            return View(Reg);
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
                await _dbContext.Registrations.AddAsync(registration);
                await _dbContext.SaveChangesAsync();
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
            if (id == null || _dbContext.Registrations == null)
            {
                return NotFound();
            }
            var Result = await _dbContext.Registrations.FindAsync(id);
            if (Result == null)
            {
                return NotFound();

            }
            return View(Result);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Registration registration)
        {
            if (id != registration.Id) { return NotFound(); }
            _dbContext.Entry(registration).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(actionName: (nameof(Index)));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _dbContext.Registrations == null)
            {
                return NotFound();
            }
            var Result = await _dbContext.Registrations.FindAsync(id);
            if (Result == null)
            {
                return NotFound();

            }
            return View(Result);

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _dbContext.Registrations == null)
            {
                return NotFound();
            }
            var Result = await _dbContext.Registrations.FindAsync(id);
            if (Result == null)
            {
                return NotFound();

            }
            return View(Result);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Registration registration)
        {
            if (id != registration.Id) { return NotFound(); }
            _dbContext.Entry(registration).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(actionName: (nameof(Index)));
        }
    }
}
