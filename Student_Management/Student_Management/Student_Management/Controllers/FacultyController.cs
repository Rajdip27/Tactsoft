using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management.DatabaseContext;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    public class FacultyController : Controller
    {
        private readonly StudentManagementDbContext _dbContext;
        public FacultyController(StudentManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var Result = await _dbContext.Facultys.ToListAsync();
            return View(Result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Faculty  faculty)
        {
            try
            {
                await _dbContext.Facultys.AddAsync(faculty);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(faculty);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                var faculty = await _dbContext.Facultys.FindAsync(Id);
                return View(faculty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public async Task<IActionResult> Edit(int id, Faculty faculty)
        {
            try
            {
                if (id == null || _dbContext.Facultys == null)
                {
                    return NotFound();
                }
                var Result = await _dbContext.Facultys.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();

                }
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null || _dbContext.Facultys == null)
                {
                    return NotFound();
                }
                var Result = await _dbContext.Facultys.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();

                }
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Faculty faculty)
        {
            try
            {
                if (id != faculty.Id) { return NotFound(); }
                _dbContext.Entry(faculty).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var student = await _dbContext.Facultys.FindAsync(id);
                return View(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
