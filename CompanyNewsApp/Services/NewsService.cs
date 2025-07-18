using System.Net.Http;
using CompanyNewsApp.ServicesContracts;
namespace CompanyNewsApp.Services
{
    public class NewsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task method()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://finnhub.io/api/v1/news?category=general&token=d1st5dpr01qhe5rbuq8gd1st5dpr01qhe5rbuq90"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string response = streamReader.ReadToEnd();

            }
        }
    }
}
