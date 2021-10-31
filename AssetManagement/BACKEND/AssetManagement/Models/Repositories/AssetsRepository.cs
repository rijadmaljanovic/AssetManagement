using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IAssetsRepository
    {
        IEnumerable<Asset> All();
        Asset Get(string rowKey);
        void CreateOrUpdate(Asset asset);
        void Delete(Asset asset);
    }
    public class AssetsRepository : IAssetsRepository
    {
        private CloudTable assetTable;
        public AssetsRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            assetTable = tableClient.GetTableReference("devAsset");
            assetTable.CreateIfNotExists();
        }
        
        public void CreateOrUpdate(Asset asset)
        {
            var operation = TableOperation.InsertOrReplace(asset);
            assetTable.Execute(operation);
        }

        public void Delete(Asset asset)
        {
            var operation = TableOperation.Delete(asset);
            assetTable.Execute(operation);
        }

        public Asset Get(string rowKey)
        {
            var query = new TableQuery<Asset>();
            var entities = assetTable.ExecuteQuery(query);
            return entities.FirstOrDefault(x=>x.RowKey==rowKey);
        }

        public IEnumerable<Asset> All()
        {
            var query = new TableQuery<Asset>();
            var entities = assetTable.ExecuteQuery(query);
            return entities;
        }

    }
}
