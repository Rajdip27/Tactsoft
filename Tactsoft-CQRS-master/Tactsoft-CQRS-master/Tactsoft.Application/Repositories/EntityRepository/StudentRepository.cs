using AutoMapper;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.Base;
using Tactsoft.Domain.Entities;
using Tactsoft.Infrastructure.AppContext;

namespace Tactsoft.Application.Repository.EntityRepository;

public class StudentRepository : BaseRepository<Student, StudentVM, long>, IStudentRepository
{
    public StudentRepository(IMapper mapper, TactsoftDbContext context) : base(mapper, context)
    {

    }

}
