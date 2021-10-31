using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        string url = "https://signalr-internship2021.mss.ba/";
        string message = "";
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ListProductsModel> Get()
        {
            return productService.GetProducts();
        }
        [HttpGet("getProductRefValues")]
        public ProductRefValues getProductRefValues()
        {
            return productService.GetRefValues();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async void Post([FromBody] ProductModel model)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                productService.SaveProduct(model,current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product added successfully!\"}";

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

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                productService.DeleteProduct(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product deleted successfully!\"}";

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
        [HttpPut("{id}")]
        public async void Update(string id, [FromBody] ProductModel model)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                productService.EditProduct(id, model);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Product edited successfully!\"}";

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
