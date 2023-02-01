using CrudOperation.Models;

namespace CrudOperationAllFrom.Service
{
    public interface ICountry
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<Country> Create(Country  country);
        Task<Country> Update(Country country);
        Task Delete(int id);
        Task Save();
    }
}
