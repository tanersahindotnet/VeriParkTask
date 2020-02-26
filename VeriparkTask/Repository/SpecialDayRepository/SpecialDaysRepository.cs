using System.Collections.Generic;
using System.Linq;
using VeriparkTask.Models;

namespace VeriparkTask.Repository.SpecialDayRepository
{
    public class SpecialDaysRepository : ISpecialDayRepository
    {
        public List<SpecialDay> GetSpecialDays()
        {
            using (var db = new DbContext())
            {
                return db.SpecialDays.ToList();
            }
        }

        public bool DeleteSpecialDay(int specialDayId)
        {
            using (var db = new DbContext())
            {
                var specialDay = new SpecialDay { Id = specialDayId };
                db.SpecialDays.Attach(specialDay);
                db.SpecialDays.Remove(specialDay);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        public bool AddSpecialDay(SpecialDay specialDay)
        {
            using (var db = new DbContext())
            {
                db.SpecialDays.Add(specialDay);
                var result = db.SaveChanges();
                return result > 0;
            }
        }
    }
}