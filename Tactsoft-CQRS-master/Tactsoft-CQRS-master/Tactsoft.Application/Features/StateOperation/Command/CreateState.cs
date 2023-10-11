using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StateOperation.Command;

public record CreateState(StateVM StateVM) : IRequest<StateVM>;

public class CreateStateHandler : IRequestHandler<CreateState, StateVM>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public CreateStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<StateVM> Handle(CreateState request, CancellationToken cancellationToken)
    {
        return await _stateRepository.InsertAsync(_mapper.Map<State>(request.StateVM));
    }
}
