using System.Collections.Generic;
using System.Linq;
using VeriparkTask.Models;

namespace VeriparkTask.Repository.CountryRepository
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> GetCountry()
        {
            using (var db = new DbContext())
            {
                return db.Countries.ToList();
            }
        }

        public bool DeleteCountry(int countryId)
        {
            using (var db = new DbContext())
            {
                var country = new Country { Id = countryId };
                db.Countries.Attach(country);
                db.Countries.Remove(country);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        public bool AddCountry(Country country)
        {
            using (var db = new DbContext())
            {
                db.Countries.Add(country);
                var result = db.SaveChanges();
                return result > 0;
            }
        }
    }
}