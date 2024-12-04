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

    public IEnumerable<Customer> GetAll()
    {
        return _customers.Values.ToList();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = GetAll();

        return Task.FromResult(customers);
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


public class DbCustomerRepository : ICustomerRepository
{
    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetBySearchTextAsync(string searchText)
    {
        throw new NotImplementedException();
    }
}
