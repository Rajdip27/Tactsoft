using MediatR;
using Tactsoft.Application.Common;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CountryOperation.Query;

public record GetCountryDropdown(string SearchText = null, int Size = CommonVariables.DropdownSize) : IRequest<Dropdown<CountryVM>>;

public class GetCountryDropdownHandler : IRequestHandler<GetCountryDropdown, Dropdown<CountryVM>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountryDropdownHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Dropdown<CountryVM>> Handle(GetCountryDropdown request, CancellationToken cancellationToken)
    {
        var data = await _countryRepository.GetDropdownAsync(
            p => (string.IsNullOrEmpty(request.SearchText) | p.Name.Contains(request.SearchText)),
            o => o.OrderBy(ob => ob.Id),
            se => new CountryVM { Id = se.Id, Name = se.Name },
            request.Size);
        return data;
    }
}
