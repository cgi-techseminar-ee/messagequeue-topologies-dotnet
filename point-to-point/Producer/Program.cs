namespace Producer
{
    using System;

    using Common;
    using Common.Messages;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Point-to-point: Producer";

            var db = new NamesDatabase();

            var bus = BusFactory.Create("pp-producer", configurator => { });

            var line = "1";
            while (!string.IsNullOrEmpty(line))
            {
                Console.Write("Enter number: ");
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                for (var i = 1; i <= int.Parse(line); i++)
                {
                    bus.Publish(new Person { Id = i, Name = db.GetRandom() }).Wait();
                }
            }

            bus.Stop();
        }
    }
}