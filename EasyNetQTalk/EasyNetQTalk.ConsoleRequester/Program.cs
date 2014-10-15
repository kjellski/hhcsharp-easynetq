using System;
using EasyNetQ;
using EasyNetQTalk.Core;

namespace EasyNetQTalk.ConsoleRequester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString))
            {
                String input;
                Console.WriteLine("Enter a number representing the ms to think for a response. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    int ms;
                    if (!int.TryParse(input, out ms)) continue;

                    var responseTask = bus.RequestAsync<Request, Response>(new Request {MillisecondsToThink = ms});
                    responseTask.ContinueWith(task => Console.WriteLine(task.Result.Result));
                }
            }
        }
    }
}