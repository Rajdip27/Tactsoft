using AutoMapper;
using MediatR;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CountryOperation.Query;

public record GetCountrySearch(int PageIndex, int PageSize, string SearchText) : IRequest<Paging<CountryVM>>;

public class GetCountrySearchHandler : IRequestHandler<GetCountrySearch, Paging<CountryVM>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountrySearchHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<Paging<CountryVM>> Handle(GetCountrySearch request, CancellationToken cancellationToken)
    {
        var data = await _countryRepository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.Name.Contains(request.SearchText)),
            o => o.OrderBy(ob => ob.Name),
            se => se);

        return data.ToPagingModel<Country, CountryVM>(_mapper);
    }
}
