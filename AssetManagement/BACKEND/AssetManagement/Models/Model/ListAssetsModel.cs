using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class ListAssetsModel
    {
        public int Number { get; set; }
        public string Id { get; set; }
        public string AssetType { get; set; }
        public string Vendor { get; set; }
        public string AssetName { get; set; }
        public string CurrentState { get; set; }
        public string Employee { get; set; }
    }
}
