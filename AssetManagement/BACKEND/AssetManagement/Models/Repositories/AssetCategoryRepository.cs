using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IAssetCategoryRepository
    {
        IEnumerable<AssetCategory> All();
        void CreateOrUpdate(AssetCategory entity);
        void Delete(AssetCategory entity);
        AssetCategory GetById(string rowKey);
    }
    public class AssetCategoryRepository : IAssetCategoryRepository
    {
        private CloudTable assetCategoryTable = null;
        public AssetCategoryRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            assetCategoryTable = tableClient.GetTableReference("devAssetCategory");
            assetCategoryTable.CreateIfNotExists();
        }
        public IEnumerable<AssetCategory> All()
        {
            var query = new TableQuery<AssetCategory>();
            var entities = assetCategoryTable.ExecuteQuery(query);
            return entities;
        }
        public void CreateOrUpdate(AssetCategory entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            assetCategoryTable.Execute(operation);
        }

        public void Delete(AssetCategory entity)
        {
            var operation = TableOperation.Delete(entity);
            assetCategoryTable.Execute(operation);
        }
        public AssetCategory GetById(string rowKey)
        {
            var query = new TableQuery<AssetCategory>();

            var entities = assetCategoryTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
    }
}
