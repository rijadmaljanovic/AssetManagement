using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Utility
{
    public interface ITemplateGenerator
    { 
        string HTMLStringAssets();
        string HTMLStringVendors();
        string HTMLStringAssignedAssets();
        string HTMLStringLocations();
        string HTMLStringManufacturers();
        string HTMLStringEmployees();
        string HTMLStringProductType();
        string HTMLStringDepartment();
        string HTMLStringProducts();
    }
    public  class TemplateGenerator:ITemplateGenerator
    {
        public readonly IAssetsRepository assetRepository;
        public readonly IVendorRepository vendorRepository;
        public readonly ILocationRepository locationRepository;
        public readonly IEmployeeRepository employeeRepository;
        public readonly IDepartmentRepository departmentRepository;
        public readonly IProductRepository productRepository;
        public readonly IProductTypeRepository productTypeRepository;


        public TemplateGenerator(IAssetsRepository assetRepository, IProductTypeRepository productTypeRepository, IProductRepository productRepository, IVendorRepository vendorRepository, ILocationRepository locationRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.assetRepository = assetRepository;
            this.vendorRepository = vendorRepository;
            this.locationRepository = locationRepository;
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.productRepository = productRepository;
            this.productTypeRepository = productTypeRepository;

        }
        public  string HTMLStringAssets()
        {
            var assets = assetRepository.All().ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Assets</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>Asset type</th>
                                        <th>Asset category</th>
                                        <th>Vendor</th>
                                        <th>Serial number</th>
                                        <th>Location</th>
                                        <th>Price</th>
                                        <th>Purchase type</th>
                                        <th>Purchase date</th>
                                        <th>Warranty expiry date</th>
                                    </tr>");

            foreach (var a in assets)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td>{8}</td>
                                    <td>{9}</td>
                                  </tr>", a.AssetName, a.AssetType,a.AssetCategory,a.Vendor,a.SerialNumber, a.Location,a.Price, a.PurchaseType,a.PurchaseDate.Date,a.WarrantyExpiryDate.Date);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringVendors()
        {
            var vendors = vendorRepository.All().ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Vendors</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>Phone number</th>
                                        <th>E-mail</th>
                                        <th>Contact person</th>
                                        <th>City</th>
                                        <th>Zipcode</th>
                                        <th>Address</th>
                                        <th>Additional comment</th>
                                    </tr>");

            foreach (var v in vendors)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                  </tr>", v.PartitionKey,v.Phone_Number,v.Email,v.Contact_Person,v.City,v.Zip_Code,v.Address,v.Additional_Comment);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringAssignedAssets()
        {
            var aassets = assetRepository.All().Where(x=>!string.IsNullOrEmpty(x.Employee)).ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Assets assigned to employee</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Asset name</th>
                                        <th>Asset type</th>
                                        <th>Asset category</th>
                                        <th>Vendor</th>
                                        <th>Employee name</th>
                                    </tr>");

            foreach (var aa in aassets)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", aa.AssetName,aa.AssetType,aa.AssetCategory,aa.Vendor,aa.Employee);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringLocations()
        {
            var locations = locationRepository.All().ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Office locations</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Location name</th>
                                        <th>Address</th>
                                        <th>City</th>
                                        <th>Contact person</th>
                                        <th>Contact person phone number</th>
                                        <th>Contact person e-mail</th>
                                    </tr>");

            foreach (var l in locations)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                  </tr>", l.LocationName,l.Address,l.City,l.ContactPersonName,l.ContactPersonPhoneNumber,l.ContactPersonEmail);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringManufacturers()
        {
            int i = 0;
            var manufacturers = productRepository.All().Select(x=>x.Manufacturer).ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Manufacturers</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th></th>
                                        <th>Manufacturer</th>
                                    </tr>");

            foreach (var m in manufacturers)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                  </tr>",++i,m);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringEmployees()
        {
            var employees = employeeRepository.All().ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Employees</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>First name</th>
                                        <th>Last name</th>
                                        <th>Location</th>
                                        <th>E-mail</th>
                                        <th>Phone number</th>
                                    </tr>");

            foreach (var e in employees)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                  </tr>", e.Name,e.LastName,e.Location,e.Email,e.PhoneNumber);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringProductType()
        {
            int i = 0;
            var productTypes = productTypeRepository.All().Select(x=>x.ProductTypeName).ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@" </head>
                            <body>
                                <div class='header'><h1>Product types</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th></th>
                                        <th>Product type</th>
                                    </tr>");

            foreach (var pt in productTypes)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                  </tr>", ++i, pt);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringDepartment()
        {
            int i = 0;
            var departments = departmentRepository.All().Select(x => x.DepartmentName).ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@"</head>
                            <body>
                                <div class='header'><h1>Departments</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th></th>
                                        <th>Department</th>
                                    </tr>");

            foreach (var d in departments)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                  </tr>", ++i, d);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
        public string HTMLStringProducts()
        {
            var products = productRepository.All().ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>");
            sb.Append(@"<style>
                                        .header {
                text-align: center;
                color: darkslategray;
                padding-bottom: 35px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid gray;
                padding: 15px;
                font-size: 20px;
                text-align: center;
            }

            table th {
                background-color: lightgray;
                color: darkslategray;
            }
                                        </style>");
            sb.Append(@" </head>
                            <body>
                                <div class='header'><h1>Products</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>Product category</th>
                                        <th>Product type</th>
                                        <th>Manufacturer</th>
                                        <th>Descriptiom</th>
                                    </tr>");

            foreach (var p in products)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", p.ProductName,p.ProductCategory,p.ProductType,p.Manufacturer,p.Description);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
