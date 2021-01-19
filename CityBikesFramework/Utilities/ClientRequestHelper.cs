using CityBikesFramework.DataEntities;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBikesFramework.Utilities
{
    public class ClientRequestHelper
    {

        public IRestResponse GetRestResponse(string baseURL, string resource, Method method, string key=null, string value=null )
        {
            //Build
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest(resource, method);
            if (key != null && value != null)
            {
                request.AddQueryParameter(key, value);
            }

            // Execute
            IRestResponse response = client.Execute(request);

            return response;
        }

        public Root DeserilizeTheResponse(IRestResponse response)
        {
            return new JsonDeserializer().Deserialize<Root>(response);
        }
    }


}
