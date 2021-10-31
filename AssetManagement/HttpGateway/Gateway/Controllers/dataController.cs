using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class dataController : ControllerBase
    {
        private readonly IRabbitMqService rabbitmqService;

        public dataController(IRabbitMqService rabbitmqService)
        {
            this.rabbitmqService = rabbitmqService;
        }

        [HttpPost]
        public void Send([FromQuery] DataObj obj, [FromBody] GetPayloadModel payload)
        {
             rabbitmqService.SendMessage(obj, payload);
        }

        [HttpGet("{deviceName}")]
        public IEnumerable<RabbitMqEntity> GetData(string deviceName)
        {
            return rabbitmqService.GetData(deviceName);
        }
    }
}
