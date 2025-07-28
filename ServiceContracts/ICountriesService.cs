using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    ///  Represents bussinness logic for manipulating countries
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Return  country object  by  list of  countries
        /// </summary>
        /// <param name="countryAddRequest"></param>
        /// <returns>Retrun the country Response</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Return all countries
        /// </summary>
        /// <returns>All countries from the list as list of CountryResponse</CountryResponse></returns>

        List<CountryResponse>GetAllCountries();

        /// <summary>
        /// Return a country by its ID
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns>Matching country as countryResponse  objec</returns>
        CountryResponse? GetCountryByCountryID(Guid? countryID);
    }
}
