using System;
using EasyNetQ;
using EasyNetQTalk.Core;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace EasyNetQTalk.Web
{
    public class PointBroadcaster
    {
        private static readonly Lazy<PointBroadcaster> Broadcaster = new Lazy<PointBroadcaster>(()
            => new PointBroadcaster(GlobalHost.ConnectionManager.GetHubContext<PointHub>().Clients, RabbitMQConfiguration.ConnectionString));

        public readonly IHubConnectionContext Clients;

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IBus _rabbitMQBus;

        public Point LatestPoint = new Point(0, 0);

        private PointBroadcaster(IHubConnectionContext clients, string rabbitMQConnectionString)
        {
            _rabbitMQBus = RabbitHutch.CreateBus(rabbitMQConnectionString);
            Clients = clients;

            _rabbitMQBus.Subscribe<Point>("canvas", point =>
            {
                LatestPoint = point;
                Clients.All.updatePoint(point);
            });

            // subscribe topic based
            _rabbitMQBus.Subscribe<Point>("canvas-1", point => Clients.All.updatePoint1(point), x => x.WithTopic("1"));
            _rabbitMQBus.Subscribe<Point>("canvas-2", point => Clients.All.updatePoint2(point), x => x.WithTopic("2"));
            _rabbitMQBus.Subscribe<Point>("canvas-3", point => Clients.All.updatePoint3(point), x => x.WithTopic("3"));
            _rabbitMQBus.Subscribe<Point>("canvas-4", point => Clients.All.updatePoint4(point), x => x.WithTopic("4"));
        }

        public static PointBroadcaster Instance
        {
            get { return Broadcaster.Value; }
        }

        public void PublishPoint(Point point)
        {
            _rabbitMQBus.Publish(point); // type based
            _rabbitMQBus.Publish(point, point.GetQuadrant()); // topic based
        }
    }
}