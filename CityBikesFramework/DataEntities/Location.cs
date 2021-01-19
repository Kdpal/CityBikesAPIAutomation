using Newtonsoft.Json;

namespace CityBikesFramework.DataEntities
{
    public class Location
    {

        [JsonProperty("city")]
        public string CITY { get; set; }
        [JsonProperty("country")]
        public string COUNTRY { get; set; }
        [JsonProperty("latitude")]
        public double LATITUDE { get; set; }
        [JsonProperty("longitude")]
        public double LONGITUDE { get; set; }
    }
}
