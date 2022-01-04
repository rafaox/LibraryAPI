using Microsoft.EntityFrameworkCore;
using LibraryApi.DataAccessLayer.Contracts;
using LibraryApi.DataAccessLayer.LibraryApiDbContext;
using LibraryApi.Services.Contracts;

namespace LibraryApi.Services.Repositories
{
    public class AsyncRepository : IAsyncRepository
    {
        private readonly LibraryApiDbContext _context;

        public AsyncRepository(LibraryApiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CountAllAsync<TEntity>() where TEntity : class, IEntity
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task<int> CountWhereAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class, IEntity
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Set<TEntity>().Update(entity);
        }

        IQueryable<TEntity> IAsyncRepository.GetQueryable<TEntity>()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
    }
}