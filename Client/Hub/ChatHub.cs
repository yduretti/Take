using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        #region Property
        private string EventMessage
        {
            get
            {
                return "ReceiveMessage";
            }
        }

        private string UserConnectedMessage
        {
            get
            {
                return "UserConnected";
            }
        }

        private string UserDisconnectedMessage
        {
            get
            {
                return "UserDisconnected";
            }
        }

        #endregion
        
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync(this.EventMessage, message);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync(this.EventMessage, message);
        }

        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync(this.EventMessage, message);
        }

        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task SendMessageToGroup(string group, string message)
        {
            return Clients.Group(group).SendAsync(this.EventMessage, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync(this.UserConnectedMessage, Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync(this.UserDisconnectedMessage, Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
    }
}