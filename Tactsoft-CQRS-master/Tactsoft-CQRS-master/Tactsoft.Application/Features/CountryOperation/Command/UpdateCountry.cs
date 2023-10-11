using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CountryOperation.Command;

public record UpdateCountry(long Id, CountryVM CountryVM) : IRequest<CountryVM>;

public class UpdateCountryHandler : IRequestHandler<UpdateCountry, CountryVM>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryVM> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.UpdateAsync(request.Id, _mapper.Map<Country>(request.CountryVM));
    }
}
