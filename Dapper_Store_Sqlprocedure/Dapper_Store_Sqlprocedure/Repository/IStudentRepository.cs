using Dapper_Store_Sqlprocedure.Models;

namespace Dapper_Store_Sqlprocedure.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<bool> Update(Student student);
        Task<bool> Delete(int id);
        Task<bool> Create(Student student);
    }
}
