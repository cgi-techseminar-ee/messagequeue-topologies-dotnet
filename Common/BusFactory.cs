namespace Common
{
    using System;

    using MassTransit;

    public static class BusFactory
    {
        public static IBusControl Create(string queueName, Action<IRabbitMqReceiveEndpointConfigurator> configurator)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(
                config =>
                {
                    var host = config.Host(
                        new Uri("rabbitmq://localhost/techmq"),
                        h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });

                    config.ReceiveEndpoint(host, queueName, configurator);
                });

            bus.Start();

            return bus;
        }
    }
}