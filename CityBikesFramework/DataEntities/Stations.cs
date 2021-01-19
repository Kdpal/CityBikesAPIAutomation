using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBikesFramework.DataEntities
{
    public class Station
    {
        [JsonProperty("empty_slots")]
        public int? EMPTY_SLOTS { get; set; }

        [JsonProperty("extra")]
        public Extra EXTRA { get; set; }

        [JsonProperty("free_bikes")]
        public int FREE_BIKES { get; set; }
        
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("latitude")]
        public double LATITUDE { get; set; }
        
        [JsonProperty("longitude")]
        public double LONGITUDE { get; set; }

        [JsonProperty("name")]
        public string NAME { get; set; }

        [JsonProperty("timestamp")]
        public DateTime TIMESTAMP { get; set; }
    }
}
