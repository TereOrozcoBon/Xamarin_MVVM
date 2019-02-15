using System;
using Newtonsoft.Json;

namespace InduccionMVVM.Models
{
    public class Products
    {
        public Products()
        {
        }

        [JsonProperty("Id")]
        public int id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("PathImg")]
        public string PathImg { get; set; }

    }
}
//http://189.254.239.136:88/WebApiobj/api/Products