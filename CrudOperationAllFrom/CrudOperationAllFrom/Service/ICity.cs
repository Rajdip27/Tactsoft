using CrudOperation.Models;

namespace CrudOperationAllFrom.Service
{
    public interface ICity
    {
        Task<IEnumerable<City>> GetAll();
        Task<City> GetById(int id);
        Task<City> Create(City city);
        Task<City> Update(City city);
        Task Delete(int id);
        Task Save();
    }
}
