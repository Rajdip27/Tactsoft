using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Service
{
    public class StateService : IState
    {
        private readonly ApplicationDbContext _dbContext;
        public StateService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<State> Create(State state)
        {
           await _dbContext.AddAsync(state);
            return state;
        }

        public async Task Delete(int id)
        {
           var Result = await _dbContext.States.FindAsync(id);
            _dbContext.Entry(Result).State=EntityState.Deleted;
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            return await _dbContext.States.ToListAsync();
        }

        public async Task<State> GetById(int id)
        {
            return await _dbContext.States.FindAsync(id);
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task<State> Update(State state)
        {
            _dbContext.Entry(state).State=EntityState.Modified;
            return state;
        }

        
    }
}
