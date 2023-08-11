using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRAuth.Shared;

namespace SignalRAuth.Server;

[Authorize]
public class ChatHub : Hub
{
    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}