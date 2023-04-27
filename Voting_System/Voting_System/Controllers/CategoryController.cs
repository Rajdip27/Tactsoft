using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Voting_System.Service;
using VotingSystem.Models;

namespace Voting_System.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDepartmentService _departmentService;
        public CategoryController(ICategoryService categoryService, IDepartmentService departmentService)
        {
            _categoryService = categoryService;
            _departmentService = departmentService;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _categoryService.GetAllAsync(x=>x.AspInfoDepartment);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = _departmentService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AspInfoCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.EntryDate = DateTime.Now;

                    await _categoryService.InsertAsync(model);
                    return RedirectToAction("Index");
                }
                ViewData["DepartmentID"] = _departmentService.Dropdown();
                return View(model);

            }
            catch
            {
                ViewData["DepartmentID"] = _departmentService.Dropdown();
                return View("Create", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            ViewData["DepartmentID"] = _departmentService.Dropdown();
            var data = await _categoryService.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AspInfoCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    model.EntryDate = DateTime.Now;
                    await _categoryService.UpdateAsync(model);
                    return RedirectToAction("Index");
                }
                ViewData["DepartmentID"] = _departmentService.Dropdown();
                return View(model);
                
            }
            catch
            {
                ViewData["DepartmentID"] = _departmentService.Dropdown();
                return View("Edit", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            ViewData["DepartmentID"] = _departmentService.Dropdown();
            var data = await _categoryService.FindAsync(x=>x.Id==id,x=>x.AspInfoDepartment);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewData["DepartmentID"] = _departmentService.Dropdown();
            var data = await _categoryService.FindAsync(id);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleteconfirm(int id)
        {
            try
            {
                var Result = await _categoryService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _categoryService.DeleteAsync(Result);
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
