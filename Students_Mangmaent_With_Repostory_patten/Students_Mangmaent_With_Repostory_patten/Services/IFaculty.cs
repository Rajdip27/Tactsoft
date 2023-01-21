using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public interface IFaculty
    {
        Task<IEnumerable<Faculty>> GetAllF();
        Task<Faculty> Create(Faculty faculty);
        Task<Faculty> Update(Faculty faculty);
        Task<Faculty> GetById(int id);
        Task Delete(int id);
        Task Save();
    }
}
