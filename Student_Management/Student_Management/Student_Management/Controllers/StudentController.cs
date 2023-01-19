using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management.DatabaseContext;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    public class StudentController : Controller
    {
      private readonly  StudentManagementDbContext _dbContext;
        public StudentController(StudentManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
            var Result=await _dbContext.Students.ToListAsync();
            return View(Result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Student student)
        {
            try
            {
                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var student = await _dbContext.Students.FindAsync(id);
                return View(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public async Task<IActionResult> Edit(int id,Student student)
        {
            try
            {
                if (id == null || _dbContext.Students == null)
                {
                    return NotFound();
                }
                var Result = await _dbContext.Students.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();

                }
                return View(Result);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null || _dbContext.Students == null)
                {
                    return NotFound();
                }
                var Result = await _dbContext.Students.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();

                }
                return View(Result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
           

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Student Students)
        {
            try
            {
                if (id != Students.Id) { return NotFound(); }
                _dbContext.Entry(Students).State = EntityState.Deleted;
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
                var student = await _dbContext.Students.FindAsync(id);
                return View(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}

