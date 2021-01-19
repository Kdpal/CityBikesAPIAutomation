using CityBikesFramework.Utilities;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace CityBikesFramework.UnitTests
{
    [TestFixture]
    public class DataDrivenTests
    {
        [TestCase("v2/networks", HttpStatusCode.OK, TestName = "Check status code for First EndPoint")]
        [TestCase("v2/networks/visa-frankfurt", HttpStatusCode.OK, TestName = "Check status code for Second EndPoint")]
        [TestCase("v2/networks/outofWorld", HttpStatusCode.NotFound, TestName = "Check status code for invalid EndPoint")]
        public void StatusCodeTest(string resource, HttpStatusCode expectedHttpStatusCode)
        {

            ClientRequestHelper helper = new ClientRequestHelper();
            // Execute
            IRestResponse response = helper.GetRestResponse("http://api.citybik.es/", $"{resource}",Method.GET);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}
