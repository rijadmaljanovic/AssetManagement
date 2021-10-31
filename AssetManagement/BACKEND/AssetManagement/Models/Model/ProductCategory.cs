using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class ProductCategory:TableEntity
    {
        public string ProductCategoryName { get; set; }
        public string UserId { get; set; }
    }
}
