using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.DatabaseContext;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        
        public async Task<IEnumerable<Student>> Get()
        {
            return await _dbContext.students.ToListAsync();
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var st=await _dbContext.students.FindAsync(id);
            return st==null?NotFound():Ok(st);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student st)
        {
            await _dbContext.students.AddAsync(st);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = st.Id }, st);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,Student st)
        {
            if (id != st.Id) return BadRequest();
            _dbContext.Entry(st).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var st = _dbContext.students.Find(id);
            if (st == null) return BadRequest();
            _dbContext.students.Remove(st);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
