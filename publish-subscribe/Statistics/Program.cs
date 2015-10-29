namespace Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Common;
    using Common.Messages;

    using MassTransit;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Pub-sub: Statistics";

            var bus = BusFactory.Create("ps-statistics",
                configurator =>
                {
                    configurator.Handler<DriveToOrder>(Handler);
                });

            Console.WriteLine("[Ready]");
            Console.ReadLine();

            bus.Stop();
        }

        private static Task Handler(ConsumeContext<DriveToOrder> context)
        {
            return Handler(context.Message);
        }

        private static readonly Dictionary<string, int> Stats = new Dictionary<string, int>();

        private static Task Handler(DriveToOrder message)
        {
            Console.Clear();

            if (Stats.ContainsKey(message.Name))
            {
                Stats[message.Name]++;
            }
            else
            {
                Stats.Add(message.Name, 1);
            }

            foreach (var kvp in Stats.OrderByDescending(a => a.Value))
            {
                Console.WriteLine("{0} - {1}", kvp.Value, kvp.Key);
            }

            return Task.CompletedTask;
        }
    }
}