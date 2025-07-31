﻿using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService: ICountriesService
    {
        // private field for storing countries
        private readonly PersonsDbContext _db;

        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
            
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

            if (_db.Countries.Count(temp => temp.CountryName == countryAddRequest.CountryName) > 0)
            {
                throw new ArgumentException("Country name already exists.", nameof(countryAddRequest.CountryName));
            }
            Country country = countryAddRequest.ToCountry();
            country.CountryID = Guid.NewGuid();

            _db.Countries.Add(country);
            _db.SaveChanges();
            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _db.Countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
                return null;

            Country? country_response_from_list = _db.Countries.FirstOrDefault(temp => temp.CountryID == countryID);
            if (country_response_from_list == null)
            {
                return null;
            }
            return country_response_from_list.ToCountryResponse();
        }
    }
}
