using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Web;

namespace AzureFunctionsOpenAPIDemo
{

    //TODO: https://github.com/microsoft/OpenAPI.NET.CSharpAnnotations/issues/159
    //TODO: Security: v2 v3 https://github.com/OAI/OpenAPI-Specification/blob/master/versions/2.0.md#securityDefinitionsObject

    public class Function1
    {
        [Function("FunctionDefault")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, FunctionContext executionContext)
        {
            var log = executionContext.GetLogger<Function1>();

            log.LogInformation("C# HTTP trigger function processed a request.");

            var query = HttpUtility.ParseQueryString(req.Url.Query);
            string name = query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content", "Content-Type: text/html; charset=utf-8");
            response.WriteString(responseMessage);

            return response;
        }

        // [Function("Swagger")]
        // public async Task<HttpResponseData> RunSwagger([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req, FunctionContext executionContext)
        // {
        //     var input = new OpenApiGeneratorConfig(
        //         annotationXmlDocuments: new List<XDocument>()
        //         {
        //             XDocument.Load(@"AzureFunctionsOpenAPIDemo.xml"),
        //         },
        //         assemblyPaths: new List<string>()
        //         {
        //             @"bin\AzureFunctionsOpenAPIDemo.dll"
        //         },
        //         openApiDocumentVersion: "V1",
        //         filterSetVersion: FilterSetVersion.V1
        //     );
        //     input.OpenApiInfoDescription = "This is a sample description...";

        //     var generator = new OpenApiGenerator();
        //     var openApiDocuments = generator.GenerateDocuments(
        //         openApiGeneratorConfig: input,
        //         generationDiagnostic: out GenerationDiagnostic result
        //     );

        //     var response = req.CreateResponse(HttpStatusCode.OK);
        //     response.Headers.Add("Content", "Content-Type: application/json; charset=utf-8");
        //     response.WriteString(openApiDocuments.First().Value.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

        //     return response;
        // }

        // [Function("SwaggerV2")]
        // public async Task<HttpResponseData> RunSwagger2([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req, FunctionContext executionContext)
        // {
        //     var input = new OpenApiGeneratorConfig(
        //         annotationXmlDocuments: new List<XDocument>()
        //         {
        //             XDocument.Load(@"AzureFunctionsOpenAPIDemo.xml"),
        //         },
        //         assemblyPaths: new List<string>()
        //         {
        //             @"bin\AzureFunctionsOpenAPIDemo.dll"
        //         },
        //         openApiDocumentVersion: "V1",
        //         filterSetVersion: FilterSetVersion.V1
        //     );
        //     input.OpenApiInfoDescription = "This is a sample description...";

        //     var generator = new OpenApiGenerator();
        //     var openApiDocuments = generator.GenerateDocuments(
        //         openApiGeneratorConfig: input,
        //         generationDiagnostic: out GenerationDiagnostic result
        //     );

        //     var response = req.CreateResponse(HttpStatusCode.OK);
        //     response.Headers.Add("Content", "Content-Type: application/json; charset=utf-8");
        //     response.WriteString(openApiDocuments.First().Value.SerializeAsJson(OpenApiSpecVersion.OpenApi2_0));

        //     return response;
        // }
    }
}
