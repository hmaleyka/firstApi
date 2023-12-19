using firstAPI.DAL;
using firstAPI.Entities;
using firstAPI.Entities.Base;
using System.Linq.Expressions;

namespace firstAPI.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //AppDbContext context { get; }
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<T> GetByIdAsync(int id);

        Task Create(T entity);
        void Update (T entity);

        void Delete(T entity);
        Task SaveChangesAsync();

    }
}
