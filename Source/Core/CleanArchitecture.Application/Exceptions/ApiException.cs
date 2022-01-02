using System;
using System.Globalization;

namespace CleanArchitecture.Application.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base()
        {

        }

        public ApiException(string message) : base(message)
        {

        }

        public ApiException(string message, params object[] args) : base($"{CultureInfo.CurrentCulture}{message}{args}")
        {

        }
    }
}
