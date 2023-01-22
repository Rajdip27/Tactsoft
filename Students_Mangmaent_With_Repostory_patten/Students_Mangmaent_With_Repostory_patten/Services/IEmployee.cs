using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task Delete(int id);
        Task Save();

    }
}
