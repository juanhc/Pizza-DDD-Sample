using CharlaDDD.Domain.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CharlaDDD.Infrastructure
{
    public class GenericRepository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        private readonly PizzaOrdersDbContext _context;

        public GenericRepository(PizzaOrdersDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);

            return entity;
        }

        public T Update(T entity)
        {
            _context.Update(entity);

            return entity;
        }

        public T Delete(T entity)
        {
            _context.Remove(entity);

            return entity;
        }

        public IQueryable<T> GetAll() => _context.Set<T>().AsQueryable();

        public async Task<T> GetByIdAsync(int id) => await _context.FindAsync<T>(id);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);
    }
}
