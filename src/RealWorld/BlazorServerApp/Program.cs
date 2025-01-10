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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

string privateKey = "your_secret_key_your_secret_key_your_secret_key";
var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(privateKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = "MyIssuer",
            ValidateIssuer = true,

            ValidAudience = "MyAudience",
            ValidateAudience = true,

            IssuerSigningKey = securityKey,

        };

        x.Events = new()
        {
            OnMessageReceived = context =>
            {
                var cookies = context.HttpContext.Request.Cookies;

                if (cookies.TryGetValue("access-token", out var access_token))
                {
                    context.Token = access_token;
                };

                return Task.CompletedTask;
            }
        };

    });

builder.Services.AddAuthorization();

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



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<DashboardContextHub>("/signalr/dashboard");

app.Run();
