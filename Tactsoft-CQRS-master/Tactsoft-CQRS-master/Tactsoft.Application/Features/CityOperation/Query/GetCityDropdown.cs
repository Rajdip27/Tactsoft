using MediatR;
using Tactsoft.Application.Common;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CityOperation.Query;

public record GetCityDropdown(long? StateId = null, string SearchText = null, int Size = CommonVariables.DropdownSize) : IRequest<Dropdown<CityVM>>;

public class GetCityDropdownHandler : IRequestHandler<GetCityDropdown, Dropdown<CityVM>>
{
    private readonly ICityRepository _cityRepository;

    public GetCityDropdownHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<Dropdown<CityVM>> Handle(GetCityDropdown request, CancellationToken cancellationToken)
    {
        var data = await _cityRepository.GetDropdownAsync(
            p => (string.IsNullOrEmpty(request.SearchText) | p.Name.Contains(request.SearchText)
            && (request.StateId == null || p.StateId == request.StateId)),
            o => o.OrderBy(ob => ob.Id),
            se => new CityVM { Id = se.Id, Name = se.Name, StateId = se.StateId },
            request.Size);
        return data;
    }
}
