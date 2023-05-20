using First_Jqery_Project.Models;
using First_Jqery_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace First_Jqery_Project.Controllers.Admin
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var data= await _studentService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult>AddorEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Student());
            }
            else
            {
                var students = await _studentService.FindAsync(id);
                if(students == null)
                {
                    return NotFound();
                }
                return View(students);
            }
        }
        public async Task<IActionResult> AddorEdit(int id, [Bind("StudentName,FatherName,MotherName,PresentAddress,ParmentAddress,PhoneNumber,DateofBirth")] Student student)
        {
            if(ModelState.IsValid)
            {
                //Save Data
                if (id == 0)
                {
                    await _studentService.InsertAsync(student);
                }
                else
                {
                    try
                    {
                        await _studentService.UpdateAsync(student);

                    }catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Json(new { isValid = true,html=Helper.RenderRazorViewToString(this,"_ViewAll", _studentService.GetAllAsync())});
              
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this,"AddorEdit", student) });
           
        }
    }
}
