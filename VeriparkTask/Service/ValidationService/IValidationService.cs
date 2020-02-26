using System.Collections.Generic;
using System.Web.Mvc;

namespace VeriparkTask.Service.ValidationService
{
    public interface IValidationService
    {
        int CheckUrlHaveValueAndReturn(string requestPath);

        string CheckModelHasErrorMessage(ICollection<ModelState> values);
    }
}