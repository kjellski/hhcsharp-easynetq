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
                Console.WriteLine(
@"Enter a Number to send a message with type: EasyNetQTalk.Core.MessageOne
Enter a Text to send a message with type: EasyNetQTalk.Core.MessageTwo
Enter 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    int number;
                    if (Int32.TryParse(input, out number))
                    {
                        bus.Send(QueueConfiguration.MessageQueueName, new MessageOne { Content = new ContentOne { Number = number } });
                        continue;
                    }
                    bus.Send(QueueConfiguration.MessageQueueName, new MessageTwo { Content = new ContentTwo { Text = input } });
                }

                Console.WriteLine("Press <Enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}