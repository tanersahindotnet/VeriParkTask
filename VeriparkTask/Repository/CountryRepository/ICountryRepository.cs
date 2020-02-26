using System.Collections.Generic;
using VeriparkTask.Models;

namespace VeriparkTask.Repository.CountryRepository
{
    public interface ICountryRepository
    {
        List<Country> GetCountry();

        bool DeleteCountry(int countryId);

        bool AddCountry(Country country);
    }
}