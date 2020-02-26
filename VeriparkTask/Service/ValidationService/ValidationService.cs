using System.Collections.Generic;
using System.Web.Mvc;

namespace VeriparkTask.Service.ValidationService
{
    public class ValidationService : IValidationService
    {
        public int CheckUrlHaveValueAndReturn(string requestPath)
        {
            try
            {
                var value = int.Parse(requestPath);
                return value;
            }
            catch
            {
                return 0;
            }
        }

        public string CheckModelHasErrorMessage(ICollection<ModelState> values)
        {
            foreach (var modelState in values)
            {
                foreach (var error in modelState.Errors)
                {
                    return error.ErrorMessage;
                }
            }
            return "";
        }
    }
}