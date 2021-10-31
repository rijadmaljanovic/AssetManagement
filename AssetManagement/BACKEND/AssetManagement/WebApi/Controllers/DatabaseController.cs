using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : Controller
    {
        private readonly IDatabaseService databaseService;
        string url = "https://signalr-internship2021.mss.ba/";
        string message = "";
        public DatabaseController(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        //LOCATIONS

        // GET:
        [HttpGet("locations")]
        public IEnumerable<Location> GetLocations()
        {
            return databaseService.ListAllLocations();
        }

        // GET api/<LocationController>/5
        [HttpGet("locations/{id}")]
        public Location Get(string id)
        {
            return databaseService.GetById(id);
        }

        // POST api/<LocationController>
        [HttpPost("locations")]
        public async void Post([FromBody] Location location)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewLocation(location,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Location added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }

        // PUT api/<LocationController>/5
        [HttpPut("locations")]
        public async void Put([FromBody] Location location)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.UpdateLocation(location,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Location edited successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("locations/{id}")]
        public async void DeleteLocation(string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteLocation(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Location deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }



        //DEPARTMENTS

        //GET
        [HttpGet("departments")]
        public IEnumerable<Department> GetDepartments()
        {
            return databaseService.ListAllDepartments();
        }
        //POST (ADD_NEW)
        [HttpPost("departments")]
        public async void Post([FromBody] Department department)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewDepartment(department,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Department added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }
        //DELETE
        [HttpDelete("departments/{id}")]
        public async void DeleteDepartment(string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteDepartment(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Department deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }


        //ASSET_TYPES

        //GET
        [HttpGet("assetTypes")]
        public IEnumerable<AssetType> GetAssetTypes()
        {
            return databaseService.ListAllAssetTypes();
        }
        //POST(ADD_NEW)
        [HttpPost("assetTypes")]
        public async void Post([FromBody] AssetType assetType)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewAssetType(assetType,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset type added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }
        //DELETE
        [HttpDelete("assetTypes/{id}")]
        public async void DeleteAssetType(string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteAssetType(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset type deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }



        //ASSET_CATEGORIES

        //GET
        [HttpGet("assetCategories")]
        public IEnumerable<AssetCategory> GetAssetCategories()
        {
            return databaseService.ListAllAssetCategories();
        }
        //POST(ADD_NEW)
        [HttpPost("assetCategories")]
        public async void Post([FromBody] AssetCategory assetCategory)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewAssetCategory(assetCategory,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset category added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }
        //DELETE
        [HttpDelete("assetCategories/{id}")]
        public async void DeleteAssetCategory(string id)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteAssetCategory(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset category deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }


        //PRODUCT_TYPES
        //GET
        [HttpGet("productTypes")]
        public IEnumerable<ProductType> GetProductTypes()
        {
            return databaseService.ListAllProductTypes();
        }
        //POST(ADD_NEW)
        [HttpPost("productTypes")]
        public async void Post([FromBody] ProductType productType)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewProductType(productType,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product type added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }
        //DELETE
        [HttpDelete("productTypes/{id}")]
        public async void DeleteProductType(string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteProductType(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product type deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }



        //PRODUCT_CATEGORIES
        //GET
        [HttpGet("productCategories")]
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return databaseService.ListAllProductCategories();
        }
        //POST(ADD_NEW)
        [HttpPost("productCategories")]
        public async void Post([FromBody] ProductCategory productCategory)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewProductCategory(productCategory,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product category added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }
        // DELETE 
        [HttpDelete("productCategories/{id}")]
        public async void DeleteProductCategory(string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteProductCategory(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product category deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }



        //EMPLOYEES

        // GET:
        [HttpGet("employees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return databaseService.ListAllEmployees();
        }

        // GET 
        [HttpGet("employees/{id}")]
        public Employee GetOneEmployee(string id)
        {
            return databaseService.GetOneEmployee(id);
        }

        // POST 
        [HttpPost("employees")]
        public async void Post([FromBody] EmployeeModel employee)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.AddNewEmployee(employee,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Employee added successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }

        // PUT 
        [HttpPut("employees")]
        public async void UpdateEmployee([FromBody] Employee employee)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.UpdateEmployee(employee,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Employee edited successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }

        // DELETE 
        [HttpDelete("employees/{id}")]
        public async void DeleteEmployee(string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                databaseService.DeleteEmployee(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Employee deleted successfully!\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }
            }
            catch
            {
                if (Response.StatusCode == 400)
                    message = "{\"type\": \"error\", \"message\": \"Error! Invalid syntax\"}";
                else if (Response.StatusCode == 401)
                    message = "{\"type\": \"error\", \"message\": \"Error ! Not authorized\"}";
                else if (Response.StatusCode == 403)
                    message = "{\"type\": \"error\", \"message\": \"Error! Forbidden\"}";
                else if (Response.StatusCode == 404)
                    message = "{\"type\": \"error\", \"message\": \"Error! Not found\"}";
                else if (Response.StatusCode == 410)
                    message = "{\"type\": \"error\", \"message\": \"Error! Gone\"}";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.PostAsync("api/signalr/user_" + current.RowKey.Replace("-", "") + "/" + message, null);
                }

            }
        }
        
    }
}
