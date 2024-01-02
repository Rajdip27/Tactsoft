using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.DatabaseContext;
using StudentManagement.Models;
using System.Net.Mime;
using System.Text;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await context.Set<Student>().ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await context.Set<Student>().FindAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student students)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Set<Student>().Add(students);
            context.SaveChanges();
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Student students)
        {
            if (id != students.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Entry(students).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.Set<Student>().Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = context.Set<Student>().Find(id);
            if (student == null)
                return NotFound();

            context.Set<Student>().Remove(student);
            context.SaveChanges();
            return NoContent();
        }

        [HttpGet("print")]
        public async Task<IActionResult> Print()
        {
            var data = await context.Set<Student>().AsNoTracking().ToListAsync();
            string reportName = "TestReport.pdf";
            string reportPath = Path.Combine(hostEnvironment.ContentRootPath, "Report", "StudentReport.rdlc");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            LocalReport report = new LocalReport(reportPath);
            report.AddDataSource("StudentDbSet", data.ToList());

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            var result = report.Execute(RenderType.Pdf, 1, parameters);
            var content = result.MainStream.ToArray();
            var contentDisposition = new ContentDisposition
            {
                FileName = reportName,
                Inline = true,
            };

            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            return File(content, MediaTypeNames.Application.Pdf);
        }
    }
}

