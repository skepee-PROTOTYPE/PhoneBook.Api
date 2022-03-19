[![CircleCI](https://circleci.com/gh/skepee/PhoneBook.Api/tree/master.svg?style=svg)](https://circleci.com/gh/skepee/PhoneBook.Api/tree/master)

# Phone Book API

API to work with phone book numbers with read, add, delete, update operations.

The solution contains the following projects:

* DATA: Database project
* MyIdentity: IdentityServer to authorize user access to API and Client
* PhoneBook.API: API GET(), POST(), PUT(), DELETE()
* PhoneBook.Client: Client to show data from API
* XUnitTestPhoneBook: unit test for crud operations 
* Postman tests


## Project details

### DATA

The datbase consists in one table to save phone numbers:]. The fields are:

* Id (PK)
* FirstName
* LastName
* HomeNumber
* WorkNumber
* PhoneNumber

The solustion contains a script for initial values.


### MyIdentity 
 Identity Server to handle permissions to API and Client

 
### PhoneBook.API
Features:
* EntityFrameworkCore
* Repostiroy Pattern
* Dependency Injection
* IdentityServer Authentication
* ILog
* async/await


### PhoneBook.Client
In order to test the api a client has been create to show results. The project contains a Razor page the invokes the GET() API.

Features:
* IHttpClientFactory implementation
* IdentityServer Authentication
 

### XUnitTestPhoneBook
List of unit tests for insert, update, read , delete operations.

Features: 
* InMemory Database
* Not shared database: at the beginning of each unit test a database is created with an initial set of values.


### Postman
the PhoneBook.API project contains a set of postman tests : PhoneBook.Api.postman_collection.json.
Import this file into your Pastman client to test API.


```
{
	"info": {
		"_postman_id": "386849db-3c30-4588-adc9-021cd4f2a56c",
		"name": "PhoneBook.Api",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "https://localhost:44349/api/phonebook/",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://localhost:44349/api/phonebook/",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44349",
					"path": [
						"api",
						"phonebook",
						""
					]
				}
			},
			"response": []
		},
		{
			"name": "https://localhost:44349/api/phonebook/",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n\"FirstName\":\"aaaa\",\r\n\"LastName\":\"nnnnn\",\r\n\"HomeNumber\":\"123456\",\r\n\"WorkNumber\":\"123457\",\r\n\"PhoneNumber\":\"123458\"\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44349/api/phonebook/",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44349",
					"path": [
						"api",
						"phonebook",
						""
					]
				}
			},
			"response": []
		},
		{
			"name": "https://localhost:44349/api/phonebook/7",
			"request": {
				"method": "DELETE",
				"header": [],
				"url": {
					"raw": "https://localhost:44349/api/phonebook/7",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44349",
					"path": [
						"api",
						"phonebook",
						"7"
					]
				}
			},
			"response": []
		},
		{
			"name": "https://localhost:44349/api/phonebook/",
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n\"id\":3,\r\n\"FirstName\":\"aaaaXX\",\r\n\"LastName\":\"nnnnnXX\",\r\n\"HomeNumber\":\"123456XX\",\r\n\"WorkNumber\":\"123457XX\",\r\n\"PhoneNumber\":\"123458XX\"\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44349/api/phonebook/",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44349",
					"path": [
						"api",
						"phonebook",
						""
					]
				}
			},
			"response": []
		}
	],
	"protocolProfileBehavior": {}
}

```


### Relase notes:
Before running the application please set your connectionstring in "DefaultConnection" in appsettings.json of PhoneBook.API project.
