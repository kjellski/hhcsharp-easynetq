using System;
using EasyNetQ;
using EasyNetQTalk.Core;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace EasyNetQTalk.Web
{
    public class PointBroadcaster
    {
        private static readonly Lazy<PointBroadcaster> Broadcaster = new Lazy<PointBroadcaster>(()
            => new PointBroadcaster(GlobalHost.ConnectionManager.GetHubContext<PointHub>().Clients, RabbitMQConfiguration.ConnectionString));

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IBus _rabbitMQBus;

        public Point LatestPoint = new Point(0, 0);
        public readonly IHubConnectionContext Clients;

        private PointBroadcaster(IHubConnectionContext clients, string rabbitMQConnectionString)
        {
            _rabbitMQBus = RabbitHutch.CreateBus(rabbitMQConnectionString);
            Clients = clients;

            _rabbitMQBus.Subscribe<Point>("EasyNetQTalk.Web", point =>
            {
                LatestPoint = point;
                Clients.All.updatePoint(point);
            });
        }

        public void PublishPoint(Point point)
        {
            var topic = point.GetQuadrant();

            _rabbitMQBus.Publish(point, topic);
        }

        public static PointBroadcaster Instance
        {
            get { return Broadcaster.Value; }
        }
    }
}