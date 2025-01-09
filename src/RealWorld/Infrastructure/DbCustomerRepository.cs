using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class DbCustomerRepository : ICustomerRepository
{
    public Task Add(Customer entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetBySearchTextAsync(string searchText)
    {
        throw new NotImplementedException();
    }
}
