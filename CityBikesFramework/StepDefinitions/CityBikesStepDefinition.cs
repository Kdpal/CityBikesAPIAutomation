using CityBikesFramework.DataEntities;
using CityBikesFramework.Utilities;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CityBikesFramework.StepDefinitions
{

    [Binding]
    public sealed class CityBikesStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private dynamic _instance;
        private readonly ClientRequestHelper _scenarioContext;
        private string endPoint;
        private IRestResponse response;
        private Root deserializedResponse;


        public CityBikesStepDefinition(ClientRequestHelper scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I access the city bikes endpoint (.*)")]
        public void GivenIAccessTheCityBikesEndpoint(string baseUrl)
        {
            endPoint = baseUrl;
        }


        [When(@"I only enter resource (.*)")]
        public void GivenIOnlyEnterResource(string resource)
        {
            response = _scenarioContext.GetRestResponse(endPoint, resource, Method.GET);
        }


        [When(@"I enter resource (.*) and Query parameters (.*)")]
        public void GivenIEnterResourceAndQueryParameters(string resource, string queryParameters)
        {
            response = _scenarioContext.GetRestResponse(endPoint, resource, Method.GET, "fields", queryParameters);
        }


        [Then(@"I get a valid response")]
        public void GivenIGetAValidResponse()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Then(@"API return content type as (.*)")]
        public void ThenAPIReturnContentTypeAs(string contentType)
        {
            //TODO: implement assert (verification) logic
            Assert.AreEqual(contentType, response.ContentType, "Wrong Content type is returned");
        }


        [Then(@"Response Contain the following values")]
        public void ThenResponseContainTheFollowingValues(Table table)
        {
            deserializedResponse = _scenarioContext.DeserilizeTheResponse(response);
            _instance = table.CreateDynamicInstance();

            Assert.AreEqual((string)_instance.ID, deserializedResponse.NETWORK.ID, "Id returned is different to what expected");
            Assert.AreEqual((string)_instance.NAME, deserializedResponse.NETWORK.NAME, "Name returned is different to what expected");
            Assert.AreEqual((string)_instance.HREF, deserializedResponse.NETWORK.HREF, "HREF returned is different to what expected");
            Assert.AreEqual((string)_instance.CITY, deserializedResponse.NETWORK.LOCATION.CITY, "City returned is different to what expected");
            Assert.AreEqual((string)_instance.COUNTRY, deserializedResponse.NETWORK.LOCATION.COUNTRY, "Country returned is different to what expected");
            Assert.AreEqual(string.Format("{0:0.####}", _instance.LATITUDE), string.Format("{0:0.####}", deserializedResponse.NETWORK.LOCATION.LATITUDE), "Latitude is different to what expected");
            Assert.AreEqual(string.Format("{0:0.####}", _instance.LONGITUDE), string.Format("{0:0.####}", deserializedResponse.NETWORK.LOCATION.LONGITUDE),"Longitude is different to what expected");


        }

        [Then(@"Response Contain the following values and (.*) stations")]
        public void ThenResponseContainTheFollowingValuesAndStations(int count, Table table)
        {
               ThenResponseContainTheFollowingValues(table);
               Assert.AreEqual(count, deserializedResponse.NETWORK.STATIONS.Count, "Count returned is different");
        }


    }
}
