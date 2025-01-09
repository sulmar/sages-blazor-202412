using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeCustomerRepository : ICustomerRepository
{
    private IDictionary<int, Customer> _customers;

    public FakeCustomerRepository(IEnumerable<Customer> customers)
    {


        _customers = customers.ToDictionary(p => p.Id);
    }

    public Task Add(Customer entity)
    {
        int id = _customers.Values.Max(p => p.Id);

        entity.Id = ++id;

       _customers.Add(entity.Id, entity);

        return Task.CompletedTask;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers.Values.ToList();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = GetAll();

        return Task.FromResult(customers);
    }

    public Task<Customer> GetById(int id)
    {
        if (_customers.TryGetValue(id, out var result))
        {
            return Task.FromResult(result);
        }
        else
        {
            return Task.FromResult<Customer>(null);
        }
    }

    public Task<IEnumerable<Customer>> GetBySearchTextAsync(string searchText)
    {
        return Task.FromResult(GetBySearchText(searchText));
    }

    private IEnumerable<Customer> GetBySearchText(string searchText)
    {
        return _customers
            .Select(c => c.Value)
            .Where(c => c.FirstName.Contains(searchText) || c.LastName.Contains(searchText));
    }
}
