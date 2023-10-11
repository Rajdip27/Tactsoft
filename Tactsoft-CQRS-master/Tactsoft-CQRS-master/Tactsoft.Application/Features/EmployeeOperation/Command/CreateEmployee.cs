using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.IO.Pipelines;
using Tactsoft.Application.Common;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.EmployeeOperation.Command;

public record CreateEmployee(EmployeeVM EmployeeVM) : IRequest<EmployeeVM>;


public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, EmployeeVM>
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<EmployeeVM> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {
        if (request.EmployeeVM.PictureFile?.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, CommonVariables.PictureLocation);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.EmployeeVM.PictureFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
           
            using (var fileStream = new FileStream(filePath, FileMode.Create, access: FileAccess.ReadWrite))
            {
                var file = request.EmployeeVM.PictureFile.OpenReadStream();
                await  file.CopyToAsync(fileStream, cancellationToken);
            }
            request.EmployeeVM.Picture = uniqueFileName;
        }

        return await _employeeRepository.InsertAsync(_mapper.Map<Domain.Entities.Employee>(request.EmployeeVM));
    }
}