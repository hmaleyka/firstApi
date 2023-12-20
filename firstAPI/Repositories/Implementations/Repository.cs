using firstAPI.DAL;
using firstAPI.Entities;
using firstAPI.Entities.Base;
using firstAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace firstAPI.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private AppDbContext _dbcontext;
        private DbSet<T> _table;
        public Repository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _table = _dbcontext.Set<T>();
        }

       

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object >>? OrderByExpression = null,
            bool isDescending=false
            ,params string[] includes)
        {
            IQueryable<T> query =  _dbcontext.Set<T>();

            if(includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }

            if(OrderByExpression !=null)
            {
                query = isDescending ? query.OrderByDescending(OrderByExpression) : query.OrderBy(OrderByExpression);
            }

            if(expression is not null)
            {
                query = query.Where(expression);
            }


            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbcontext.Set<T>().AsNoTracking().FirstOrDefaultAsync(b=>b.Id==id);
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async  Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        //Task<IQueryable<T>> IRepository<T> .GetAll(Expression<Func<T, bool>>? expression, params string[] includes)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<T> IRepository<T>.GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
