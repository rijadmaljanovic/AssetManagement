using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class Department:TableEntity
    {
        public string DepartmentName { get; set; }
        public string UserId { get; set; }
    }
}
