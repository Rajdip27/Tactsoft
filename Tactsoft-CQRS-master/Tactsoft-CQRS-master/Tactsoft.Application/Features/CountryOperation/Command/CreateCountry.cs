using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CountryOperation.Command;

public record CreateCountry(CountryVM CountryVM) : IRequest<CountryVM>;

public class CreateCountryHandler : IRequestHandler<CreateCountry, CountryVM>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CreateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryVM> Handle(CreateCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.InsertAsync(_mapper.Map<Country>(request.CountryVM));
    }
}
