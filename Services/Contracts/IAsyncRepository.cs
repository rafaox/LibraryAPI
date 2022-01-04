using System.Linq.Expressions;
using LibraryApi.DataAccessLayer.Contracts;

namespace LibraryApi.Services.Contracts
{
    public interface IAsyncRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class, IEntity;
        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        Task AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity;
        Task<IEnumerable<TEntity>> GetWhereAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        Task<int> CountAllAsync<TEntity>() where TEntity : class, IEntity;
        Task<int> CountWhereAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class, IEntity;

        Task SaveChangesAsync();
    }
}