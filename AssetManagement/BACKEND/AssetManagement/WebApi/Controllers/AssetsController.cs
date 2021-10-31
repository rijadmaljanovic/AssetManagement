using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsService assetsService;
        string url = "https://signalr-internship2021.mss.ba/";
        string message = "";
        public AssetsController(IAssetsService assetsService)
        {
            this.assetsService = assetsService;
        }
        // GET: api/Assets/getAllAssets
        [HttpGet]
        public IEnumerable<ListAssetsModel> getAllAssets()
        {
            return assetsService.ListAssets();
        }
        [HttpGet("getAssetRefValues")]
        public AssetRefValues AddNewAsset()
        {
            return assetsService.AddNewAsset();
        }
        [HttpPost]
        public async void SaveNewAsset([FromBody] AssetModel asset)
        {
            User current = (User)HttpContext.Items["User"];

            try
            {
                assetsService.SaveNewAsset(asset, current);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset added successfully!\"}";

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
        // GET api/Assets/assignToEmployee
        [HttpGet("getAssetEmployeeRefValues")]
        public AssetEmployeeRefValues AssignToEmployee()
        {
            return assetsService.AssignToEmployee();
        }
        //POST api/Assets/assignToEmployee
        [HttpPut("{id}")]
        public async void AssignToEmployeetSave([FromBody] AssetEmployeeModel model, string id)
        {

            User current = (User)HttpContext.Items["User"];

            try
            {
                assetsService.AssignToEmployeeSave(model, id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset assigned successfully!\"}";

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
                assetsService.DeleteAsset(id);
                if (Response.StatusCode == 200)
                    message = "{\"type\": \"success\", \"message\": \"Asset deleted successfully!\"}";

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
