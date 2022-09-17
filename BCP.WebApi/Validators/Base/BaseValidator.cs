using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Validators
{
    public class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        protected CustomContext context = new CustomContext();        

        public BaseValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;            
        }
    }
}