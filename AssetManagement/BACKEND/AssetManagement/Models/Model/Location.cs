using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class Location:TableEntity
    {
        public string LocationName { get; set; }
        public string Address{ get; set; }
        public string City { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhoneNumber { get; set; }
        public string ContactPersonEmail { get; set; }
        public string UserId { get; set; }
    }

}
