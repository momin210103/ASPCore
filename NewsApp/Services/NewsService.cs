using System.Threading.Tasks;
using System.Text.Json;
using NewsApp.ServiceContracts;
namespace NewsApp.Services
{
    public class NewsService: INewsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public NewsService(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<Dictionary<string,object>?>GetNews(string symbol)
        {
           using(HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri ($"https://finnhub.io/api/v1/company-news?symbol={symbol}&from=2025-01-15&to=2025-02-20&token={_configuration["NewsToken"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage htttpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = htttpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string response = streamReader.ReadToEnd();

                Dictionary<string,object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
               
                if(responseDictionary == null)
                {
                    throw new InvalidOperationException("No response from news");
                }
                if (responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
                }
                return responseDictionary;
            }

        }
    }
}
