using System.Linq.Expressions;

namespace Magic_Villa_VillaAPI.Repository;

public interface IRepository<T> where T : class
{
    public Task SaveChangesAsync();
    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    public Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool isTracked = true);
    public Task CreateAsync(T entity);
    public Task RemoveAsync(T entity);
}
