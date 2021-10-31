using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IAssetEmployeeRepository
    {
        IEnumerable<AssetEmployee> GetAll();
        AssetEmployee GetByAssetId(string id);
        void Add(AssetEmployee assetEmployee);
        void Delete(AssetEmployee ae);
    }

    public class AssetEmployeeRepository : IAssetEmployeeRepository
    {
        private CloudTable assetEmployeeTable = null;

        public AssetEmployeeRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            assetEmployeeTable = tableClient.GetTableReference("devAssetEmployee");
            assetEmployeeTable.CreateIfNotExists();
        }

        public void Add(AssetEmployee assetEmployee)
        {
            var operation = TableOperation.InsertOrReplace(assetEmployee);
            assetEmployeeTable.Execute(operation);
        }

        public IEnumerable<AssetEmployee> GetAll()
        {
            var query = new TableQuery<AssetEmployee>();
            var entities = assetEmployeeTable.ExecuteQuery(query);
            return entities;
        }

        public AssetEmployee GetByAssetId(string id)
        {
            var query = new TableQuery<AssetEmployee>();
            var entities = assetEmployeeTable.ExecuteQuery(query);
            return entities.FirstOrDefault(x => x.AssetId == id);
        }
        public void Delete(AssetEmployee ae)
        {
            var operation = TableOperation.Delete(ae);
            assetEmployeeTable.Execute(operation);
        }
    }

}
