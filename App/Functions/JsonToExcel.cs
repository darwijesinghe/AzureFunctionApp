using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using App.Services.Interfaces;
using App.Models.Response;
using System.Data;
using System.Linq;
using System.Net;
using App.Helpers;

namespace App.Functions
{
    public class JsonToExcel
    {
        // Services
        private readonly ILogger<JsonToExcel> _logger;
        private readonly IConvertService      _convertor;

        public JsonToExcel(ILogger<JsonToExcel> logger, IConvertService convertor)
        {
            _logger    = logger;
            _convertor = convertor;
        }

        [FunctionName("JsonToExcel")]
        [OpenApiOperation()]
        [OpenApiParameter(name: "Json", Required = true, In = ParameterLocation.Query, Type = typeof(string))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", bodyType: typeof(string))]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            try
            {
                // gets the json value
                string json = req.Query["Json"];
                if (string.IsNullOrEmpty(json))
                    return new ObjectResult(new Result { Success = false, Message = "Json value is required." });

                if (!Helper.IsValidJson(json))
                    return new ObjectResult(new Result { Success = false, Message = "Enterd value is not a valid Json." });

                // converts Json to DataTable
                var table = JsonConvert.DeserializeObject<DataTable>(json);

                // makes the Excel file from the table
                var result = await _convertor.ConvertDataTableToExcel(table);
                if (result.Success)
                {
                    // content type of the file
                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName    = "document.xlsx";

                    // response header
                    req.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment;filename=\"{fileName}\"");

                    // returns the file
                    return new FileContentResult(result.Data.ToArray(), contentType);
                }

                // returns fail response
                return new ObjectResult(new Result { Success = false, Message = result.Message });
            }
            catch (Exception ex)
            {
                // logs the error
                _logger.LogError(ex.Message);

                // returns the exception
                return new ObjectResult(new Result
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
