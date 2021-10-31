using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class AssetEmployee:TableEntity
    {
        public string AssetId { get; set; }
        public string EmployeeId { get; set; }

    }
}
