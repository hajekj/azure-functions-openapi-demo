using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.Xml.Linq;
using Microsoft.OpenApi.CSharpAnnotations.DocumentGeneration;
using Microsoft.OpenApi.CSharpAnnotations.DocumentGeneration.Models;
using Microsoft.OpenApi.Models;
using System.Linq;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi;
using System.Text;

namespace AzureFunctionsOpenAPIDemo
{

    //TODO: https://github.com/microsoft/OpenAPI.NET.CSharpAnnotations/issues/159
    //TODO: Security: v2 v3 https://github.com/OAI/OpenAPI-Specification/blob/master/versions/2.0.md#securityDefinitionsObject

    public static class Function1
    {
        [FunctionName("FunctionDefault")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Swagger")]
        public static async Task<HttpResponseMessage> RunSwagger([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var input = new OpenApiGeneratorConfig(
                annotationXmlDocuments: new List<XDocument>()
                {
                    XDocument.Load(@"AzureFunctionsOpenAPIDemo.xml"),
                },
                assemblyPaths: new List<string>()
                {
                    @"bin\AzureFunctionsOpenAPIDemo.dll"
                },
                openApiDocumentVersion: "V1",
                filterSetVersion: FilterSetVersion.V1
            );
            input.OpenApiInfoDescription = "This is a sample description...";

            var generator = new OpenApiGenerator();
            var openApiDocuments = generator.GenerateDocuments(
                openApiGeneratorConfig: input,
                generationDiagnostic: out GenerationDiagnostic result
            );

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(openApiDocuments.First().Value.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0), Encoding.UTF8, "application/json")
            };
        }

        [FunctionName("SwaggerV2")]
        public static async Task<HttpResponseMessage> RunSwagger2([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var input = new OpenApiGeneratorConfig(
                annotationXmlDocuments: new List<XDocument>()
                {
                    XDocument.Load(@"AzureFunctionsOpenAPIDemo.xml"),
                },
                assemblyPaths: new List<string>()
                {
                    @"bin\AzureFunctionsOpenAPIDemo.dll"
                },
                openApiDocumentVersion: "V1",
                filterSetVersion: FilterSetVersion.V1
            );
            input.OpenApiInfoDescription = "This is a sample description...";

            var generator = new OpenApiGenerator();
            var openApiDocuments = generator.GenerateDocuments(
                openApiGeneratorConfig: input,
                generationDiagnostic: out GenerationDiagnostic result
            );

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(openApiDocuments.First().Value.SerializeAsJson(OpenApiSpecVersion.OpenApi2_0), Encoding.UTF8, "application/json")
            };
        }
    }
}
