using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Repositories
{
    public interface IProductTypeRepository
    {
        void CreateOrUpdate(ProductType entity);
        void Delete(ProductType entity);
        ProductType GetById(string rowKey);
        IEnumerable<ProductType> All();
    }
    public class ProductTypeRepository: IProductTypeRepository
    {
        private CloudTable productTypeTable = null;
        public ProductTypeRepository()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");

            var tableClient = storageAccount.CreateCloudTableClient();

            productTypeTable = tableClient.GetTableReference("devProductType");

            productTypeTable.CreateIfNotExists();
        }
        public void CreateOrUpdate(ProductType entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            productTypeTable.Execute(operation);
        }
        public IEnumerable<ProductType> All()
        {
            var query = new TableQuery<ProductType>();
            var entities = productTypeTable.ExecuteQuery(query);
            return entities;
        }
        public void Delete(ProductType entity)
        {
            var operation = TableOperation.Delete(entity);
            productTypeTable.Execute(operation);
        }
        public ProductType GetById(string rowKey)
        {
            var query = new TableQuery<ProductType>();

            var entities = productTypeTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
    }
}
