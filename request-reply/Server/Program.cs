namespace Server
{
    using System;
    using System.Threading;

    using Common;
    using Common.Messages;

    using MassTransit;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var bus = BusFactory.Create(
                "rr-reply",
                configurator =>
                {
                    configurator.Handler<FibonacciRequest>(
                        context =>
                        {
                            var message = context.Message;
                            Console.WriteLine("Requested: {0}", message.Number);
                            return context.RespondAsync(new FiboracciResponse { Number = message.Number, Answer = CalculateFibonacci(message.Number) });
                        });
                });

            Console.WriteLine("[Server started]");
            Console.ReadLine();

            bus.Stop();
        }

        private static int CalculateFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }
}