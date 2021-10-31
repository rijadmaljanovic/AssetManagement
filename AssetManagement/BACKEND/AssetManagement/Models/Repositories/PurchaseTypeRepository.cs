using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    
    public class PurchaseTypeRepository
    {
        private CloudTable purchaseTypeTable = null;
        public PurchaseTypeRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            purchaseTypeTable = tableClient.GetTableReference("devPurchaseType");
            purchaseTypeTable.CreateIfNotExists();
        }
        public List<PurchaseType> All()
        {
            return new List<PurchaseType>() {
            new PurchaseType()
            {
                PurchaseTypeName="Owned"
            },
            new PurchaseType()
            {
                PurchaseTypeName = "Leased"
            },
            new PurchaseType()
            {
                PurchaseTypeName = "Rented"
            },
            new PurchaseType()
            {
                PurchaseTypeName = "Subscription"
            }
            };
        }
    }
}
