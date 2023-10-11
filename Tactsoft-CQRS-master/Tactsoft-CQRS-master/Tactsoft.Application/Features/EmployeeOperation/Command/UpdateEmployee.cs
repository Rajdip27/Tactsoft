using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Tactsoft.Application.Common;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.EmployeeOperation.Command;

public record UpdateEmployee(int Id, EmployeeVM EmployeeVM) : IRequest<EmployeeVM>;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, EmployeeVM>
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<EmployeeVM> Handle(UpdateEmployee request, CancellationToken cancellationToken)
    {
        if (request.EmployeeVM.PictureFile?.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, CommonVariables.PictureLocation);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.EmployeeVM.PictureFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, access: FileAccess.ReadWrite))
            {
                var file = request.EmployeeVM.PictureFile.OpenReadStream();
                await file.CopyToAsync(fileStream, cancellationToken);

            }
            request.EmployeeVM.Picture = uniqueFileName;
        }
        else
        {
            request.EmployeeVM.Picture=request.EmployeeVM.Picture?.Split("/")?.LastOrDefault().Trim();
        }
        return await _employeeRepository.UpdateAsync(request.Id, _mapper.Map<Employee>(request.EmployeeVM));
    }
}