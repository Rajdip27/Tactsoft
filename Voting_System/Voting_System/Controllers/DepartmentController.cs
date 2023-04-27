using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voting_System.Service;
using VotingSystem.Models;

namespace Voting_System.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _departmentService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AspInfoDepartment model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    model.EntryDate= DateTime.Now;
                    
                    await _departmentService.InsertAsync(model);
                    return RedirectToAction ("Index");
                }
                return View(model);

            }
            catch
            {
                return View("Create",model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var data=await _departmentService.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AspInfoDepartment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    model.EntryDate= DateTime.Now;
                    await _departmentService.UpdateAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch
            {
                return View("Edit",model) ;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var data = await _departmentService.FindAsync(id);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var data = await _departmentService.FindAsync(id);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletecon(int id)
        {
            try
            {
                var Result = await _departmentService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _departmentService.DeleteAsync(Result);
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
