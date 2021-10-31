using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.Model;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        string url = "https://signalr-internship2021.mss.ba/";
        string message = "";
        VendorRepository repository = new VendorRepository();

        [HttpGet]
        public IEnumerable<VendorModel> Index()
        {
            var entities = repository.All();
            var models = entities.Select(x => new VendorModel
            {
                Guid = x.RowKey,
                Vendor_Name = x.PartitionKey,
                Phone_Number = x.Phone_Number,
                Email = x.Email,
                Contact_Person = x.Contact_Person,
                City = x.City,
                Zip_Code = x.Zip_Code,
                Address = x.Address,
                Additional_Comment = x.Additional_Comment,
            });

            return models;
        }

        [HttpPost]
        public async void Create(VendorModel model)
        {
            User current = (User)HttpContext.Items["User"];

            try {

                repository.CreateOrUpdate(new VendorEntity
                {
                    PartitionKey = model.Vendor_Name,
                    RowKey = Guid.NewGuid().ToString(),
                    Phone_Number = model.Phone_Number,
                    Email = model.Email,
                    Contact_Person = model.Contact_Person,
                    City = model.City,
                    Zip_Code = model.Zip_Code,
                    Address = model.Address,
                    Additional_Comment = model.Additional_Comment,
                    UserId = current.RowKey

                }) ;

                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Vendor added successfully!\"}";

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

        [HttpPatch("{id}")]
        public async void Update(string id , VendorModel model)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                var item = repository.GetById(id);
                item.Phone_Number = model.Phone_Number;
                item.Email = model.Email;
                item.Contact_Person = model.Contact_Person;
                item.City = model.City;
                item.Zip_Code = model.Zip_Code;
                item.Address = model.Address;
                item.Additional_Comment = model.Additional_Comment;

                repository.CreateOrUpdate(item);

                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Vendor edited successfully!\"}";

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

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                var item = repository.GetById(id);
                repository.Delete(item);

                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Vendor deleted successfully!\"}";

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
