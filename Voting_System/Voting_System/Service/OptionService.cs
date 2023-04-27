using VotingSystem.DatabaseContext;
using VotingSystem.Models;

namespace Voting_System.Service
{
    public class OptionService : BaseService<AspInfoOption>, IOptionService
    {
        private readonly ApplicationDbContext _context;
        public OptionService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
