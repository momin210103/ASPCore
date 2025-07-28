using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService: ICountriesService
    {
        // private field for storing countries
        private readonly List<Country> _countries;

        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();
            if (initialize)
            {
                _countries.AddRange(new List<Country>() {
                new Country(){ CountryID = Guid.Parse("68FAEE23-8826-4C0D-8BAC-EDDE5D9C3CBA"),CountryName = "USA"},
                new Country() { CountryID = Guid.Parse("C1995F68-5E01-42F2-8CCF-53DEAD12626F"), CountryName = "UK" },
                new Country() { CountryID = Guid.Parse("02AD18A4-99A8-41D4-8114-861D9F981405"), CountryName = "UAE" },
                new Country() { CountryID = Guid.Parse("8E805839-46BB-4BAB-B01F-814229B00963"), CountryName = "Bangladesh" },
                new Country() { CountryID = Guid.Parse("DC5A9378-8DA2-4C91-B807-B6BA1F665EC5"), CountryName = "Pakistan" },
                });
                

            }
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {

            //Validation: countryAddRequest should not be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest), "Country add request cannot be null.");
            }
            //Validation: country name cnanot be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException("Country name cannot be null.", nameof(countryAddRequest.CountryName));
            }
            //Validation: CountruName cannot be duplicate

            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country name already exists.", nameof(countryAddRequest.CountryName));
            }
            Country country = countryAddRequest.ToCountry();
            country.CountryID = Guid.NewGuid();

            _countries.Add(country);
            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
                return null;

            Country? country_response_from_list = _countries.FirstOrDefault(temp => temp.CountryID == countryID);
            if (country_response_from_list == null)
            {
                return null;
            }
            return country_response_from_list.ToCountryResponse();
        }
    }
}
