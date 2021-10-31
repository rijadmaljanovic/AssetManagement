using Gateway.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public interface IRabbitMqService
    {
        void SendMessage(DataObj obj, GetPayloadModel payload);
        IEnumerable<RabbitMqEntity> GetData(string deviceName);

    }
    public class RabbitMqService : IRabbitMqService
    {
        public readonly IRabbitmqRepository rabbitMqRepository;

        public RabbitMqService(IRabbitmqRepository rabbitMqRepository)
        {
            this.rabbitMqRepository = rabbitMqRepository;
        }

        public void SendMessage(DataObj obj, GetPayloadModel payload)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://riki:kikiriki@rabbitmq-internship2021.mss.ba:5672")

            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("internship-queue",
               durable: true,
               exclusive: false,
               autoDelete: false,
               arguments: null
                );

            var message = new RabbitMqEntity() { DeviceName = obj.DeviceName, SecurityKey = obj.SecurityKey, Latitude = payload.Latitude,Longitude=payload.Longitude };
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish("", "internship-queue", null, body);
        }
        public IEnumerable<RabbitMqEntity> GetData(string deviceName)
        {
            IEnumerable<RabbitMqEntity> payloads = rabbitMqRepository.All().Where(z => z.DeviceName == deviceName);
            
            return payloads;
        }
    }
}
