using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> All();
        Product Get(string rowKey);
        void CreateOrUpdate(Product product);
        void Delete(Product product);
    }
    public class ProductRepository : IProductRepository
    {
        private CloudTable productTable;
        public ProductRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            productTable = tableClient.GetTableReference("devProduct");
            productTable.CreateIfNotExists();
        }
        public IEnumerable<Product> All()
        {
            var query = new TableQuery<Product>();
            var entities = productTable.ExecuteQuery(query);
            return entities;
        }

        public void CreateOrUpdate(Product product)
        {
            var operation = TableOperation.InsertOrReplace(product);
            productTable.Execute(operation);
        }

        public void Delete(Product product)
        {
            var operation = TableOperation.Delete(product);
            productTable.Execute(operation);
        }

        public Product Get(string rowKey)
        {
            var query = new TableQuery<Product>();
            var entities = productTable.ExecuteQuery(query);
            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
    }
}
