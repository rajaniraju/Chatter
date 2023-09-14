using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub:Hub
    {
        private readonly string _botUser;
        public ChatHub()
        {
            _botUser = "MyChat_Bot";
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
            await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage",_botUser,$"{ userConnection.User} has joined{userConnection.Room}");
        }
    }
}
