using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService reportsService;
        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }
        // GET: api/<ReportsController>
        [HttpGet("assets")]
        public IEnumerable<Asset> GetAssets()
        {
            return reportsService.GetAssets();
        }
        [HttpGet("vendors")]
        public IEnumerable<VendorEntity> GetVendors()
        {
            return reportsService.GetVendors();
        }
        [HttpGet("assignedAssets")]
        public IEnumerable<Asset> GetAssignedAssets()
        {
            return reportsService.GetAssignedAssets();
        }
        [HttpGet("departments")]
        public IEnumerable<Department> GetDepartments()
        {
            return reportsService.GetDepartments();
        }
        [HttpGet("employees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return reportsService.GetEmployees();
        }
        [HttpGet("locations")]
        public IEnumerable<Location> GetLocations()
        {
            return reportsService.GetLocations();
        }
        [HttpGet("manufacturers")]
        public IEnumerable<string> Manufacturers()
        {
            return reportsService.GetManufacturers();
        }
        [HttpGet("products")]
        public IEnumerable<Product> Products()
        {
            return reportsService.GetProducts();
        }
        [HttpGet("productTypes")]
        public IEnumerable<ProductType> ProductTypes()
        {
            return reportsService.GetProductTypes();
        }
    }
}
