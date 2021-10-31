using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class AssetRefValues
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public IEnumerable<string> Vendors { get; set; }
        public IEnumerable<string> Types { get; set; }
        public List<string> PurchaseTypes { get; set; }
    }
}
