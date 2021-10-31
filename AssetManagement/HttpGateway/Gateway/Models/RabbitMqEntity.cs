using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class RabbitMqEntity:TableEntity
    {
        public string DeviceName { get; set; }
        public string SecurityKey { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
