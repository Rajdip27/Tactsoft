using Resume_Manager.Context;
using Resume_Manager.Models;
using Resume_Manager.Service.Base;

namespace Resume_Manager.Service
{
    public class ResumeService : BaseService<Applicant>, IResumeService
    {
        private readonly ApplicationDbContext _context;
        public ResumeService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
