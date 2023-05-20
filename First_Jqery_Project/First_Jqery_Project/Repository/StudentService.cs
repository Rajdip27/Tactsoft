using First_Jqery_Project.DatabaseContext;
using First_Jqery_Project.Models;
using First_Jqery_Project.Repository.Base;

namespace First_Jqery_Project.Repository
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
