using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityBikesFramework.DataEntities
{
    public class Network
    {
        [JsonProperty("company")]
        public List<string> COMPANY { get; set; }

        [JsonProperty("href")]
        public string HREF { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }
        
        [JsonProperty("location")]
        public Location LOCATION { get; set; }
        
        [JsonProperty("name")]
        public string NAME { get; set; }

        [JsonProperty("stations")]
        public List<Station> STATIONS { get; set; }
    }
}
