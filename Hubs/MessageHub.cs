using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller
            //Sadece server'a bildirim gönderen client'la iletişim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            //Server'a bağlı olan tüm client'larla iletişim kurar
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            //Sadece Server'a bildirim gönderen client dışında Servar'a bağlı olan tüm client'lara mesaj gönderir.
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Metotları
            #region All Expect
            //Belirtilen clientlar hariç server'a bağlı olan tüm clientlara bildiride bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            //Belirli bir clienta bildirimde bulunur.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            //Seçilen clients'lara bildirim gönderir
            //await Clients.Clients(connectionIds).SendAsync(message);
            #endregion
            #region Group
            //Belirtilen grouptaki tüm clientlara bildirimde bulunan bir fonsiyon
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region GroupExcept
            //Belirtilen grouptaki belirtilen clientlar dışında tüm clientlara mesaj iletimi sağlayan bir fonsiyon,
            List<string> groups = new List<string>();
            //await Clients.GroupExcept(groupName, clientIds).SendAsync("receiveMessage", message);
            #endregion
            #region Groups
            //Birden fazla grouba mesaj göndermeni sağlar
            //await Clients.GroupExcept(groupName, groups).SendAsync("receiveMessage", message);
            #endregion
            #region OthersInGroup
            //Belirtilen grupta client hariç diğer kişilere bildirim gönderir
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region User
            await Context.User.Identity.;
            //await Clients.User()

            #endregion
            #region Users

            #endregion
            #endregion
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
