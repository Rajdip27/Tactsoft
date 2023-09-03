using Microsoft.AspNetCore.Mvc;
using MongoDbTest.Models;
using MongoDbTest.Services;

namespace MongoDbTest.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IActionResult> Index()
    {
        var data= await _studentRepository.GetAllAsync();
        return View(data);
    }

    [HttpGet]
    public async Task<ActionResult> AddorEdit(string id)
    {
        if(id == null)
        {
            return View(new Student());
        }
        else
        {
            var data= await _studentRepository.GetByIdAsync(id);
            return View(data);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddorEdit(string id ,Student student,IFormFile pictureFile)
    {
            if (id == null)
            {
            if (pictureFile != null && pictureFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    pictureFile.CopyTo(stream);
                }
                student.Photos = $"{pictureFile.FileName}";
            }


            await _studentRepository.CreateAsync(student).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            else
            {
                var students = await _studentRepository.GetByIdAsync(id).ConfigureAwait(false);
                await _studentRepository.UpdateAsync(id, students).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
    }


    public async Task<ActionResult>Delete(string id)
    {
        await _studentRepository.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
