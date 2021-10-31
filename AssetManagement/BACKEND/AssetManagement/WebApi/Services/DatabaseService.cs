using Models.Model;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IDatabaseService
    {
        //LOCATIONS
        IEnumerable<Location> ListAllLocations();
        Location GetOne(string partitionKey, string rowKey);
        void AddNewLocation(Location location,User u);
        void UpdateLocation(Location location,User u);
        void DeleteLocation(string rowKey);
        Location GetById(string rowKey);

        //DEPARTMENTS
        IEnumerable<Department> ListAllDepartments();
        void AddNewDepartment(Department department,User u);
        void DeleteDepartment(string rowKey);

        //ASSET_CATEGORIES
        IEnumerable<AssetCategory> ListAllAssetCategories();
        void AddNewAssetCategory(AssetCategory assetCategory,User u);
        void DeleteAssetCategory(string rowKey);

        //ASSET_TYPES
        IEnumerable<AssetType> ListAllAssetTypes();
        void AddNewAssetType(AssetType assetType,User u);
        void DeleteAssetType(string rowKey);

        //PRODUCT_CATEGORIES
        IEnumerable<ProductCategory> ListAllProductCategories();
        void AddNewProductCategory(ProductCategory productCategory,User u);
        void DeleteProductCategory(string rowKey);

        //PRODUCT_TYPES
        IEnumerable<ProductType> ListAllProductTypes();
        void AddNewProductType(ProductType productType,User u);
        void DeleteProductType(string rowKey);

        //EMPLOYEES
        IEnumerable<Employee> ListAllEmployees();
        void AddNewEmployee(EmployeeModel employee,User u);
        Employee GetOneEmployee(string rowKey);
        void DeleteEmployee(string rowKey);
        void UpdateEmployee(Employee location,User u);
        Employee GetByIdEmployee(string rowKey);

    }
    public class DatabaseService : IDatabaseService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IAssetCategoryRepository assetCategoryRepository;
        private readonly IAssetTypeRepository assetTypeRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IEmployeeRepository employeeRepository;

        public DatabaseService(ILocationRepository locationRepository, IDepartmentRepository departmentRepository, IAssetCategoryRepository assetCategoryRepository,
          IAssetTypeRepository assetTypeRepository, IProductCategoryRepository productCategoryRepository, IProductTypeRepository productTypeRepository,
          IEmployeeRepository employeeRepository)
        {
            this.locationRepository = locationRepository;
            this.departmentRepository = departmentRepository;
            this.assetCategoryRepository = assetCategoryRepository;
            this.assetTypeRepository = assetTypeRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.productTypeRepository = productTypeRepository;
            this.employeeRepository = employeeRepository;
        }


        //LOCATIONS
        public IEnumerable<Location> ListAllLocations()
        {
            return locationRepository.All();
        }

        public void AddNewLocation(Location location,User u)
        {
            Location newLocation = new Location()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                City = location.City,
                Address = location.Address,
                ContactPersonName = location.ContactPersonName,
                ContactPersonEmail = location.ContactPersonEmail,
                ContactPersonPhoneNumber = location.ContactPersonPhoneNumber,
                LocationName = location.LocationName,
                UserId = u.RowKey
            };
            locationRepository.CreateOrUpdate(newLocation);
        }
        public Location GetOne(string partitionKey, string rowKey)
        {
            return locationRepository.Get(partitionKey, rowKey);
        }

        public void DeleteLocation(string rowKey)
        {
            Location location = locationRepository.GetById(rowKey);

            locationRepository.Delete(location);
        }

        public void UpdateLocation(Location location,User u)
        {
            Location loc = locationRepository.Get(location.PartitionKey, location.RowKey);

            loc.LocationName = location.LocationName;
            loc.City = location.City;
            loc.Address = location.Address;
            loc.ContactPersonName = location.ContactPersonName;
            loc.ContactPersonEmail = location.ContactPersonEmail;
            loc.ContactPersonPhoneNumber = location.ContactPersonPhoneNumber;
            loc.UserId = u.RowKey;
            locationRepository.CreateOrUpdate(loc);
        }
        public Location GetById(string rowKey)
        {
            return locationRepository.GetById(rowKey);
        }

        //DEPARTMENTS
        public IEnumerable<Department> ListAllDepartments()
        {
            return departmentRepository.All();
        }
        public void AddNewDepartment(Department department,User u)
        {
            Department newDepartment = new Department
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                DepartmentName = department.DepartmentName,
                UserId = u.RowKey
            };
            departmentRepository.CreateOrUpdate(newDepartment);
        }
        public void DeleteDepartment(string rowKey)
        {
            Department department = departmentRepository.GetById(rowKey);

            departmentRepository.Delete(department);
        }


        //ASSET_CATEGORIES
        public IEnumerable<AssetCategory> ListAllAssetCategories()
        {
            return assetCategoryRepository.All();
        }
        public void AddNewAssetCategory(AssetCategory assetCategory,User u)
        {
            AssetCategory newAssetCategory = new AssetCategory
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                AssetCategoryName = assetCategory.AssetCategoryName,
                UserId = u.RowKey
            };
            assetCategoryRepository.CreateOrUpdate(newAssetCategory);
        }
        public void DeleteAssetCategory(string rowKey)
        {
            AssetCategory assetCategory = assetCategoryRepository.GetById(rowKey);

            assetCategoryRepository.Delete(assetCategory);
        }


        //ASSET_TYPES
        public IEnumerable<AssetType> ListAllAssetTypes()
        {
            return assetTypeRepository.All();
        }
        public void AddNewAssetType(AssetType assetType,User u)
        {
            AssetType newAssetType = new AssetType
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                AssetTypeName = assetType.AssetTypeName,
                UserId = u.RowKey
            };
            assetTypeRepository.CreateOrUpdate(newAssetType);
        }
        public void DeleteAssetType(string rowKey)
        {
            AssetType assetType = assetTypeRepository.GetById(rowKey);

            assetTypeRepository.Delete(assetType);
        }


        //PRODUCT_CATEGORIES
        public IEnumerable<ProductCategory> ListAllProductCategories()
        {
            return productCategoryRepository.All();
        }
        public void AddNewProductCategory(ProductCategory productCategory,User u)
        {
            ProductCategory newProductCategory = new ProductCategory
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                ProductCategoryName = productCategory.ProductCategoryName,
                UserId = u.RowKey
            };
            productCategoryRepository.CreateOrUpdate(newProductCategory);
        }
        public void DeleteProductCategory(string rowKey)
        {
            ProductCategory productCategory = productCategoryRepository.GetById(rowKey);

            productCategoryRepository.Delete(productCategory);
        }


        //PRODUCT_TYPES
        public IEnumerable<ProductType> ListAllProductTypes()
        {
            return productTypeRepository.All();
        }
        public void AddNewProductType(ProductType productType,User u)
        {
            ProductType newProductType = new ProductType
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                ProductTypeName = productType.ProductTypeName,
                UserId = u.RowKey
            };
            productTypeRepository.CreateOrUpdate(newProductType);
        }
        public void DeleteProductType(string rowKey)
        {
            ProductType productType = productTypeRepository.GetById(rowKey);

            productTypeRepository.Delete(productType);
        }


        //EMPLOYEES
        public IEnumerable<Employee> ListAllEmployees()
        {
            return employeeRepository.All();
        }

        public void AddNewEmployee(EmployeeModel employee,User u)
        {
            Department d = departmentRepository.GetById(employee.DepartmentID);
            Employee newEmployee = new Employee()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                Name = employee.Name,
                LastName = employee.LastName,
                Location = employee.Location,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Department=d.DepartmentName,
                UserId = u.RowKey
            };
            employeeRepository.CreateOrUpdate(newEmployee);
        }
        
        public Employee GetOneEmployee(string rowKey)
        {
            return employeeRepository.Get(rowKey);
        }

        public void DeleteEmployee(string rowKey)
        {
            Employee employee = employeeRepository.GetById(rowKey);

            employeeRepository.Delete(employee);
        }

        public void UpdateEmployee(Employee employee,User u)
        {
            Employee emp = employeeRepository.Get(employee.RowKey);

            emp.Name = emp.Name;
            emp.LastName = emp.LastName;
            emp.Location = emp.Location;
            emp.Email = emp.Email;
            emp.PhoneNumber = emp.PhoneNumber;
            emp.Department = emp.Department;
            emp.UserId = u.RowKey;

            employeeRepository.CreateOrUpdate(emp);
        }
        public Employee GetByIdEmployee(string rowKey)
        {
            return employeeRepository.GetById(rowKey);
        }
    }
}

