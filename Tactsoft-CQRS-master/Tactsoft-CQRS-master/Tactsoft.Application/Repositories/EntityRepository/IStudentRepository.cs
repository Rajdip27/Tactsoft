using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.Base;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Repository.EntityRepository;

public interface IStudentRepository : IBaseRepository<Student, StudentVM, long>
{

}
