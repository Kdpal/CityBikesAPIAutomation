using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBikesFramework.DataEntities
{
    public class Extra
    {

        [JsonProperty("bike_uids")]
        public List<string>  BIKE_UIDS { get; set; }

        [JsonProperty("number")]
        public string NUMBER { get; set; }

        [JsonProperty("uid")]
        public string UID { get; set; }

        [JsonProperty("slots")]
        public int? SLOTS { get; set; }
    }
}
