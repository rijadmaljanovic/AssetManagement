using Models.Model;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IProductService
    {
        IEnumerable<ListProductsModel> GetProducts();
        ProductRefValues GetRefValues();
        void SaveProduct(ProductModel model,User u);
        void DeleteProduct(string id);
        void EditProduct(string id, ProductModel model);


    }
    public class ProductService:IProductService
    {
        public readonly IProductRepository productRepository;
        public readonly IProductTypeRepository productTypeRepository;
        public readonly IProductCategoryRepository productCategoryRepository;
        public ProductService(IProductRepository productRepository, IProductTypeRepository productTypeRepository, IProductCategoryRepository productCategoryRepository)
        {
            this.productRepository = productRepository;
            this.productTypeRepository = productTypeRepository;
            this.productCategoryRepository = productCategoryRepository;

        }

        public void DeleteProduct(string id)
        {
            Product p = productRepository.Get(id);
            productRepository.Delete(p);
        }

        public IEnumerable<ListProductsModel> GetProducts()
        {
            int i = 0;
            var products = productRepository.All();
            var model = products.Select(x => new ListProductsModel
            {
                Number=++i,
                Id=x.RowKey,
                ProductCategory=x.ProductCategory,
                ProductName=x.ProductName,
                ProductType=x.ProductType
            });
            return model;
        }
        public ProductRefValues GetRefValues()
        {
            var productTypes = productTypeRepository.All();
            var productCategories = productCategoryRepository.All();
            return new ProductRefValues()
            {
                ProductCategories = productCategories,
                ProductTypes = productTypes
            };
        }

        public void SaveProduct(ProductModel model,User u)
        {
            ProductType pt = productTypeRepository.GetById(model.ProductTypeId);
            ProductCategory pc = productCategoryRepository.GetById(model.ProductCategoryId);
            Product novi = new Product()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                ProductCategory = pc.ProductCategoryName,
                ProductType = pt.ProductTypeName,
                ProductName=model.ProductName,
                Description = model.Description,
                Manufacturer = model.Manufacturer,
                UserId = u.RowKey
            };
            productRepository.CreateOrUpdate(novi);
        }
        public void EditProduct(string id,ProductModel model)
        {
            ProductType pt = productTypeRepository.GetById(model.ProductTypeId);
            ProductCategory pc = productCategoryRepository.GetById(model.ProductCategoryId);
            Product p= productRepository.Get(id);
            p.Manufacturer = model.Manufacturer;
            p.ProductCategory = pc.ProductCategoryName;
            p.ProductType = pt.ProductTypeName;
            p.ProductName = model.ProductName;
            productRepository.CreateOrUpdate(p);
        }

    }
}
