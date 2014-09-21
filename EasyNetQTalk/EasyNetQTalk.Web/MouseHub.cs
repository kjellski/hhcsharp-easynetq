using Microsoft.AspNet.SignalR;

namespace EasyNetQTalk.Web
{
    public class MouseHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}