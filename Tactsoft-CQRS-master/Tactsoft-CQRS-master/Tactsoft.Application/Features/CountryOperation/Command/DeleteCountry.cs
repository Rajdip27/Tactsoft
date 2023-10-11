using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CountryOperation.Command;

public record DeleteCountry(long Id) : IRequest<CountryVM>;

public class DeleteCountryHandler : IRequestHandler<DeleteCountry, CountryVM>
{
    private readonly ICountryRepository _countryRepository;

    public DeleteCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<CountryVM> Handle(DeleteCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.DeleteAsync(request.Id);
    }
}
