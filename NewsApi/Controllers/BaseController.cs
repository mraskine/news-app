using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ReturnError(string errorMessage)
        {
            var result = new BaseApiResponse
            {
                Success = false,
                ErrorMessage = errorMessage
            };

            return Ok(result);
        }

        protected void HandleExeption(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
