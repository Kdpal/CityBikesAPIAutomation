using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityBikesFramework.DataEntities
{
    public class MainRoot
    {
        [JsonProperty("networks")]
        public List<Network> NETWORKS { get; set; }
    }

}
