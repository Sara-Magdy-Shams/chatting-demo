using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chatting_Demo.Signal_R
{
    public class ChattingHub : Hub
    {
        public async Task SendToOthers(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }

        public async Task NotifyOthersOfNewUser(string user)
        {
            await Clients.Others.SendAsync("notifyNewUserRegistration", user);
        }

        public async Task BroadcastMessage(string user, string message, string senderConnectionId)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendPrivateMessage(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }
    }
}
