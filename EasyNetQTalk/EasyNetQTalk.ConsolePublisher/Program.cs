using System;
using System.Text.RegularExpressions;
using EasyNetQ;
using EasyNetQTalk.Core;

namespace EasyNetQTalk.ConsolePublisher
{
    internal class Program
    {
        private static void Main()
        {
            using (var bus = RabbitHutch.CreateBus(RabbitMQConfiguration.ConnectionString))
            {
                String input;
                Console.WriteLine("Enter a point, two numbers separated by something. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    var point = GetPointFrom(input);

                    if(point != null)
                        bus.Publish(point);
                }
            }
        }

        private static Point GetPointFrom(String input)
        {
            try
            {
                var regex = new Regex(@"\d+");
                var xString = regex.Matches(input)[0].Value;
                var yString = regex.Matches(input)[1].Value;

                var point = new Point(int.Parse(xString), int.Parse(yString));

                return point;
            }
            catch (Exception)
            {
                Console.WriteLine("Try again, format is \"<number> <number>\"");
                return null;
            }
        }
    }
}