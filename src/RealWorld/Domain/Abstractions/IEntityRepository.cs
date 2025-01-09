using Domain.Models;

namespace Domain.Abstractions;

// Szablon (typ ugólniony)
public interface IEntityRepository<T>
    where T : BaseEntity
{
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetById(int id);
    Task Add(T entity);
}

