using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.StateOperation.Query;

public record GetStateDetails(long Id) : IRequest<StateVM>;

public class GetStateDetailsHandler : IRequestHandler<GetStateDetails, StateVM>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public GetStateDetailsHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<StateVM> Handle(GetStateDetails request, CancellationToken cancellationToken)
    {
        return await _stateRepository.FirstOrDefaultAsync(request.Id);
    }
}
