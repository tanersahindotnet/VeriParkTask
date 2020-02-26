using System.Collections.Generic;
using VeriparkTask.Models;

namespace VeriparkTask.Repository.SpecialDayRepository
{
    public interface ISpecialDayRepository
    {
        List<SpecialDay> GetSpecialDays();

        bool DeleteSpecialDay(int specialDayId);

        bool AddSpecialDay(SpecialDay specialDay);
    }
}