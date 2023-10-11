using AutoMapper;
using MediatR;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CityOperation.Query;

public record GetCitySearch(int PageIndex, int PageSize, string SearchText) : IRequest<Paging<CityVM>>;

public class GetCitySearchHandler : IRequestHandler<GetCitySearch, Paging<CityVM>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCitySearchHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<Paging<CityVM>> Handle(GetCitySearch request, CancellationToken cancellationToken)
    {
        var data = await _cityRepository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.Name.Contains(request.SearchText)),
            o => o.OrderBy(ob => ob.Name),
            se => se, i => i.State);

        return data.ToPagingModel<City, CityVM>(_mapper);
    }
}
