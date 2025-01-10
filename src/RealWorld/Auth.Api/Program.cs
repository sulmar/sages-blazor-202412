using Auth.Api.Abstractions;
using Auth.Api.Infrastructure;
using Auth.Api.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITokenService, JwtTokenService>();

var app = builder.Build();

app.MapGet("/", () => "Hello Auth.Api!");

app.MapPost("api/login", ([FromForm] LoginRequest request, ITokenService tokenService, HttpContext context) =>
{
    if (request.Login == "john" && request.Password == "123")
    {
        UserIdentity userIdentity = new UserIdentity("john", "John", "Smith", "john@domain.com");

        var accessToken = tokenService.CreateAccessToken(userIdentity);

        context.Response.Cookies.Append("access-token", accessToken, new CookieOptions
        {
            HttpOnly = true, // blokuje dostêp z js do document.cookie
            Secure = true,
            Expires = DateTimeOffset.UtcNow.AddMinutes(15)
        });

        return Results.Ok(new { accessToken });

    }

    return Results.Unauthorized();
}).DisableAntiforgery();

app.Run();
