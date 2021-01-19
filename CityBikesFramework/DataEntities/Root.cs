using Newtonsoft.Json;


namespace CityBikesFramework.DataEntities
{
    public class Root
    {

        [JsonProperty("network")]
        public Network NETWORK { get; set; }
    }

}
