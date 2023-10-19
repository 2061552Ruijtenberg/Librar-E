using LibraryCollectionWebApplication.Models;
using LibraryCollectionWebApplication.Models.API;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryCollectionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            HttpClient client = _httpClientFactory.CreateClient(name: "quotes-Api");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                //API key and connection thingy
                Headers =
                {
                 { "X-RapidAPI-Key", "63b3961830mshfd90caab0afc5e1p1ecb8ajsnb5bd31d0d030" },
                 { "X-RapidAPI-Host", "quotel-quotes.p.rapidapi.com" },
                },
                Content = new StringContent("{}")
                {
                    Headers =
                    {
                        ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                    }
                }
            };
            HttpResponseMessage responseMessage = client.SendAsync(httpRequest).Result;
            Quote? quote = responseMessage.Content.ReadFromJsonAsync<Quote>().Result;

            return View(quote);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}