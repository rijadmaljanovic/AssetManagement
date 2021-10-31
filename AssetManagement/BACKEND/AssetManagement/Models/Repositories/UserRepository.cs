using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IUserRepository
    {
        void CreateOrUpdate(User model);
        IEnumerable<User> All();
    }
    public class UserRepository : IUserRepository
    {
        private CloudTable users;
        public UserRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            users = tableClient.GetTableReference("devUser");
            users.CreateIfNotExists();
        }
        public void CreateOrUpdate(User model)
        {
            var operation = TableOperation.InsertOrReplace(model);
            users.Execute(operation);
        }
        public IEnumerable<User> All()
        {
            var query = new TableQuery<User>();
            var entities = users.ExecuteQuery(query);
            return entities;
        }
    }
}
