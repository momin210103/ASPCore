namespace NewsApp.ServiceContracts
{
    public interface INewsService
    {
        Task<Dictionary<string, object>?> GetNews(string? symbol);
    }    
}
