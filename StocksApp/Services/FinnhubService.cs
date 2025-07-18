using System.Text.Json;
using StocksApp.ServiceContracts;

namespace StocksApp.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            // Constructor logic here
        }
        public async Task<Dictionary<string,object>?> GetStockPrice(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpReqestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}"),
                    Method = HttpMethod.Get,
                    
                };
               HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpReqestMessage);
               Stream stream =  httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string response = streamReader.ReadToEnd();
                Dictionary<string,object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string,object>>(response);
                if(responseDictionary == null)
                {
                    throw new InvalidOperationException("No response received from the API.");
                }
                if(responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException($"Error from API: {responseDictionary["error"]}");
                }
                return responseDictionary;
            }

        }
    }
}
