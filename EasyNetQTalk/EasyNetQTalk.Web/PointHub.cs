using EasyNetQTalk.Core;
using Microsoft.AspNet.SignalR;

namespace EasyNetQTalk.Web
{
    public class PointHub : Hub
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

        public void PublishPoint(Point point)
        {
            _broadcaster.PublishPoint(point);
        }
    }
}