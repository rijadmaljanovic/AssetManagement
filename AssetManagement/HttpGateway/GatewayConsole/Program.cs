using Gateway;
using Gateway.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GatewayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new RabbitmqRepository();

            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://riki:kikiriki@rabbitmq-internship2021.mss.ba:5672"),
                DispatchConsumersAsync = true
            };
            const string queueName = "internship-queue";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queue = channel.QueueDeclare(queueName, true, false, false, null);

                // consumer
               
                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;
                channel.BasicConsume(queueName, true, consumer);

                // publisher

                var props = channel.CreateBasicProperties();

                while (true)
                {
                    Thread.Sleep(1000);
                }
            }

            async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
            {
                var message = Encoding.UTF8.GetString(@event.Body.ToArray());
                RabbitMqEntity obj =JsonConvert.DeserializeObject<RabbitMqEntity>(message);
                

                repository.CreateOrUpdate(new RabbitMqEntity()
                {
                    Latitude =obj.Latitude,
                    Longitude=obj.Longitude,
                    DeviceName=obj.DeviceName,
                    SecurityKey=obj.SecurityKey,
                    PartitionKey = Guid.NewGuid().ToString(),
                    RowKey = Guid.NewGuid().ToString()
                });

                Console.WriteLine($"Coordinates: {obj.Latitude} - {obj.Longitude}");
                await Task.Delay(250);
                Thread.Sleep(1000);
            }
        }
    }
}
