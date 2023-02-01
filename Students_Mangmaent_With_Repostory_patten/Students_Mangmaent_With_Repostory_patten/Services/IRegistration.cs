using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public interface IRegistration
    {
        Task<IEnumerable<Registrion>> GetAllSt();
        Task<Registrion> GetById(int id);
        Task<Registrion> Create (Registrion registrion);
        Task Update(Registrion  registrion);
        Task Delete(int id);
        Task Save();
    }
}
