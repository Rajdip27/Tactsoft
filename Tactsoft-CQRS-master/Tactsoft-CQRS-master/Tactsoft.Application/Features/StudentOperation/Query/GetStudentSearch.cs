using AutoMapper;
using MediatR;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StudentOperation.Query;

public record GetStudentSearch(int PageIndex, int PageSize, string SearchText) : IRequest<Paging<StudentVM>>;


public class GetStudentSearchHandler : IRequestHandler<GetStudentSearch, Paging<StudentVM>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentSearchHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<Paging<StudentVM>> Handle(GetStudentSearch request, CancellationToken cancellationToken)
    {
        var data = await _studentRepository.GetPageAsync(request.PageIndex, request.PageSize,
           p => (string.IsNullOrEmpty(request.SearchText) || p.FirstName.Contains(request.SearchText)),
           o => o.OrderBy(ob => ob.Id),
           se => se);

        return data.ToPagingModel<Student, StudentVM>(_mapper);
    }
}