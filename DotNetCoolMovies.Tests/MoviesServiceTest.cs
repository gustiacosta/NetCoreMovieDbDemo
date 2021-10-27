using DotNetCoolMovies.ApiService;
using DotNetCoolMovies.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCoolMovies.Tests
{
    public class MoviesServiceTest
    {
        private readonly HttpClient httpClient;
        public MoviesServiceTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddConfiguration(hostingContext.Configuration);
                    config.AddJsonFile("appsettings.json");
                })
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            httpClient = server.CreateClient();
        }

        [Fact]
        public async Task ApiCallSuccess()
        {
            using var httpResponse = await httpClient.GetAsync("https://localhost:44366/movies/all");
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Theory]
        [InlineData(new object[] { "emily", "crime" })]
        public async Task ApiCallSearchingForExistingMovies(params string[] values)
        {
            foreach (var value in values)
            {
                using var httpResponse = await httpClient.GetAsync($"https://localhost:44366/movies/search/{value}");
                Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            }
        }

        [Theory]
        [InlineData(new object[] { "homeland", "charles" })]
        public async Task ApiCallSearchingForNonExistingMovies(params string[] values)
        {
            foreach (var value in values)
            {
                using var httpResponse = await httpClient.GetAsync($"https://localhost:44366/movies/search/{value}");
                var content = await httpResponse.Content.ReadAsStringAsync();

                ResponseModel resultModel = new();
                if (!string.IsNullOrEmpty(content))
                {
                    resultModel = JsonConvert.DeserializeObject<ResponseModel>(content);
                }

                Assert.Equal(resultModel.Data.Count, 0);
            }
        }
    }
}
