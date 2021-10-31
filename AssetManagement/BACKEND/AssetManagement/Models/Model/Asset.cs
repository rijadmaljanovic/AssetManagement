using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class Asset:TableEntity
    {
        [JsonProperty("assetCategory")]
        public string AssetCategory { get; set; }

        [JsonProperty("assetType")]
        public string AssetType { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("assetName")]
        public string AssetName { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("purchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [JsonProperty("warrantyExpiryDate")]
        public DateTime WarrantyExpiryDate { get; set; }

        [JsonProperty("purchaseType")]
        public string PurchaseType { get; set; }
        [JsonProperty("Employee")]
        public string Employee { get; set; }
        public string UserId { get; set; }
    }
}
