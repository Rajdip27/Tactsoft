using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StudentOperation.Command;

public record UpdateStudent(int Id, StudentVM StudentVM):IRequest<StudentVM>;

public class UpdateStudentHandler : IRequestHandler<UpdateStudent, StudentVM>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public Task<StudentVM> Handle(UpdateStudent request, CancellationToken cancellationToken)
    {
        return _studentRepository.UpdateAsync(request.Id, _mapper.Map<Student>(request.StudentVM));
    }
}