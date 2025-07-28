using System;
using Entities;

namespace ServiceContracts.DTO
{ 
    /// <summary>
    /// Dto class that is  used  as return type for most of Conttries Service methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }
        //It compares the current instance with object to another instance of CountryResponse type and returns true if both instance are equal otherwise false.
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if(obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }
            CountryResponse country_to_compare = (CountryResponse)obj;
            return CountryID == country_to_compare.CountryID && CountryName == country_to_compare.CountryName;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class ContryExtensions
    {
       public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName
            };
        }

    }
}
