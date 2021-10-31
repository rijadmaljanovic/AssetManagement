using Models;
using Models.Model;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IReportsService
    {
        IEnumerable<Asset> GetAssets();
        IEnumerable<VendorEntity> GetVendors();
        IEnumerable<Asset> GetAssignedAssets();
        IEnumerable<Location> GetLocations();
        IEnumerable<string> GetManufacturers();
        IEnumerable<Employee> GetEmployees();
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<Department> GetDepartments();
        IEnumerable<Product> GetProducts();
    }
    public class ReportsService : IReportsService
    {
        public readonly IAssetsRepository assetRepository;
        public readonly IVendorRepository vendorRepository;
        public readonly ILocationRepository locationRepository;
        public readonly IEmployeeRepository employeeRepository;
        public readonly IDepartmentRepository departmentRepository;
        public readonly IProductRepository productRepository;
        public readonly IProductTypeRepository productTypeRepository;


        public ReportsService(IAssetsRepository assetRepository, IProductTypeRepository productTypeRepository, IProductRepository productRepository, IVendorRepository vendorRepository, ILocationRepository locationRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.assetRepository = assetRepository;
            this.vendorRepository = vendorRepository;
            this.locationRepository = locationRepository;
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.productRepository = productRepository;
            this.productTypeRepository = productTypeRepository;

        }
        public IEnumerable<Asset> GetAssets()
        {
           return assetRepository.All();
        }
        public IEnumerable<VendorEntity> GetVendors()
        {
            return vendorRepository.All();
        }
        public IEnumerable<Asset> GetAssignedAssets()
        {
            return assetRepository.All().Where(x => !string.IsNullOrEmpty(x.Employee));
        }

        public IEnumerable<Department> GetDepartments()
        {
            return departmentRepository.All();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepository.All();
        }

        public IEnumerable<Location> GetLocations()
        {
            return locationRepository.All();
        }

        public IEnumerable<string> GetManufacturers()
        {
            return productRepository.All().Select(x => x.Manufacturer);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.All();
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return productTypeRepository.All();
        }
    }
}
