Download And Unzip
------------------
1- GoTo the following URL 
https://github.com/Kdpal/CityBikesAPIAutomation.git
2- Click the Green 'Code' button and chose the 'Download Zip' option
3- It will download a CityBikesAPIAutomation-main.zip file 
4- Unzip the file to a folder
e.g. C:\Downloads\CityBikesAPIAutomation-main will contain the following 
  --CityBikesFramework
  --NUnitConsoleRunner3.12.0
  --Assemblies 
  --CityBikesAPIAutomation.sln
5. Next we will see different options to run the APIAutomation tests.


Option 1 Running NUnit tests via Command Line 
---------------------------------------------
The zip file contains few Assemblies which are precompiled and can be used with NUnit Console Runner to execute the 12 tests cases without using IDE

1. Open Command prompt or Window Power Shell
2. Navigate to the NUnitConsoleRunner3.12.0 tools folder 
e.g. 
	cd C:\Downloads\CityBikesAPIAutomation-main\NUnit.ConsoleRunner.3.12.0\tools

3. Run the following command
  .\nunit3-console.exe {Path to Unzipped folder}\Assemblies\CityBikesFramework.dll --result="{Path to Unzipped folder}\TestResults\CityBikesTestResults.xml;format=nunit3"
e.g. 
  .\nunit3-console.exe C:\Downloads\CityBikesAPIAutomation-main\Assemblies\CityBikesFramework.dll --result="C:\Downloads\CityBikesAPIAutomation-main\TestResults\CityBikesTestResults.xml;format=nunit3"

4. NUnitConsoleRunner3 will run the 12 tests and display the message on the command window that all tests passed. 

5. CityBikesAPIAutomation-main\TestResults\CityBikesTestResults.xml will be created at the end of the test which contain the detail execution of all 12 tests



Option 2 Running Nunit test via IDE i.e. Visual Studio 2019
------------------------------------------------------------
The project is build using .Net Framework 4.8 so make sure the machine got this installed.
Download VS 2019 Community edition or higher. Community edition is free to download
https://visualstudio.microsoft.com/downloads/

1. In the unzip folder click the cityBikesAPIAutomation.sln file
2. This will open VS 2019 and a Warning message is displayed to trust the unknown source prese ok. 
3. Once the project is load we need to install the Specflow Extensionfor that follow the steps below 
  
  -- In VS 2019 menu click the Extensions --> Manage Extensions menu
  -- In the search box in the top left corner of the dialog search "Specflow for Visual Studio 2019"
  -- Install the extension
  -- Close the VS 2019 and it will install the extension 
  -- Open the solution again which is mentioned in step 1
4. Now Build the project by right clicking Clean Solution and then Build Solution
5. Once build go to Test --> Test Explore menu and it will open Test Explorer on the left side of VS 2019
6. Go to Test --> Configure Run Setting --> Select Solution Wide runSetting File. And select App.runsettings file from the project root
7. Successful build will display 12 tests. 6 NUnit tests and 6 Specflow Acceptance tests 
8. Run the test by click the play all button in the test explorer. 


Problem Statement
-----------------
As a biker I would like to know the exact location of city bikes around the world in a given application.

-- Endpoint: http://api.citybik.es/v2/networks
-- Auth: No
-- HTTPS: No
-- Understands how the API works.
-- Create some BDD scenarios and automate them using Java to test the API
-- Test this particular scenario: “As a user I want to verify that the city Frankfurt is in Germany and return their corresponded latitude and longitude”


API Behaviour
-------------
API Base URL
http://api.citybik.es/v2/


API Endpoints
http://api.citybik.es/v2/networks
{
  "networks": [
    {
        "company": "JCDecaux", 
        "href": "/v2/networks/velib", <--- network API endpoint
        "location": {
          "latitude": 48.856612, 
          "city": "Paris", 
          "longitude": 2.352233, 
          "country": "FRA"
        }, 
        "name": "Vélib'", 
        "id": "velib"
    },
    {...}
  ]
}

so the above will return one array of networks that will display all the bicyle hire companies in the world with company name, href, location attributes , name and id

http://api.citybik.es/v2/networks/velib
{
	"network": {
		"company": [
			"Smovengo"
		],
		"href": "/v2/networks/velib",
		"id": "velib",
		"location": {
			"city": "Paris",
			"country": "FR",
			"latitude": 48.856614,
			"longitude": 2.3522219
		},
		"name": "Velib' Métropôle",
		"stations": [
			{
				"empty_slots": 27,
				"extra": {
					"banking": false,
					"bikes_overflow": 0,
					"dueDate": 1531632033,
					"ebikes": 2,
					"ebikes_overflow": 0,
					"has_ebikes": true,
					"normal_bikes": 4,
					"online": true,
					"slots": 35,
					"status": "Operative",
					"uid": "16107"
				},
				"free_bikes": 6,
				"id": "78ec9186acd18a0b30bd3156d24b9f8d",
				"latitude": 48.865983,
				"longitude": 2.275725,
				"name": "Benjamin Godard - Victor Hugo",
				"timestamp": "2021-01-19T21:51:34.614000Z"
			},
			{
				"empty_slots": 36,
				"extra": {
					"banking": true,
					"bikes_overflow": 0,
					"dueDate": 1522965646,
					"ebikes": 2,
					"ebikes_overflow": 0,
					"has_ebikes": true,
					"normal_bikes": 16,
					"online": true,
					"slots": 55,
					"status": "Operative",
					"uid": "6015"
				},
				"free_bikes": 18,
				"id": "43c856353b954711f2bbee185a1f9d04",
				"latitude": 48.85375581057431,
				"longitude": 2.3390958085656168,
				"name": "André Mazet - Saint-André des Arts",
				"timestamp": "2021-01-19T21:51:34.642000Z"
			}, {...}
		],
		   "company": "JCDecaux",            |
			"href": "/v2/networks/velib",     -->     Redundant Information
			"location": {                    |
			  "latitude": 48.856612,         |     Same information as first request
			  "city": "Paris",               |---      with less requests
			  "longitude": 2.352233,         | 
			  "country": "FRA"               |    This can be filtered by passing
			},                               |      ?fields=stations to the URI
			"id": "velib"                    |  e.g. http://api.citybik.es/v2/networks/velib?fields=stations
		
	}
}

so the above will return one array of networks that will display all the a particular company in a city along with all stations in the city

Syntax
-------

Field filtering
Fields can be filtered by adding a ?fields=list,of,fields parameter to any request. Field visibility gets only into the first document for now, but we plan on supporting lucene type parameters to allow filterings like location.city,station.*

For example http://api.citybik.es/v2/networks?fields=id,name,href will render just the name, id and API endpoint of each network

{
  "networks": [
    {
        "href": "/v2/networks/velib", 
        "id": "velib", 
        "name": "V\u00e9lib'"
    }, 
    {
        "href": "/v2/networks/valenbisi", 
        "id": "valenbisi", 
        "name": "Valenbisi"
    }, 
    {
        "href": "/v2/networks/ecobici", 
        "id": "ecobici", 
        "name": "EcoBici"
    },
    {...}
  ]
}

Format
The system currently supports only JSON.
More formats may be implemented, and will be requested by setting the appropiate MIME type on the Content-Type field of the header's request.


Testing Scenarios
----------------

Unit Testing 
-- Test Response Ok i.e. 200
-- Test Invalid Response Not Found 404
-- Test Content Type 
-- Test Endpoint one 
-- Test Second Endpoint 
-- Test structure of JSON 
-- Test Invalid Endpoint 
-- Test filtering column and attribute level
-- Test Invalid Filtering 
-- Test Paging if any 
-- Test sorting 
-- Test https 
-- Test Authentication


Behaviour Driven Scenarios
--------------------------
-- As a user I want to verify that the city Frankfurt is in Germany and return their corresponded latitude and longitude
-- Verify that Content type of City bike API is application/json
-- Verify that the API return all the stations in city of Frankfurt in Germany
-- Verify that the API return all the stations in different cities of world



Testing Framework
------------------
-- Specflow is used to write BDD Scenarios in a feature file and Step definition files are used to call the API with C# Binding
-- The API calling is done using RESTSharp package which is C# version of REST Assure 
-- Nunit testing framework and NUnit test adaptor is used to do the Assertions and Give us capability to run paraller or sequential 
-- Nunit Console Runner is used to run via command line


Testing Framwork Working
------------------------
 
 BDD Framework (Specflow, NUnit, REST Sharp in C#)
    Specflow Scenario --> Step Definition --> RestRequest(resource,method)| QueryParameters (optional) --> Execute -- > returns IRestResponse in JSON Format
  
    Desereilize response using JsonDserializer.Desereilize method. This converts it back to object model e.g Root --> Location --> City
  
    After Desererlize the objects are population as properties and that is returned in Step definiton section where using Assert of Nunit Framework
  
 Unit Testing Framwork (NUnit, RestShar in C#)
    
    NUnit test request RestRequest(resource,method)| QueryParameters (optional) --> Execute -- > returns IRestResponse in JSON Format
  
    Desereilize response using JsonDserializer.Desereilize method. This converts it back to object model e.g Root --> Location --> City
  
    After Desererlize the objects are population as properties and that can be used in Assert of Nunit Framework which can run it sequential or parallel 
	
	
Project Structure 
-----------------
-- DataEntities Folder 
   Contain the Data Object model in C# basically reprenstation of JSON data return in Objects using JSON Properties.
   Different c# files e.g. Network, Location

-- Utilties Folder 
   Common Helper methods which can be used by both Unit Tests and Specflow framworks

-- Feature Folder 
   Feature Files which contain BDD style sytax to represent different scenario in Given, When Then format, Each Scenario is a test 
   Scenario Outline is used for Data driven tests 

-- Step Definitions Folder 
   Binding of Specflow definition with c# and this is middle layer where the scenarios steps from Feature file logic is implemented. 
   i.e. Call the back end Service to return the result and then use the Nunit assertation to validate the steps 

-- Hook Folder 
   Not used in this project but we can use the After or Before Test/Scenario/Feature/Step tags to implement pre test or step conditions. 
   E.g. Restore database or start a server or close browser 
   
-- UnitTests Folder
   Contain NUnit unit tests which is calling the Rest API directory using helper methods and using Nunit Assert to validate 
   
   
Functions
------------
   
 public IRestResponse GetRestResponse (string baseURL,string resource,Method method Type, string Key=null, string Value=null)
	This function responsible to construct he RestClient and RestRequest and execute using the parameter passed.
		baseURL: Pass the base url which is not going to change e.g. http://api.citybik.es/
		resource: which make up the end point e.g. /v2/networks
		MethodType: like GET, POST , PUT etc METHOD.GET
		Key : key of the query parameter e.g. fields.
		Value: Value of the query parameter e.g. id,name,href for filtering 
     
		Key Value parameters only added if both are provided. otherwise the request is send without query parameter
	 
 public Root DeserilizeTheResponse(IRestResponse response)	 
    This function is responsible for deserialization of the JSON return into different Object and return the data type Root i.e Network data entity
	    IRestResponse: response returned from GetRestResponse method passed to deserialize
	
	
	
	
	
	
  
  
  
  

  
  


