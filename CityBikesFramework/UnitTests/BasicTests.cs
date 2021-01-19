using CityBikesFramework.Utilities;
using NUnit.Framework;
using RestSharp;

namespace CityBikesFramework.UnitTests
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void ContentTypeTest()
        {
            ClientRequestHelper helper = new ClientRequestHelper();
            // Execute
            IRestResponse response = helper.GetRestResponse("http://api.citybik.es/", "v2/networks",Method.GET);

            // Assert
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

    }
}
