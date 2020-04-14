using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MicrosoftAspNetWebApiClientSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public void Get()
        {
            var urlBase = "http://www.google.com";

            // var url = "http://www.google.com/api/search?a=123&b=qwe&c=6643";
            var url = urlBase.AppendPathSegment("api")
                             .AppendPathSegment("search")
                             .SetQueryParam("a", "123")
                             .SetQueryParam("b", "qwe")
                             .SetQueryParam("c", "6643");

            QueryParamCollection queryParams = url.QueryParams;
            var queryParam = queryParams["a"];

            Url newUrl = url.RemoveQueryParam("c");
        }
    }

    public class MyClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}