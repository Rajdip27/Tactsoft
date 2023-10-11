using AutoMapper;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.Base;
using Tactsoft.Domain.Entities;
using Tactsoft.Infrastructure.AppContext;

namespace Tactsoft.Application.Repositories.EntityRepository;

public class StateRepository : BaseRepository<State, StateVM, long>, IStateRepository
{
    public StateRepository(IMapper mapper, TactsoftDbContext context) : base(mapper, context)
    {

    }

}
