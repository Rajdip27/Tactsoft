using Voting_System.Models;
using VotingSystem.DatabaseContext;

namespace Voting_System.Service
{
    public class AccountService : BaseService<CreateUser>, IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
