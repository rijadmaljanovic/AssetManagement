using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class ProductType:TableEntity
    {
        public string ProductTypeName { get; set; }
        public string UserId { get; set; }
    }
}
