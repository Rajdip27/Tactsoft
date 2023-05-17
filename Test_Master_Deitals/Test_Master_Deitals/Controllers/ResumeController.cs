using Microsoft.AspNetCore.Mvc;
using Test_Master_Deitals.DataContext;
using Test_Master_Deitals.Models;

namespace Test_Master_Deitals.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant=new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
           // applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });

            return View(applicant);
        }
        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            foreach(Experience experience in applicant.Experiences)
            {
                if(experience.ComapanyName==null||experience.ComapanyName.Length==0)
                    applicant.Experiences.Remove(experience);
            }
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
