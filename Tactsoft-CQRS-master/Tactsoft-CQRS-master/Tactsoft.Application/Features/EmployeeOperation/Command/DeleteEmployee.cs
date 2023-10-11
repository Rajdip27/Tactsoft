using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.EmployeeOperation.Command;

public record DeleteEmployee(int Id) : IRequest<EmployeeVM>;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, EmployeeVM>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public DeleteEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeVM> Handle(DeleteEmployee request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.DeleteAsync(request.Id);
    }
}