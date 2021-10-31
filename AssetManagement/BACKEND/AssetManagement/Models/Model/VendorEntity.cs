using System;
using Microsoft.Azure.Cosmos.Table;

namespace Models
{
    public class VendorEntity : TableEntity
    {
        public string Vendor_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string Contact_Person { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Address { get; set; }
        public string Additional_Comment { get; set; }
        public string UserId { get; set; }
        //public DateTime Timestamp { get; set; }
    }
}
