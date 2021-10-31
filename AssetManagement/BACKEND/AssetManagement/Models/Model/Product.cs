using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
   public class Product:TableEntity
   {
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

    }
}
