namespace Consumer
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Common;
    using Common.Messages;

    using MassTransit;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Process.Start("consumer", "1");
                Process.Start("consumer", "2");
                return;
            }

            Console.Title = "Competing consumers: Consumer - " + args[0];

            var bus = BusFactory.Create("cc-consumer",
                configurator =>
                {
                    configurator.UseConcurrencyLimit(1);
                    configurator.Handler<City>(Handler);
                });

            Console.WriteLine("[Ready]");
            Console.ReadLine();

            bus.Stop();
        }

        private static Task Handler(ConsumeContext<City> context)
        {
            return Handler(context.Message);
        }

        private static Task Handler(City message)
        {
            Console.WriteLine("[{0}] {1}", message.Id, message.Name);
            return Task.Delay(100);
        }
    }
}