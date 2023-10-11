using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.EmployeeOperation.Query;

public record GetEmployeeDetails(long Id) : IRequest<EmployeeVM>;

public class GetEmployeeDetailsHandler : IRequestHandler<GetEmployeeDetails, EmployeeVM>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeDetailsHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeVM> Handle(GetEmployeeDetails request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.FirstOrDefaultAsync(x => x.Id == request.Id, x => x.Country, x => x.State, x => x.City);
    }
}