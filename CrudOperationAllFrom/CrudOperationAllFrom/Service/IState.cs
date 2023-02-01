using CrudOperation.Models;

namespace CrudOperationAllFrom.Service
{
    public interface IState
    {
        Task<IEnumerable<State>> GetAll();
        Task<State> GetById(int id);
        Task<State> Create(State state);
        Task<State> Update(State state);
        Task Delete(int id);
        Task Save();
    }
}
