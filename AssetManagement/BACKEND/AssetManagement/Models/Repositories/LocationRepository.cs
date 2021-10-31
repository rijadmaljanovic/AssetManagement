using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface ILocationRepository
    {
        IEnumerable<Location> All ();
        void CreateOrUpdate(Location entity);
        void Delete(Location entity);
        Location Get(string partitionKey, string rowKey);
        Location GetById(string rowKey);
    }
    public class LocationRepository : ILocationRepository
    {
        private CloudTable locationTable = null;
        public LocationRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            locationTable = tableClient.GetTableReference("devLocation");
            locationTable.CreateIfNotExists();
        }
        
        public IEnumerable<Location> All()
        {
            var query = new TableQuery<Location>();
            var entities = locationTable.ExecuteQuery(query);
            return entities;
        }
        public void CreateOrUpdate(Location entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            locationTable.Execute(operation);
        }

        public void Delete(Location entity)
        {
            var operation = TableOperation.Delete(entity);
            locationTable.Execute(operation);
        }

        public Location Get(string partitionKey, string rowKey)
        {
            var operation = TableOperation.Retrieve<Location>(partitionKey, rowKey);

            var result = locationTable.Execute(operation);

            return result.Result as Location;
        }

        public Location GetById(string rowKey)
        {
            var query = new TableQuery<Location>();

            var entities = locationTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
    }
}
