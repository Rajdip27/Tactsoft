using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using New_Pratice_Project.DatabaseContext;
using New_Pratice_Project.Models;
using New_Pratice_Project.ViewModel;

namespace New_Pratice_Project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        //public IActionResult Index()
        //{
        //    Employee employee=_context.Employees.FirstOrDefault(x=>x.Id==1);
        //    VmEmployee vmEmployee=new VmEmployee();
        //   vmEmployee.Id = employee.Id;
        //    vmEmployee.Name = employee.Name;
        //    vmEmployee.DepermentName=_context.Deperments.FirstOrDefault(x=>x.Id == employee.Id).Name;
        //    vmEmployee.Address = employee.Address;
        //    vmEmployee.Phone = employee.Phone;  
        //    return View(vmEmployee);
        //}
        //public IActionResult Index()
        //{ 
        //    List<Employee> employees = _context.Employees.ToList();
        //    VmEmployee vmEmployee = new VmEmployee();
        //    List<VmEmployee> vmEmployeeList = employees.Select(e => new VmEmployee{ Id=e.Id,Address=e.Address,Phone=e.Phone,Name=e.Name, depermentId = e.DepermentId,Deperment=e.Deperment.Name}).ToList();
        //    return View(vmEmployeeList);
        //}
        //public IActionResult Index()
        //{
        //    List<Deperment> listDeperment=_context.Deperments.ToList();
        //    ViewBag.DepermentList = new SelectList(listDeperment, "Id", "Name");
        //    return View();
        //}
        public IActionResult Index()
        {
            List<Employee> employee = _context.Employees.ToList();
            return View(employee);


        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Deperment> listDeperment = _context.Deperments.ToList();
            ViewBag.depermentsList = new SelectList(listDeperment,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
               await _context.Employees.AddAsync(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(employee);

        }

    }
}
