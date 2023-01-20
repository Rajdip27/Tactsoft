using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAllSt();
        Task<Student> GetById(int id);
        Task<Student> Create (Student student);
        Task Update(Student student);
        Task Delete(int id);
        Task Save();
    }
}
