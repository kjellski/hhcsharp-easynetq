using Microsoft.AspNet.SignalR;

namespace EasyNetQTalk.Web
{
    internal class PointHub : Hub
    {
        private readonly PointBroadcaster _broadcaster;

        public PointHub()
            : this(PointBroadcaster.Instance)
        {
        }

        public PointHub(PointBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }
    }
}