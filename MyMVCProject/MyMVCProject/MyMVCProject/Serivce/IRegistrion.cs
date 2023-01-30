using MyMVCProject.Models;

namespace MyMVCProject.Serivce
{
    public interface IRegistrion
    {
        Task<IEnumerable<Registration>> GetAll();
        Task<Registration> GetById(int id);
        Task<Registration> Create(Registration registration);
        Task Update(Registration registration);
        Task DeleteById(int id);
        Task Save();
    }
}
