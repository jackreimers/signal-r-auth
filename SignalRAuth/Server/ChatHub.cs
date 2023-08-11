using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRAuth.Shared;

namespace SignalRAuth.Server;

public class ChatHub : Hub
{
    [Authorize]
    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
    
    public async Task SendMessageNoAuth(ChatMessage message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    [Authorize]
    public async IAsyncEnumerable<int> StreamCount([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var count = 10;
        var delay = 1000;
        
        for (var i = 0; i < count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return i;

            await Task.Delay(delay, cancellationToken);
        }
    }
}