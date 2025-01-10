
using BlazorServerApp.Hubs;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BlazorServerApp.BackroundServices;

public class DashboardContextBackroundService(
    ILogger<DashboardContextBackroundService> logger,
    IHubContext<DashboardContextHub> hubContext
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var context = new DashboardContext
            {
                TotalSales = Random.Shared.Next(1, 100000),
                NewUsers = Random.Shared.Next(10, 20),
                ActiveSessions = Random.Shared.Next(10, 50)
            };

            logger.LogInformation("Context {TotalSales} {NewUsers} {ActiveSessions}", context.TotalSales, context.NewUsers, context.ActiveSessions);


            await hubContext.Clients.All.SendAsync("DashboardChanged", context);

            await Task.Delay(1000);
        }

    }
}
