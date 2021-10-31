using Microsoft.Azure.Cosmos.Table;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> All();
        Employee Get(string id);
        void Delete(Employee entity);
        Employee GetById(string rowKey);
        void CreateOrUpdate(Employee entity);

    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private CloudTable employeeTable = null;
        public EmployeeRepository()
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=internship002;AccountKey=VhG928egfhCi/9yjcK5j4/5PnYpgkk00Ib1ZdsaVFgplwXsU3EG/WtNtT3rCF50ccKI9n5JvawrGX8Ohn+RRhg==;EndpointSuffix=core.windows.net");
            var tableClient = storageAccount.CreateCloudTableClient();
            employeeTable = tableClient.GetTableReference("devEmployee");
            employeeTable.CreateIfNotExists();
        }

        public Employee Get(string id)
        {
            var query = new TableQuery<Employee>();
            var entities = employeeTable.ExecuteQuery(query);
            return entities.FirstOrDefault(x => x.RowKey == id);
        }

        public IEnumerable<Employee> All()
        {
            var query = new TableQuery<Employee>();
            var entities = employeeTable.ExecuteQuery(query);
            return entities;
        }
        public void CreateOrUpdate(Employee entity)
        {
            var operation = TableOperation.InsertOrReplace(entity);
            employeeTable.Execute(operation);
        }
        public void Delete(Employee entity)
        {
            var operation = TableOperation.Delete(entity);
            employeeTable.Execute(operation);
        }


        public Employee GetById(string rowKey)
        {
            var query = new TableQuery<Employee>();

            var entities = employeeTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.RowKey == rowKey);
        }

        public Employee GetByName(string name)
        {
            var query = new TableQuery<Employee>();

            var entities = employeeTable.ExecuteQuery(query);

            return entities.FirstOrDefault(x => x.Name + " " + x.LastName == name);
        }
    }
}
