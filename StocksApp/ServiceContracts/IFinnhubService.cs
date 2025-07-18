namespace StocksApp.ServiceContracts
{
    public interface IFinnhubService
    {
       Task< Dictionary<string,object>?> GetStockPrice(string stockSymbol);
    }
}
