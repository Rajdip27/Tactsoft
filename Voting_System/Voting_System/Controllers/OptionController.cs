using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Voting_System.Service;
using VotingSystem.Models;

namespace Voting_System.Controllers
{
	[Authorize(Roles = "Admin")]
	public class OptionController : Controller
    {
        private readonly IOptionService _optionService;
        private readonly ICategoryService _categoryService;
        public OptionController(IOptionService optionService, ICategoryService categoryService)
        {
            _optionService = optionService;
            _categoryService = categoryService;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _optionService.GetAllAsync(x => x.Category);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = _categoryService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AspInfoOption model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.EntryDate = DateTime.Now;

                    await _optionService.InsertAsync(model);
                    return RedirectToAction("Index");
                }
                ViewData["CategoryId"] = _categoryService.Dropdown();
                return View(model);

            }
            catch
            {
                ViewData["CategoryId"] = _categoryService.Dropdown();
                return View("Create", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            ViewData["CategoryId"] = _categoryService.Dropdown();
            var data = await _optionService.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AspInfoOption model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    model.EntryDate = DateTime.Now;
                    await _optionService.UpdateAsync(model);
                    return RedirectToAction("Index");
                }
                ViewData["CategoryId"] = _categoryService.Dropdown();
                return View(model);

            }
            catch
            {
                ViewData["CategoryId"] = _categoryService.Dropdown();
                return View("Edit", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            ViewData["CategoryId"] = _categoryService.Dropdown();
            var data = await _optionService.FindAsync(x => x.Id == id, x => x.Category);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewData["CategoryId"] = _categoryService.Dropdown();
            var data = await _optionService.FindAsync(x=>x.Id==id,x=>x.Category);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleteconfirm(int id)
        {
            try
            {
                var Result = await _optionService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _optionService.DeleteAsync(Result);
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
