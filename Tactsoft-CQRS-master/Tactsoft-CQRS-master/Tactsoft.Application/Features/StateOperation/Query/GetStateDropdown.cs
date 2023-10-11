using MediatR;
using Tactsoft.Application.Common;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.StateOperation.Query;

public record GetStateDropdown(long? CountryId = null, string SearchText = null, int Size = CommonVariables.DropdownSize) : IRequest<Dropdown<StateVM>>;

public class GetStateDropdownHandler : IRequestHandler<GetStateDropdown, Dropdown<StateVM>>
{
    private readonly IStateRepository _stateRepository;

    public GetStateDropdownHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<Dropdown<StateVM>> Handle(GetStateDropdown request, CancellationToken cancellationToken)
    {
        var data = await _stateRepository.GetDropdownAsync(
            p => (string.IsNullOrEmpty(request.SearchText) | p.Name.Contains(request.SearchText)
            && (request.CountryId == null || p.CountryId == request.CountryId)),
            o => o.OrderBy(ob => ob.Id),
            se => new StateVM { Id = se.Id, Name = se.Name, CountryId = se.CountryId },
            request.Size);
        return data;
    }
}
