using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class EmployeeModel 
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentID { get; set; }
    }
}
