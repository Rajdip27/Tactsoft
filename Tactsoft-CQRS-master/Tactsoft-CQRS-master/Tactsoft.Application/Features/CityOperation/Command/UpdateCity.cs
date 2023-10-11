using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CityOperation.Command;

public record UpdateCity(long Id, CityVM CityVM) : IRequest<CityVM>;

public class UpdateCityHandler : IRequestHandler<UpdateCity, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(UpdateCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.UpdateAsync(request.Id, _mapper.Map<City>(request.CityVM));
    }
}
