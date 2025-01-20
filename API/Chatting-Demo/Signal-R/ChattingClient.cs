
using Microsoft.AspNetCore.SignalR.Client;

namespace Chatting_Demo.Signal_R
{
    public class ChattingClient
    {
        private HubConnection connection;
        public ChattingClient(HubConnection connection)
        {
            this.connection = connection;
        }
        public async Task NotifyNewUser(string userName)
        {
            if(this.connection.State != HubConnectionState.Connected)
                await this.connection.StartAsync();
            await connection.InvokeAsync("NotifyOthersOfNewUser", userName);
        }
    }
}
