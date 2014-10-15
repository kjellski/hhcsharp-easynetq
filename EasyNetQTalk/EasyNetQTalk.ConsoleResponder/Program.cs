using System;
using System.Threading;
using EasyNetQ;
using EasyNetQTalk.Core;

namespace EasyNetQTalk.ConsoleResponder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString))
            {
                bus.Respond<Request, Response>(request =>
                {
                    Console.WriteLine("Thinking really hard for " + request.MillisecondsToThink + "ms");
                    Thread.Sleep(request.MillisecondsToThink);
                    return new Response {Result = "We had to work until it was " + DateTime.UtcNow.ToString()};
                });

                Console.WriteLine("Press <Enter> to quit...");
                Console.ReadLine();
            }
        }
    }
}