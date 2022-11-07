using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);            

            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            //return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.UserLeaved(Context.ConnectionId);


            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
    }
}
