using System;
using System.Collections.Generic;

namespace Application.Response
{
    public class ErrorResponse
    {
        public List<ErrorModel> ErrorMessage { get; set; } = new List<ErrorModel>();
    }
}
