using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using IO.Swagger.Models;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Web;

namespace AzureFunctionsOpenAPIDemo
{
    public static class PetApi
    {
        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>POST</verb>
        /// <url>http://localhost:7071/api/v2/AddPet</url>
        /// <param name="postBody" in="body"><see cref="Pet"/>Sample object</param>
        /// <response code="405">Invalid input</response>
        [Function("AddPet")]
        public static HttpResponseData AddPet([HttpTrigger(AuthorizationLevel.Function, "post", Route = "v2/AddPet")] HttpRequestData req, FunctionContext executionContext)
        {
            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>DELETE</verb>
        /// <url>http://localhost:7071/api/v2/DeletePet/{petId}</url>
        /// <param name="petId" cref="long" in="path">Pet id to delete</param>
        /// <param name="apiKey" cref="string" in="header">Api Key</param>
        /// <response code="400">Invalid pet value</response>
        [Function("DeletePet")]
        public static HttpResponseData DeletePet([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v2/DeletePet/{petId:long?}")] HttpRequestData req, FunctionContext executionContext, long? petId)
        {
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>GET</verb>
        /// <url>http://localhost:7071/api/v2/pet/findByStatus</url>
        /// <remarks>Multiple status values can be provided with comma separated strings</remarks>
        /// <param name="status" cref="string" in="query">Status values that need to be considered for filter</param>
        /// <response code="200"><see cref="List{T}"/>where T is <see cref="Pet"/>successful operation</response>
        /// <response code="400">Invalid status value</response>
        [Function("FindByStatus")]
        public static HttpResponseData FindPetsByStatus([HttpTrigger(AuthorizationLevel.Function, "get", Route = "v2/pet/findByStatus")] HttpRequestData req, FunctionContext executionContext)
        {
            var query = HttpUtility.ParseQueryString(req.Url.Query);
            var statusCodes = query["status"].ToString().Split(",");
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Pet>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            string exampleJson = null;
            exampleJson = "<Pet>\n  <id>123456789</id>\n  <name>doggie</name>\n  <photoUrls>\n    <photoUrls>aeiou</photoUrls>\n  </photoUrls>\n  <tags>\n  </tags>\n  <status>aeiou</status>\n</Pet>";
            exampleJson = "[ {\n  \"photoUrls\" : [ \"photoUrls\", \"photoUrls\" ],\n  \"name\" : \"doggie\",\n  \"id\" : 0,\n  \"category\" : {\n    \"name\" : \"name\",\n    \"id\" : 6\n  },\n  \"tags\" : [ {\n    \"name\" : \"name\",\n    \"id\" : 1\n  }, {\n    \"name\" : \"name\",\n    \"id\" : 1\n  } ],\n  \"status\" : \"available\"\n}, {\n  \"photoUrls\" : [ \"photoUrls\", \"photoUrls\" ],\n  \"name\" : \"doggie\",\n  \"id\" : 0,\n  \"category\" : {\n    \"name\" : \"name\",\n    \"id\" : 6\n  },\n  \"tags\" : [ {\n    \"name\" : \"name\",\n    \"id\" : 1\n  }, {\n    \"name\" : \"name\",\n    \"id\" : 1\n  } ],\n  \"status\" : \"available\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Pet>>(exampleJson)
            : default(List<Pet>);
            //TODO: Change the data returned

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content", "Content-Type: application/json; charset=utf-8");
            response.WriteString(JsonConvert.SerializeObject(example));

            return response;
        }

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>GET</verb>
        /// <url>http://localhost:7071/api/v2/pet/findByTags</url>
        /// <remarks>Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.</remarks>
        /// <param name="tags">Tags to filter by</param>
        /// <response code="200"><see cref="List{T}"/>where T is <see cref="Pet"/>successful operation</response>
        /// <response code="400">Invalid tag value</response>
        [Function("FindPetsByTags")]
        public static HttpResponseData FindPetsByTags([HttpTrigger(AuthorizationLevel.Function, "get", Route = "v2/pet/findByTags")] HttpRequestData req, FunctionContext executionContext)
        {
            var query = HttpUtility.ParseQueryString(req.Url.Query);
            var tags = query["tags"].ToString().Split(",");
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Pet>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            string exampleJson = null;
            exampleJson = "<Pet>\n  <id>123456789</id>\n  <name>doggie</name>\n  <photoUrls>\n    <photoUrls>aeiou</photoUrls>\n  </photoUrls>\n  <tags>\n  </tags>\n  <status>aeiou</status>\n</Pet>";
            exampleJson = "[ {\n  \"photoUrls\" : [ \"photoUrls\", \"photoUrls\" ],\n  \"name\" : \"doggie\",\n  \"id\" : 0,\n  \"category\" : {\n    \"name\" : \"name\",\n    \"id\" : 6\n  },\n  \"tags\" : [ {\n    \"name\" : \"name\",\n    \"id\" : 1\n  }, {\n    \"name\" : \"name\",\n    \"id\" : 1\n  } ],\n  \"status\" : \"available\"\n}, {\n  \"photoUrls\" : [ \"photoUrls\", \"photoUrls\" ],\n  \"name\" : \"doggie\",\n  \"id\" : 0,\n  \"category\" : {\n    \"name\" : \"name\",\n    \"id\" : 6\n  },\n  \"tags\" : [ {\n    \"name\" : \"name\",\n    \"id\" : 1\n  }, {\n    \"name\" : \"name\",\n    \"id\" : 1\n  } ],\n  \"status\" : \"available\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Pet>>(exampleJson)
            : default(List<Pet>);
            //TODO: Change the data returned

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content", "Content-Type: application/json; charset=utf-8");
            response.WriteString(JsonConvert.SerializeObject(example));

            return response;
        }

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <remarks>Returns a single pet</remarks>
        /// <group>PetApi</group>
        /// <verb>GET</verb>
        /// <url>http://localhost:7071/api/v2/pet/{petId}</url>
        /// <param name="petId" cref="long" in="path">Pet id to delete</param>
        /// <response code="200"><see cref="Pet"/>successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        [Function("GetPetById")]
        public static HttpResponseData GetPetById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "v2/pet/{petId:long?}")] HttpRequestData req, FunctionContext executionContext, long? petId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Pet));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            string exampleJson = null;
            exampleJson = "<Pet>\n  <id>123456789</id>\n  <name>doggie</name>\n  <photoUrls>\n    <photoUrls>aeiou</photoUrls>\n  </photoUrls>\n  <tags>\n  </tags>\n  <status>aeiou</status>\n</Pet>";
            exampleJson = "{\n  \"photoUrls\" : [ \"photoUrls\", \"photoUrls\" ],\n  \"name\" : \"doggie\",\n  \"id\" : 0,\n  \"category\" : {\n    \"name\" : \"name\",\n    \"id\" : 6\n  },\n  \"tags\" : [ {\n    \"name\" : \"name\",\n    \"id\" : 1\n  }, {\n    \"name\" : \"name\",\n    \"id\" : 1\n  } ],\n  \"status\" : \"available\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Pet>(exampleJson)
            : default(Pet);
            //TODO: Change the data returned

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content", "Content-Type: application/json; charset=utf-8");
            response.WriteString(JsonConvert.SerializeObject(example));

            return response;
        }

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>PUT</verb>
        /// <url>http://localhost:7071/api/v2/pet</url>
        /// <param name="postBody" in="body"><see cref="Pet"/>Pet object that needs to be added to the store</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Pet not found</response>
        /// <response code="405">Validation exception</response>
        [Function("UpdatePet")]
        public static async Task<HttpResponseData> UpdatePet([HttpTrigger(AuthorizationLevel.Function, "put", Route = "v2/pet")] HttpRequestData req, FunctionContext executionContext)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic pet = JsonConvert.DeserializeObject<Pet>(requestBody);
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>POST</verb>
        /// <url>http://localhost:7071/api/v2/pet/{petId}</url>
        /// <param name="petId" cref="long" in="path">ID of pet that needs to be updated</param>
        /// <param name="formData" in="body" type="application/x-www-form-urlencoded"><see cref="PetForm"/>Updated name of the pet</param>
        /// <response code="405">Invalid input</response>
        [Function("UpdatePetWithForm")]
        public static async Task<HttpResponseData> UpdatePetWithForm([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "v2/pet/{petId:long?}")] HttpRequestData req, FunctionContext executionContext, long? petId)
        {
            // var formdata = await req.ReadFormAsync();

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);

            throw new NotImplementedException();
        }


        /// <summary>
        /// uploads an image
        /// </summary>
        /// <group>PetApi</group>
        /// <verb>POST</verb>
        /// <url>http://localhost:7071/api/v2/pet/{petId}/uploadImage</url>
        /// <param name="petId" cref="long" in="path">ID of pet that needs to be updated</param>
        /// <param name="formData" in="body" type="application/x-www-form-urlencoded"><see cref="PetUploadFileForm"/>Updated name of the pet</param>
        /// <response code="200"><see cref="ApiResponse"/>successful operation</response>
        [Function("UploadFile")]
        public static async Task<HttpResponseData> UploadFile([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "v2/pet/{petId:long?}/uploadImage")] HttpRequestData req, FunctionContext executionContext, long? petId)
        {
            // var formdata = await req.ReadFormAsync();
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ApiResponse));

            string exampleJson = null;
            exampleJson = "{\n  \"code\" : 0,\n  \"type\" : \"type\",\n  \"message\" : \"message\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<ApiResponse>(exampleJson)
            : default(ApiResponse);
            //TODO: Change the data returned

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content", "Content-Type: application/json; charset=utf-8");
            response.WriteString(JsonConvert.SerializeObject(example));

            return response;
        }
    }
}
