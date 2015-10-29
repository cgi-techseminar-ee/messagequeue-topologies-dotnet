namespace Producer
{
    using System;

    using Common;
    using Common.Messages;

    internal static class Program
    {
        private static void Main()
        {
            Console.Title = "Competing consumers: Producer";

            var db = new CitiesDatabase();

            var bus = BusFactory.Create("cc-producer", configurator => { });

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
                    bus.Publish(new City { Id = i, Name = db.GetRandom() }).Wait();
                }
            }

            bus.Stop();
        }
    }
}