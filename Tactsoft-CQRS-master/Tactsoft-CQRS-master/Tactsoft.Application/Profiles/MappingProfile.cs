using AutoMapper;
using Tactsoft.Application.Common;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Country, CountryVM>().ReverseMap();
        CreateMap<State, StateVM>().ReverseMap();
        CreateMap<City, CityVM>().ReverseMap();
        CreateMap<Student, StudentVM>().ReverseMap();
        CreateMap<Employee, EmployeeVM>().ForMember(x=>x.Picture, x => x.MapFrom(src => string.IsNullOrEmpty(src.Picture) ? "" :$"{CommonVariables.PictureLocation}/{src.Picture}"))
            .ReverseMap();
    }
}
