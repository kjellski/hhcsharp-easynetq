using System;
using EasyNetQ;
using EasyNetQTalk.Core;

namespace EasyNetQTalk.ConsoleReceiver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var rabbitMQBus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString))
            {
                rabbitMQBus.Receive(QueueConfiguration.MessageQueueName, registration =>
                {
                    registration.Add<MessageOne>(
                        one => Console.WriteLine("Received Message of type " + one.GetType().FullName + " with content: " + one.Content.Number));
                    registration.Add<MessageTwo>(
                        two => Console.WriteLine("Received Message of type " + two.GetType().FullName + " with content: " + two.Content.Text));
                });

                Console.WriteLine("Press <Enter> to quit...");
                Console.ReadLine();
            }
        }
    }
}