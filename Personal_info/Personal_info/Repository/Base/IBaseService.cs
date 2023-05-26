using Personal_info.Models.Base;
using System.Linq.Expressions;

namespace Personal_info.Repository.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IQueryable<T> All();
        IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(params Expression<Func<T, Object>>[] includes);
        Task<T> FindAsync(long id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        T Find(long id);
        T Find(Int64 id, params Expression<Func<T, Object>>[] includeProperties);
        void Insert(T entity);
        void Update(T entity, long id);
        void Delete(T entity);

        Task InsertAsync(T entity);
        Task UpdateAsync(long id, T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
