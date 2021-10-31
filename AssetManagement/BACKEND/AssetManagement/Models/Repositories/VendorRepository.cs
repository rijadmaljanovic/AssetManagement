using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Models;

namespace WebApi
{
    public interface IVendorRepository
    {
        IEnumerable<VendorEntity> All();
        void CreateOrUpdate(VendorEntity entity);
        void Delete(VendorEntity entity);
        VendorEntity Get(string partitionKey, string rowKey);
        VendorEntity GetById(string rowKey);
    }
    public class VendorRepository:IVendorRepository
    {

        private CloudTable vendorTable = null;
        public VendorRepository()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");

            var tableClient = storageAccount.CreateCloudTableClient();

            vendorTable = tableClient.GetTableReference("devVendor");

            vendorTable.CreateIfNotExists();

        }

        public IEnumerable<VendorEntity> All()
        {
            var query = new TableQuery<VendorEntity>();

            var entities = vendorTable.ExecuteQuery(query);

            return entities;
        }

        public void CreateOrUpdate(VendorEntity entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            vendorTable.Execute(operation);
        }

        public void Delete(VendorEntity entity)
        {
            var operation = TableOperation.Delete(entity);
            vendorTable.Execute(operation);
        }

        public VendorEntity Get(string partitionKey, string rowKey)
        {
            var operation = TableOperation.Retrieve<VendorEntity>(partitionKey, rowKey);

            var result = vendorTable.Execute(operation);

            return result.Result as VendorEntity;
        }

        public VendorEntity GetById(string rowKey)
        {
            var query = new TableQuery<VendorEntity>();

            var entities = vendorTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }

    }
}
