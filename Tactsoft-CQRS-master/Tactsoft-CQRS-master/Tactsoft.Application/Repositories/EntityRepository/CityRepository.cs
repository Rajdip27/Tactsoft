using AutoMapper;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.Base;
using Tactsoft.Domain.Entities;
using Tactsoft.Infrastructure.AppContext;

namespace Tactsoft.Application.Repositories.EntityRepository;

public class CityRepository : BaseRepository<City, CityVM, long>, ICityRepository
{
    public CityRepository(IMapper mapper, TactsoftDbContext context) : base(mapper, context)
    {
    }

}
