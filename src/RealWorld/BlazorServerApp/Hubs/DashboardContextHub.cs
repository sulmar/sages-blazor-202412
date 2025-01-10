using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerApp.Hubs;

public class DashboardContextHub(ILogger<DashboardContextHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {

        // zła praktyka
        // logger.LogInformation($"Connected {Context.ConnectionId}");

        // dobra praktyka
        logger.LogInformation("Connected {ConnectionId}", Context.ConnectionId);


        return base.OnConnectedAsync();
    }
}
