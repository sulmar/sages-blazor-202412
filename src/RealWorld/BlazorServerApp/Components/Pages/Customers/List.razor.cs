using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Components.Pages.Customers;

public partial class List
{
    // .NET 9
    //public List(ICustomerRepository Repository)
    //{
    //    this.Repository = Repository;
    //}

    [Inject]
    private ICustomerRepository Repository {  get; set; }

    private IEnumerable<Customer> Customers { get; set; }

    protected override void OnInitialized()
    {
        Customers = Repository.GetAll();
    }

}
