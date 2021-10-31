using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class AssetEmployeeRefValues
    {
        public IEnumerable<Asset> Assets { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

    }
}
