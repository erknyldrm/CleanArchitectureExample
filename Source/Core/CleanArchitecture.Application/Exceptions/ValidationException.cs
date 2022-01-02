using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        
        public ValidationException() : base("Errors occured.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors.AddRange(failures.Select(p=>p.ErrorMessage));
        }
    }
}
