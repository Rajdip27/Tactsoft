using First_Jqery_Project.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using First_Jqery_Project.DatabaseContext;

namespace First_Jqery_Project.Repository.Base
{
    public class BaseService<T>:IBaseService<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        public BaseService(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public IQueryable<T> All()
        {
            return entities;
        }
        public IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> queryable = All();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            { queryable = queryable.Include<T, object>(includeProperty); }
            return queryable;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, Object>>[] includes)
        {
            return await includes.Aggregate(
                entities.AsQueryable(),
                (current, include) => current.Include(include)).ToListAsync();
        }
        public async Task<T> FindAsync(long id) => await entities.FindAsync(id);

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(entities.AsQueryable(),
                (current, include) => current.Include(include),
                c => c.AsNoTracking().FirstOrDefaultAsync(predicate)
            ).ConfigureAwait(false);
        }




        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Find(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreatedDateUtc = DateTime.UtcNow;
            entity.UpdatedDateUtc = DateTime.UtcNow;
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity, long id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            T exist = _context.Set<T>().Find(id);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }

        public async Task UpdateAsync(long id, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            T exist = _context.Set<T>().Find(id);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task InsertAsync(T entity)
        {
            entity.CreatedDateUtc = DateTime.UtcNow;
            entity.UpdatedDateUtc = DateTime.UtcNow;

            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

    }
}

