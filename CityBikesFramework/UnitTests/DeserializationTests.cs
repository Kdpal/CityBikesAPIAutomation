using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using CityBikesFramework.DataEntities;
using System.Net;
using CityBikesFramework.Utilities;

namespace CityBikesFramework.UnitTests
{
    [TestFixture]
    public class DeserializationTests
    {

        [Test]
        public void FrankfurtCityTest()
        {

            ClientRequestHelper helper = new ClientRequestHelper();
            // Execute
            IRestResponse response = helper.GetRestResponse("http://api.citybik.es/", "v2/networks/visa-frankfurt", Method.GET, "fields", "id,name,href,location");


            // JSON Response to Object as content type return is application/json as verified in another unit test
            Root deserializedResponse = helper.DeserilizeTheResponse(response);

            // Asserts
            Assert.That(deserializedResponse.NETWORK.HREF,
                Is.EqualTo("/v2/networks/visa-frankfurt"));
            Assert.That(deserializedResponse.NETWORK.ID,
                Is.EqualTo("visa-frankfurt"));
            Assert.That(deserializedResponse.NETWORK.NAME,
                Is.EqualTo("VISA"));
            Assert.That(deserializedResponse.NETWORK.LOCATION.CITY,
                Is.EqualTo("Frankfurt"));
            Assert.That(deserializedResponse.NETWORK.LOCATION.COUNTRY,
                Is.EqualTo("DE"));
            Assert.That(string.Format("{0:0.####}",deserializedResponse.NETWORK.LOCATION.LATITUDE),
                Is.EqualTo("50.1072"));
            Assert.That(string.Format("{0:0.####}",deserializedResponse.NETWORK.LOCATION.LONGITUDE),
                Is.EqualTo("8.6638"));

        }

        [Test]
        public void NetworksGenericTest()
        {
            // Build
            RestClient client = new RestClient("http://api.citybik.es/");
            RestRequest request = new RestRequest("v2/networks", Method.GET);

            // Execute using Generic 
            var response = client.Execute<MainRoot>(request);

            // Assert first element is Moscow out 646 cities
            Assert.That(response.Data.NETWORKS[0].COMPANY[0], Is.EqualTo("ЗАО «СитиБайк»"));
            Assert.That(response.Data.NETWORKS.Count, Is.EqualTo(646));
            Assert.That(response.Data.NETWORKS[0].LOCATION.CITY, Is.EqualTo("Moscow"));
        
        }
    }
}