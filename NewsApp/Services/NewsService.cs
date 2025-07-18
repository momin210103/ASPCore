using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class NewsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task GetNews()
        {
           using(HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri ("https://finnhub.io/api/v1/company-news?symbol=AAPL&from=2025-01-15&to=2025-02-20&token=d1st5dpr01qhe5rbuq8gd1st5dpr01qhe5rbuq90"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage htttpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = htttpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string response = streamReader.ReadToEnd();

            }

        }
    }
}
