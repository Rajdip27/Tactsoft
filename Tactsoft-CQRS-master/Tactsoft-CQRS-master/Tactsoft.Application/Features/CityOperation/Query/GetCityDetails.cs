using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CityOperation.Query;

public record GetCityDetails(long Id) : IRequest<CityVM>;

public class GetCityDetailsHandler : IRequestHandler<GetCityDetails, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCityDetailsHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(GetCityDetails request, CancellationToken cancellationToken)
    {
        return await _cityRepository.FirstOrDefaultAsync(request.Id);
    }
}
