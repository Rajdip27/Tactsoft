using AutoMapper;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.Base;
using Tactsoft.Domain.Entities;
using Tactsoft.Infrastructure.AppContext;

namespace Tactsoft.Application.Repositories.EntityRepository;

public class CountryRepository : BaseRepository<Country, CountryVM, long>, ICountryRepository
{
    public CountryRepository(IMapper mapper, TactsoftDbContext context) : base(mapper, context)
    {
    }

}
