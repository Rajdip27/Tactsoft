using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using New_Pratice_Project.DatabaseContext;
using New_Pratice_Project.Models;
using New_Pratice_Project.ViewModel;

namespace New_Pratice_Project.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Deperment> listDeperment=_context.Deperments.ToList();
            ViewBag.Employees = new SelectList(listDeperment,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmployeeViewModel model)
        {
            try
            {
                List<Deperment> listDeperment = _context.Deperments.ToList();
                ViewBag.Employees = new SelectList(listDeperment, "Id", "Name");
                Employee employee = new Employee();
               employee.Name = model.Name;
                employee.Address=model.Address;
                employee.Phone= model.Phone;
                employee.DepermentId = model.DepartmentId;
                _context.Employees.Add(employee);
                _context.SaveChanges();

                Site site=new Site();
                site.SiteName = model.SiteName;
                site.EmployeeId = employee.Id;
                _context.Sites.Add(site);
                _context.SaveChanges();


            }
            catch(Exception ex)
            {
               return View(ex.Message);
            }
            return View(model);

        }
    }
}
