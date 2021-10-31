using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class AssetCategory:TableEntity
    {
        public string AssetCategoryName { get; set; }
        public string UserId { get; set; }
    }
}
