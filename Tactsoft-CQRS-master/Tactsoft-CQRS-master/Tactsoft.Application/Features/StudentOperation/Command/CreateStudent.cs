using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StudentOperation.Command;

public record CreateStudent(StudentVM StudentVM):IRequest<StudentVM>;

public class CreateStudentHandler : IRequestHandler<CreateStudent, StudentVM>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentVM> Handle(CreateStudent request, CancellationToken cancellationToken)
    {
        return await _studentRepository.InsertAsync(_mapper.Map<Student>(request.StudentVM));
    }
}