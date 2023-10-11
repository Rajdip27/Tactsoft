using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CityOperation.Command;

public record CreateCity(CityVM CityVM) : IRequest<CityVM>;

public class CreateCityHandler : IRequestHandler<CreateCity, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CreateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(CreateCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.InsertAsync(_mapper.Map<City>(request.CityVM));
    }
}
