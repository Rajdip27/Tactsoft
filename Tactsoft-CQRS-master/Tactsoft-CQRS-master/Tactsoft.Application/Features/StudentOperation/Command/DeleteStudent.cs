using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StudentOperation.Command;

public record DeleteStudent(int Id):IRequest<StudentVM>;

public class DeleteStudentHandler : IRequestHandler<DeleteStudent, StudentVM>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public DeleteStudentHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentVM> Handle(DeleteStudent request, CancellationToken cancellationToken)
    {
        return await _studentRepository.DeleteAsync(request.Id);
    }
}