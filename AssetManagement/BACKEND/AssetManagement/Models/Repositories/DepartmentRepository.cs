using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> All();
        void CreateOrUpdate(Department entity);
        void Delete(Department entity);
        Department GetById(string rowKey);
    }
    public class DepartmentRepository:IDepartmentRepository
    {
        private CloudTable departmentTable = null;
        public DepartmentRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            departmentTable = tableClient.GetTableReference("devDepartment");
            departmentTable.CreateIfNotExists();
        }
        
        public IEnumerable<Department> All()
        {
            var query = new TableQuery<Department>();
            var entities = departmentTable.ExecuteQuery(query);
            return entities;
        }
        public void CreateOrUpdate(Department entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            departmentTable.Execute(operation);
        }

        public void Delete(Department entity)
        {
            var operation = TableOperation.Delete(entity);
            departmentTable.Execute(operation);
        }
        public Department GetById(string rowKey)
        {
            var query = new TableQuery<Department>();

            var entities = departmentTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }
    }
}
