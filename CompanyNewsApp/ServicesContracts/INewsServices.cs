namespace CompanyNewsApp.ServicesContracts
{
    public interface INewsServices
    {
        Task <Dictionary<string, object>?> GetNews(string symbol);
    }
}
