Feature: CityBikes
	As a biker I would like to know the exact location
	of city bikes around work in a given application

Background: 
    Given I access the city bikes endpoint http://api.citybik.es/


@mytag
Scenario: Verify that Content type of City bike API is application/json
	When I only enter resource /v2/networks
	Then I get a valid response
	And API return content type as application/json


Scenario: Verify that the city Frankfurt is in Germany 
	When I enter resource /v2/networks/visa-frankfurt and Query parameters id,name,href,location
    Then I get a valid response
	And API return content type as application/json
	And Response Contain the following values
	| ID             | NAME | HREF                        | CITY      | COUNTRY | LATITUDE | LONGITUDE |
	| visa-frankfurt | VISA | /v2/networks/visa-frankfurt | Frankfurt | DE      | 50.1072  | 8.6638    |


Scenario: Verify that the API return all the stations in city of Frankfurt in Germany
	When I enter resource /v2/networks/visa-frankfurt and Query parameters id,name,href,location,stations
    Then I get a valid response
	And API return content type as application/json
	And Response Contain the following values and 97 stations
	| ID             | NAME | HREF                        | CITY      | COUNTRY | LATITUDE | LONGITUDE |
	| visa-frankfurt | VISA | /v2/networks/visa-frankfurt | Frankfurt | DE      | 50.1072  | 8.6638    |


#The following scenario is Data driven with Scenario outlines take Example in row of table. 
Scenario Outline: Verify that the API return all the stations in different cities of world
	When I enter resource <Network EndPoint> and Query parameters id,name,href,location,stations
    Then I get a valid response
	And API return content type as application/json
	And Response Contain the following values and <No of Stations> stations
	| ID   | NAME   | HREF               | CITY   | COUNTRY   | LATITUDE   | LONGITUDE   |
	| <ID> | <NAME> | <Network EndPoint> | <CITY> | <COUNTRY> | <LATITUDE> | <LONGITUDE> |
	Examples: 
	| Network EndPoint              | No of Stations | ID               | NAME             | CITY      | COUNTRY | LATITUDE | LONGITUDE |
	| /v2/networks/visa-frankfurt   | 97             | visa-frankfurt   | VISA             | Frankfurt | DE      | 50.1072  | 8.6638    |
	| /v2/networks/nextbike-london  | 1              | nextbike-london  | Nextbike         | London    | GB      | 51.4862  | -0.1197   |
	| /v2/networks/santander-cycles | 788            | santander-cycles | Santander Cycles | London    | GB      | 51.5112  | -0.1198   |