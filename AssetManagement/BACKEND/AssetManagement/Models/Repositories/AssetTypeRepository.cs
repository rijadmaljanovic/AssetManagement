using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IAssetTypeRepository
    {
        IEnumerable<AssetType> All();
        void CreateOrUpdate(AssetType entity);
        void Delete(AssetType entity);
        AssetType GetById(string rowKey);
    }
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private CloudTable assetTypeTable = null;
        public AssetTypeRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            assetTypeTable = tableClient.GetTableReference("devAssetType");
            assetTypeTable.CreateIfNotExists();
        }
       
        public IEnumerable<AssetType> All()
        {
            var query = new TableQuery<AssetType>();
            var entities = assetTypeTable.ExecuteQuery(query);
            return entities;
        }
        public void CreateOrUpdate(AssetType entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            assetTypeTable.Execute(operation);
        }

        public void Delete(AssetType entity)
        {
            var operation = TableOperation.Delete(entity);
            assetTypeTable.Execute(operation);
        }
        public AssetType GetById(string rowKey)
        {
            var query = new TableQuery<AssetType>();

            var entities = assetTypeTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
    }
}
