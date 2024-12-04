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
}
