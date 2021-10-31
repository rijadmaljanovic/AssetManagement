using Microsoft.AspNetCore.Http;
using Models;
using Models.Model;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IAssetsService
    {
        IEnumerable<ListAssetsModel> ListAssets();
        AssetRefValues AddNewAsset();
        void SaveNewAsset(AssetModel newasset,User u);
        AssetEmployeeRefValues AssignToEmployee();
        void AssignToEmployeeSave(AssetEmployeeModel model,string id);
        void DeleteAsset(string assetRowKey);
    }
    public class AssetsService : IAssetsService
    {
       public readonly IAssetsRepository assetsRepository;
        public readonly IAssetCategoryRepository assetCategoryRepository;
        public readonly ILocationRepository locationRepository;
        public readonly IAssetTypeRepository assetTypeRepository;
        public readonly IEmployeeRepository employeeRepository;
        public readonly IVendorRepository vendorRepository;
        public readonly IDepartmentRepository departmentRepository;
        public readonly IAssetEmployeeRepository assetEmployeeRepository;

        public AssetsService(IAssetsRepository assetsRepository,IAssetEmployeeRepository assetEmployeeRepository, IVendorRepository vendorRepository, IDepartmentRepository departmentRepository,IAssetCategoryRepository assetCategoryRepository,IAssetTypeRepository assetTypeRepository,ILocationRepository locationRepository,IEmployeeRepository employeeRepository)
        {
            this.assetsRepository = assetsRepository;
            this.assetCategoryRepository = assetCategoryRepository;
            this.assetTypeRepository = assetTypeRepository;
            this.locationRepository = locationRepository;
            this.vendorRepository = vendorRepository;
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.assetEmployeeRepository = assetEmployeeRepository;
        }
        public AssetRefValues AddNewAsset()
        {
            IEnumerable<AssetCategory> categories = assetCategoryRepository.All();
            IEnumerable<AssetType> assetTypes = assetTypeRepository.All();
            IEnumerable<Location> locations = locationRepository.All();
            IEnumerable<VendorEntity> vendors = vendorRepository.All();
            var purchaseTypeRepo = new PurchaseTypeRepository();
            List<PurchaseType> purchaseTypes = purchaseTypeRepo.All();

            return new AssetRefValues()
            {
                Categories = categories.Select(x => x.AssetCategoryName),
                Locations = locations.Select(x => x.LocationName),
                Vendors = vendors.Select(x => x.PartitionKey),
                Types = assetTypes.Select(x => x.AssetTypeName),
                PurchaseTypes = purchaseTypes.Select(x => x.PurchaseTypeName).ToList()
            };
        }
        public void SaveNewAsset(AssetModel newAsset,User u)
        {
            var novi = new Asset
            {
                RowKey=Guid.NewGuid().ToString(),
                PartitionKey=newAsset.AssetType,
                AssetName=newAsset.AssetName,
                AssetCategory=newAsset.AssetCategory,
                AssetType=newAsset.AssetType,
                Vendor=newAsset.Vendor,
                SerialNumber=newAsset.SerialNumber,
                Location=newAsset.Location,
                Price=newAsset.Price,
                PurchaseDate=newAsset.PurchaseDate,
                PurchaseType=newAsset.PurchaseType,
                WarrantyExpiryDate=newAsset.WarrantyExpiryDate,
                UserId = u.RowKey
            };
            assetsRepository.CreateOrUpdate(novi);
        }
        public AssetEmployeeRefValues AssignToEmployee()
        {
            IEnumerable<Asset> assets = assetsRepository.All();
            IEnumerable<Employee> employees = employeeRepository.All();
            return new AssetEmployeeRefValues()
            {
                Assets = assets,
                Employees = employees
            };
        }
        public void AssignToEmployeeSave(AssetEmployeeModel model,string id)
        {
            Asset asset= assetsRepository.Get(id);
            Employee employee = employeeRepository.Get(model.EmployeeId);
            asset.Employee = employee.Name + " " + employee.LastName;
            AssetEmployee novi = new AssetEmployee()
            {
                PartitionKey = id,
                RowKey = Guid.NewGuid().ToString(),
                AssetId = id,
                EmployeeId = model.EmployeeId
            };
            assetsRepository.CreateOrUpdate(asset);
            assetEmployeeRepository.Add(novi);
        }
        public IEnumerable<ListAssetsModel> ListAssets()
        {
            int i = 0;
            var asset = assetsRepository.All();
            var assetModel = asset.Select(x => new ListAssetsModel
            {
                Number=++i,
                Id = x.RowKey,
                AssetType = x.PartitionKey,
                AssetName = x.AssetName,
                Vendor = x.Vendor,
                Employee = x.Employee == string.Empty || x.Employee == null ? " ":x.Employee,
                CurrentState= x.Employee == string.Empty || x.Employee == null ? "Not assigned to employee" : "Assigned to employee"
            }) ;
            return assetModel;
        }
        public void DeleteAsset(string assetRowKey)
        {
           Asset assetToDelete= assetsRepository.Get(assetRowKey);
           AssetEmployee ae = assetEmployeeRepository.GetAll().FirstOrDefault(x => x.AssetId == assetRowKey);
            if (ae!=null)
            {
                assetEmployeeRepository.Delete(ae);
            }
           assetsRepository.Delete(assetToDelete);
        }
    }
}
