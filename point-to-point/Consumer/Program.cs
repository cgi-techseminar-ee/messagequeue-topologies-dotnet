namespace Consumer
{
    using System;
    using System.Threading.Tasks;

    using Common;
    using Common.Messages;

    using MassTransit;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Point-to-point: Consumer";
            var bus = BusFactory.Create("pp-consumer",
                configurator =>
                {
                    //configurator.UseConcurrencyLimit(1);
                    configurator.Handler<Person>(Handler);
                });

            Console.WriteLine("[Ready]");
            Console.ReadLine();

            bus.Stop();
        }

        private static Task Handler(ConsumeContext<Person> context)
        {
            return Handler(context.Message);
        }

        private static Task Handler(Person message)
        {
            Console.WriteLine("[{0}] {1}", message.Id, message.Name);
            return Task.Delay(100);
        }
    }
}