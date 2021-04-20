using System.Collections.Generic;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        bool Exists(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
