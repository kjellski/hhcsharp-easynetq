using System;
using EasyNetQ;
using EasyNetQTalk.Core;

namespace EasyNetQTalk.ConsoleSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString))
            {
                String input;
                Console.WriteLine("Enter a point, two numbers separated by something. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Send("my.queue", new MessageOne {Content = new ContentOne {Number = 1337}});
                }

                Console.WriteLine("Press <Enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}