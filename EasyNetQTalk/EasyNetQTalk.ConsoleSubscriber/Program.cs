using System;
using EasyNetQ;
using EasyNetQTalk.Core;

namespace EasyNetQTalk.ConsoleSubscriber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var rabbitMQBus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString))
            {
                rabbitMQBus.Subscribe<Point>("EasyNetQTalk.ConsoleSubscriber",
                    point => Console.WriteLine("Point(" + point.X + ", " + point.Y + ")."));

                Console.WriteLine("Press <Enter> to quit...");
                Console.ReadLine();
            }
        }
    }
}