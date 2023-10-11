using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StateOperation.Command;

public record UpdateState(long Id, StateVM StateVM) : IRequest<StateVM>;

public class UpdateStateHandler : IRequestHandler<UpdateState, StateVM>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public UpdateStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<StateVM> Handle(UpdateState request, CancellationToken cancellationToken)
    {
        return await _stateRepository.UpdateAsync(request.Id, _mapper.Map<State>(request.StateVM));
    }
}
