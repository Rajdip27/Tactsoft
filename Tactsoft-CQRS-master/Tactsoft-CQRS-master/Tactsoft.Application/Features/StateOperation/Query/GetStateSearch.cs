using AutoMapper;
using MediatR;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StateOperation.Query;

public record GetStateSearch(int PageIndex, int PageSize, string SearchText) : IRequest<Paging<StateVM>>;

public class GetStateSearchHandler : IRequestHandler<GetStateSearch, Paging<StateVM>>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public GetStateSearchHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<Paging<StateVM>> Handle(GetStateSearch request, CancellationToken cancellationToken)
    {
        var data = await _stateRepository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.Name.Contains(request.SearchText)),
            o => o.OrderBy(ob => ob.Name),
            se => se);

        return data.ToPagingModel<State, StateVM>(_mapper);
    }
}
