using Gateway.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway
{
    public interface IRabbitmqRepository
    {
        IEnumerable<RabbitMqEntity> All();
        void CreateOrUpdate(RabbitMqEntity entity);

    }
    public class RabbitmqRepository: IRabbitmqRepository
    {
        private CloudTable rabbitmqTable = null;
        public RabbitmqRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net;");

            var tableClient = storageAccount.CreateCloudTableClient();

            rabbitmqTable = tableClient.GetTableReference("devKoordinate");

            rabbitmqTable.CreateIfNotExists();

        }
        public IEnumerable<RabbitMqEntity> All()
        {
            var query = new TableQuery<RabbitMqEntity>();
            var entities = rabbitmqTable.ExecuteQuery(query);
            return entities;
        }
        public void CreateOrUpdate(RabbitMqEntity entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            rabbitmqTable.Execute(operation);
        }
    }
    
}
