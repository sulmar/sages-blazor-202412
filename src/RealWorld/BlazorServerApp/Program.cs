using BlazorServerApp.Components;
using BlazorServerApp.Models;
using BlazorServerApp.Services;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Blazored.LocalStorage;
using BlazorServerApp.Hubs;
using BlazorServerApp.BackroundServices;
using System.Security.Principal;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddSingleton<IEnumerable<Customer>>(sp =>
        [
            new Customer { Id  = 1, FirstName = "John", LastName = "Smith" },
            new Customer { Id  = 2, FirstName = "Kate", LastName = "Smith" },
            new Customer { Id  = 3, FirstName = "Bob", LastName = "Smith" },
            new Customer { Id  = 4, FirstName = "Ann", LastName = "Smith" },
            new Customer { Id  = 5, FirstName = "Adam", LastName = "Smith" },
        ]);

builder.Services.AddSingleton<CounterContext>();
builder.Services.AddSingleton<ApplicationState>();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddHostedService<DashboardContextBackroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

ClaimsPrincipal

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<DashboardContextHub>("/signalr/dashboard");

app.Run();
