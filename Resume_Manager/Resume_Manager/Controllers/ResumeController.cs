using Microsoft.AspNetCore.Mvc;
using Resume_Manager.Context;
using Resume_Manager.Models;
using Resume_Manager.Service;

namespace Resume_Manager.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
      
        private readonly IWebHostEnvironment _webHost;

        public ResumeController(IResumeService resumeService, IWebHostEnvironment webHost)
        {
            _resumeService = resumeService;
            _webHost = webHost;

        }
        public async Task< IActionResult> Index()
        {
            var data =await _resumeService.GetAllAsync();
            return View(data);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { Id = 1 });
            //applicant.Experiences.Add(new Experience() { Id = 2 });
            //applicant.Experiences.Add(new Experience() { Id = 3 });
            return View(applicant);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Applicant applicant)
        {
          
            await _resumeService.InsertAsync(applicant);
            return RedirectToAction("Index");

        }
    }
}
