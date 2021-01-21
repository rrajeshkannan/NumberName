1. Background / Requirement
	- Develop a REST based web API server

	- Endpoints
		- /identity
			- GET
				- Request: EMPTY
				- Response: JSON body { "server_name": <full name> }
				- Response-code: 200 OK
		- /convert
			- POST
				- Request: JSON body { "value": <non-negative integer> }
				- Response: JSON body
					{
						"value": <original integer submitted>,
						"value_in_words": <integer value written out in words>
					}
				- Response-code: 200 OK
				- Response-code for error in input (bad input): 400 BAD REQUEST response
		- * - any other URL
			- Response-code: "404 NOT FOUND"

2. Technology
	- .NET Core API
		- for developing the server backend
		- version: 5.0

	- DockerFile
		- describes the image of web API server
		- built on top of .NET Core slim runtime image on top of linux

	- docker
		- for building and running the web API server in containers

	- docker-compose
		- for composing the docker image as described in DockerFile

3. Code base structure - NumberName
	- src
		- contains all the source code for the web API server

	- doc
		- contains this documentation

3. Build & Run
	- Download and unpack code
	- $ cd ./NumberName/src

	- $ sudo docker-compose up
		- it builds the complete image
		- it publishes the built image into local docker container image repository
		- it runs the published image inside a container (ENTRYPOINT: dotnet NumberName.Server.dll)

	- $ sudo docker image ls
		- we can see the image published into the local container image repository

	- $ sudo docker ps
		- we can see the container image running as a docker process
		- Take a note of "Ports" - for e.g., 0.0.0.0:49153->80/tcp

4. How it works?
	- Swagger
		- in a browser, visit: http://0.0.0.0:49153/swagger/index.html
		- it opens the OpenAPI documentation for the REST web API server's endpoints and models
		- we can try sending request to the server using swagger interface simply (both request / response)

	- Postman
		- GET http://0.0.0.0:49153/identity
		- POST http://0.0.0.0:49153/convert

5. Walkthrough
	- Architecture patterns:
		- MVC
			- this web API server is built on MVC architecture
			- Controller and Model - explained in detail below
		- Fluent API
			- the core business logic for converting a numeric value into its word form follows a fluent-api pattern
			- to refer: \src\NumberName.Server\NumberToName\Services\NumberToNameConverter
			- for example:
				value
		                    .ConvertForPeriod(valueInWords, Period.Billion, BillionPeriodBegin)
                		    .ConvertForPeriod(valueInWords, Period.Million, MillionPeriodBegin)
		                    .ConvertForPeriod(valueInWords, Period.Thousand, ThousandPeriodBegin)
                		    .ConvertForPeriod(valueInWords, Period.Hundred, HundredPeriodBegin)
		                    .ConvertSubHundred(valueInWords)
                		    .ConvertSubTwenty(valueInWords)

		- DI
			- Controllers and Services completely employ the DI container capabilities of a .Net Core API module
			- Dependencies are configured inside the "Startup" class - \src\NumberName.Server\Startup
			- to refer: constructor of \src\Identity\IdentityController
			- to refer: constructor of \src\Identity\IdentityController

	- Controller
		- a controller handles only one concern (responsibility) - represents an API endpoint for accessing resource and responds to the resource access incoming traffic
		- the API endpoint route for each resource is defined using Route("*****")
			- to refer: \src\Identity\IdentityController
			- to refer: \src\NumberToName\ConvertController
		- [HttpGet] / [HttpPost] decorated methods - represent the resource verbs

	- Service
		- a service originally represents the business logic as quoted in the Requirements (Section-1) above
		- a controller delegates the incoming call to the Service for real work
		- to refer: \src\NumberName.Server\Identity\Services\IdentityService.cs
		- to refer: \src\NumberName.Server\NumberToName\Services\ConversionService.cs

	- Model - represents a resource (entity)
		- a model class abstracts a domain model / entity
		- to refer: \src\Identity\Model\ServerIdentity.cs
		- to refer: \src\NumberName.Server\NumberToName\Model\NumberNameInput
		- to refer: \src\NumberName.Server\NumberToName\Model\NumberNameOutput

	- docker-compose.yml and Dockerfile
		- represent the container packaging and deployment models

	- appsettings.json
		- holds all configuration values extracted from the code
		- as a best practice

6. Enhancements to look for
	Logging
	Indian number system - lakhs/crores