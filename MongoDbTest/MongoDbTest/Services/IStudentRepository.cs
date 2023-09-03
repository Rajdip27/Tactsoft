using MongoDbTest.Models;

namespace MongoDbTest.Services;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(string id);
    Task<Student> CreateAsync(Student  student);
    Task UpdateAsync(string id, Student student);
    Task DeleteAsync(string id);
}
