using Domain.Models;

namespace Domain.Abstractions;

// Szablon (typ ugólniony)
public interface IEntityRepository<T>
    where T : BaseEntity
{
    IEnumerable<T> GetAll();
}

