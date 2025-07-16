using ServiceContracts;
namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;

        public CitiesService() 
        { 
            _cities = new List<string>
            {
                "New York",
                "Los Angeles",
                "Chicago",
                "Houston",
                "Phoenix"
            };
        }
        public List<string> GetCities()
        {
            return _cities;
        }

    }
}
