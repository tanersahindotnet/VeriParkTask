using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VeriparkTask.Const;
using VeriparkTask.Models;
using VeriparkTask.Models.InputModels;
using VeriparkTask.Repository.CountryRepository;
using VeriparkTask.Repository.SpecialDayRepository;
using VeriparkTask.Service.ValidationService;

namespace VeriparkTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpecialDayRepository _specialDayRepository = new SpecialDaysRepository();
        private readonly ICountryRepository _countryRepository = new CountryRepository();
        private readonly IValidationService _validationService = new ValidationService();

        public ActionResult Index()
        {
            var countries = _countryRepository.GetCountry();
            ViewBag.countryDropDownItems = ReturnCountriesASelectListItems(countries);
            return View();
        }

        [HttpPost]
        public ActionResult Index(CheckInInput model)
        {
            var values = ViewData.ModelState.Values;
            var errorMessage = _validationService.CheckModelHasErrorMessage(values);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var result = CalculateAmount(model);
                ViewBag.result = result;
            }
            else
            {
                ViewData["Error"] = errorMessage;
            }
            var countries = _countryRepository.GetCountry();
            ViewBag.countryDropDownItems = ReturnCountriesASelectListItems(countries);
            return View();
        }

        public ActionResult Countries()
        {
            var url = Request.Url.Segments.Last();
            var result = _validationService.CheckUrlHaveValueAndReturn(url);
            if (result > 0)
            {
                _countryRepository.DeleteCountry(result);
            }
            ViewBag.countries = _countryRepository.GetCountry();
            return View();
        }

        [HttpPost]
        public ActionResult Countries(Country model)
        {
            var values = ViewData.ModelState.Values;
            var errorMessage = _validationService.CheckModelHasErrorMessage(values);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var result = _countryRepository.AddCountry(model);
                if (result)
                {
                    ViewData["Success"] = WarningMessages.AddCountrySuccess;
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Error"] = WarningMessages.AddCountryFail;
                }
            }
            else
            {
                ViewData["Error"] = errorMessage;
            }
            ViewBag.countries = _countryRepository.GetCountry();

            return View();
        }

        public ActionResult SpecialDays()
        {
            var url = Request.Url.Segments.Last();
            var result = _validationService.CheckUrlHaveValueAndReturn(url);
            if (result > 0)
            {
                _specialDayRepository.DeleteSpecialDay(result);
            }
            ViewBag.specialDays = _specialDayRepository.GetSpecialDays();
            var countries = _countryRepository.GetCountry();
            ViewBag.countryDropDownItems = ReturnCountriesASelectListItems(countries);
            return View();
        }

        [HttpPost]
        public ActionResult SpecialDays(SpecialDay model)
        {
            var values = ViewData.ModelState.Values;
            var errorMessage = _validationService.CheckModelHasErrorMessage(values);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var result = _specialDayRepository.AddSpecialDay(model);
                if (result)
                {
                    ViewData["Success"] = WarningMessages.AddSpecialDaySuccess;
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Error"] = WarningMessages.AddSpecialDayFail;
                }
            }
            else
            {
                ViewData["Error"] = errorMessage;
            }
            ViewBag.specialDays = _specialDayRepository.GetSpecialDays();
            var countries = _countryRepository.GetCountry();
            ViewBag.countryDropDownItems = ReturnCountriesASelectListItems(countries);
            return View();
        }

        public List<SelectListItem> ReturnCountriesASelectListItems(List<Country> countries)
        {
            var countryDropDownItems = new List<SelectListItem>();
            foreach (var countryItem in countries)
            {
                countryDropDownItems.Add(new SelectListItem
                {
                    Text = countryItem.CountryName,
                    Value = countryItem.Id.ToString()
                });
            }
            return countryDropDownItems;
        }

        public string CalculateAmount(CheckInInput model)
        {
            var amount = 0;
            var country = _countryRepository.GetCountry().FirstOrDefault(p => p.Id == model.CountryId);
            var specialDays = _specialDayRepository.GetSpecialDays().Where(p => p.CountryId == model.CountryId).ToList();
            for (var date = model.BookCheckIn; model.BookReceived.CompareTo(date) > 0; date = date.AddDays(1.0))
            {
                var findingSpecialDays = specialDays.Where(p => p.SpecialDate.Month == date.Month && p.SpecialDate.Day == date.Day).ToList();
                if (findingSpecialDays.Any() || date.DayOfWeek.ToString() == country.OffDay1 || date.DayOfWeek.ToString() == country.OffDay2)
                {
                    continue;
                }
                amount += 5;
            }
            return "Your Penalty Amount:" + amount + country.CurrencyCode;
        }
    }
}