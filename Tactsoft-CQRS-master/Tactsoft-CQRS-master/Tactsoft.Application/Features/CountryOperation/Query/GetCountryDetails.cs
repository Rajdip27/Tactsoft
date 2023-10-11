using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CountryOperation.Query;

public record GetCountryDetails(long Id) : IRequest<CountryVM>;

public class GetCountryDetailsHandler : IRequestHandler<GetCountryDetails, CountryVM>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountryDetailsHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryVM> Handle(GetCountryDetails request, CancellationToken cancellationToken)
    {
        return await _countryRepository.FirstOrDefaultAsync(request.Id);
    }
}
