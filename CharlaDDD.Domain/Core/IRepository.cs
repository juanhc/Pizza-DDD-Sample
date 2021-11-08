using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CharlaDDD.Domain.Core
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
