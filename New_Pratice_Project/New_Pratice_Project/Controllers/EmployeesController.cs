using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var employees = _context.Employees.Include(x=>x.Deperment);
            return View(employees.ToList());
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
        [HttpPost]
        public ActionResult DelEmployee(int EmployeeId)
        {
           
            Employee emp = _context.Employees.SingleOrDefault(x => x.Id == EmployeeId);
            if (emp != null)
            {
                _context.Entry(emp).State = EntityState.Deleted;
               _context.SaveChanges();
            }
            return Json(emp);

        }
    }
}
