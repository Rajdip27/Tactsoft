using Voting_System.Models;
using VotingSystem.DatabaseContext;

namespace Voting_System.Service
{
	public class AdminService : BaseService<CreateAdmin>, IAdminService
	{
		private readonly ApplicationDbContext _context;
		public AdminService(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
