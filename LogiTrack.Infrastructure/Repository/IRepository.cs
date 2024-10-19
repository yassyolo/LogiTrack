namespace LogiTrack.Infrastructure.Repository
{
    public interface IRepository
    {
        IQueryable<T?> All<T>() where T : class;
        IQueryable<T?> AllReadonly<T>() where T : class;
        Task<T?> GetById<T>(object id) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
