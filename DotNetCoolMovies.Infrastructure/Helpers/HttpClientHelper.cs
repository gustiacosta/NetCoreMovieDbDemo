using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetCoolMovies.Infrastructure.Helpers
{
    public class HttpClientHelper
    {

        public static async Task<string> CallExternalRateEndpoint(string param, IHttpClientFactory _httpClientFactory, string url)
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.HttpClientFactoryName);
            using (var httpResponse = await httpClient.GetAsync(url))
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return await Task.FromResult(content);
                }
            }

            return string.Empty;
        }
    }
}