using System;
using EasyNetQ;
using EasyNetQTalk.Core;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace EasyNetQTalk.Web
{
    public class PointBroadcaster
    {
        private static readonly Lazy<PointBroadcaster> _broadcaster = new Lazy<PointBroadcaster>(()
            => new PointBroadcaster(GlobalHost.ConnectionManager.GetHubContext<PointHub>().Clients, RabbitMQConfiguration.ConnectionString));

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private static readonly IBus Bus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString);

        public Point LatestPoint = new Point(0, 0);
        private readonly IHubConnectionContext _clients;

        private PointBroadcaster(IHubConnectionContext clients, string rabbitMQConnectionString)
        {
            _clients = clients;

            Bus.Subscribe<Point>("EasyNetQTalk.Web", point =>
            {
                LatestPoint = point;
                _clients.All.updatePoint(point);
            });
        }

        public static PointBroadcaster Instance
        {
            get { return _broadcaster.Value; }
        }
    }
}