using System.Collections.Generic;

namespace NewsApi.Models.System
{
    public class BaseApiResponse
    {
        // Success means no exceptions. Even if the validation failed success = true to be able to pass error messages to the client
        public bool Success { get; set; }

        public List<Error> Errors { get; set; }
        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }

        public BaseApiResponse()
        {
            Success = true;
            Errors = new List<Error>();
        }
    }
}
