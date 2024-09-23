using BeerCollection.ActionFilters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BeerCollection.Controllers
{
    [TypeFilter(typeof(ValidateModelFilter))]
    [Route("api/[controller]/[action]")]
    [EnableCors]
    public class BaseController : Controller
    {
        public static ResultModel GetReturnMessage(string message, bool hasWarning, bool hasError)
        {
            return new ResultModel { HasError = hasError, HasWarning = hasWarning, Message = message };
        }
    }
}
