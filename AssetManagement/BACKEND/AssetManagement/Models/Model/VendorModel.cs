using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class VendorModel
    {
        public string Vendor_Name { get; set; }
        public string Guid { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string Contact_Person { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Address { get; set; }
        public string Additional_Comment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
