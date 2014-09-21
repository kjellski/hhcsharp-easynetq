using System;
using System.Reactive.Subjects;
using EasyNetQ;
using EasyNetQTalk.Core;
using Nancy;

namespace EasyNetQTalk.Web
{
    public class PointModule : NancyModule
    {
        private readonly Subject<Point> _pointSubject = new Subject<Point>();
        private Point _point = new Point();
        private IBus _bus;


        public PointModule()
            : base("api/point")
        {
            InitializeEasyNetQ();

            Get["/"] = x => Response.AsText("");
        }

        private void InitializeEasyNetQ()
        {
            _bus = RabbitHutch.CreateBus("host=192.168.47.129");
            _bus.Subscribe<Point>("EasyNetQTalk.Web", point => _pointSubject.OnNext(point));
        }
    }
}