using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class ProductRefValues
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
