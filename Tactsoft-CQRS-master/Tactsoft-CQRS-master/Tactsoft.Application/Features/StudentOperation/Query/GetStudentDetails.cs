using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;

namespace Tactsoft.Application.Features.StudentOperation.Query;

public record GetStudentDetails(int Id) : IRequest<StudentVM>;

public class GetStudentDetailsHandler : IRequestHandler<GetStudentDetails, StudentVM>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentDetailsHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentVM> Handle(GetStudentDetails request, CancellationToken cancellationToken)
    {
        return await _studentRepository.FirstOrDefaultAsync(request.Id);
    }
}