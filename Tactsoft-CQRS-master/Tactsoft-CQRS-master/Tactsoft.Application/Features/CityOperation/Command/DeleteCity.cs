using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CityOperation.Command;

public record DeleteCity(long Id) : IRequest<CityVM>;

public class DeleteCityHandler : IRequestHandler<DeleteCity, CityVM>
{
    private readonly ICityRepository _cityRepository;

    public DeleteCityHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CityVM> Handle(DeleteCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.DeleteAsync(request.Id);
    }
}
