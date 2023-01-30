using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Create(Customer customer);
       // Task<Customer> Update(Customer customer);
        Task Delete(int id);
        Task Save();
    }
}
