using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Repositories
{
    public interface IProductCategoryRepository
    {
        void CreateOrUpdate(ProductCategory entity);
        void Delete(ProductCategory entity);
        ProductCategory GetById(string rowKey);
        IEnumerable<ProductCategory> All();
    }
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private CloudTable productCategoryTable = null;
        public ProductCategoryRepository()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");

            var tableClient = storageAccount.CreateCloudTableClient();

            productCategoryTable = tableClient.GetTableReference("devProductCategory");

            productCategoryTable.CreateIfNotExists();
        }
        public void CreateOrUpdate(ProductCategory entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            productCategoryTable.Execute(operation);
        }

        public void Delete(ProductCategory entity)
        {
            var operation = TableOperation.Delete(entity);
            productCategoryTable.Execute(operation);
        }
        public ProductCategory GetById(string rowKey)
        {
            var query = new TableQuery<ProductCategory>();

            var entities = productCategoryTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
        public IEnumerable<ProductCategory> All()
        {
            var query = new TableQuery<ProductCategory>();
            var entities = productCategoryTable.ExecuteQuery(query);
            return entities;
        }
    }
}
