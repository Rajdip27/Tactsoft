using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public interface ICource
    {
        Task<IEnumerable<Cource>> GetAllCo();
        Task<Cource> GetById(int id);
        Task<Cource> Create(Cource cource);
        Task<Cource> Update(Cource cource);
        Task Delete(int id);
        Task Save();
    }
}
