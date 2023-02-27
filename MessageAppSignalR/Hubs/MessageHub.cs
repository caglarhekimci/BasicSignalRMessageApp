using Microsoft.AspNetCore.SignalR;

namespace MessageAppSignalR.Hubs
{
    public class MessageHub : Hub
    {
        public static List<string> _products = new();
        public async Task SendProduct(string messageInfo)
        {
            _products.Add(messageInfo);
            await Clients.All.SendAsync("ReceiveProduct", messageInfo, _products.Count());
        }
        public async Task ResetProduct()
        {
            _products.Clear();
            await Clients.All.SendAsync("ReceiveResetProduct");
        }
    }
}
