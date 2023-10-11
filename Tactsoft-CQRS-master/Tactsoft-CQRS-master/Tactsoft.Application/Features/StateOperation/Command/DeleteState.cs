using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.StateOperation.Command;

public record DeleteState(long Id) : IRequest<StateVM>;

public class DeleteStateHandler : IRequestHandler<DeleteState, StateVM>
{
    private readonly IStateRepository _stateRepository;

    public DeleteStateHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<StateVM> Handle(DeleteState request, CancellationToken cancellationToken)
    {
        return await _stateRepository.DeleteAsync(request.Id);
    }
}
