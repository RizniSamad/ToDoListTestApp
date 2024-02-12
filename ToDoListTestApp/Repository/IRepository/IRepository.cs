using Ardalis.Specification;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Entity.Interfaces;

namespace ToDoListTestApp.Repository.IRepository
{
    public interface IRepository<T> where T : class, IAggregatedRoot
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetFirstOrDefaultAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}
