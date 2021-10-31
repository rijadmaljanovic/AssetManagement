using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class AssetModel
    {
        public string AssetCategory { get; set; }
        public string AssetType { get; set; }

        public string Vendor { get; set; }

        public string AssetName { get; set; }

        public string SerialNumber { get; set; }

        public double Price { get; set; }

        public string Location { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime WarrantyExpiryDate { get; set; }

        public string PurchaseType { get; set; }
        public string Employee { get; set; }
    }
}
