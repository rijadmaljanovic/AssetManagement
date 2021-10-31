using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class AssetType: TableEntity
    {
        public string AssetTypeName { get; set; }
        public string UserId { get; set; }
    }
}
