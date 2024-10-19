
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        private DbSet<T> GetDbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await GetDbSet<T>().AddAsync(entity);
        }

        public IQueryable<T?> All<T>() where T : class
        {
            return GetDbSet<T>();
        }

        public IQueryable<T?> AllReadonly<T>() where T : class
        {
            return GetDbSet<T>().AsNoTracking();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            GetDbSet<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<T?> GetById<T>(object id) where T : class
        {
            return await GetDbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
