using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Validators
{
    public static class OnFailureSetFirstLevelErrorValidator
    {
        public static IRuleBuilderOptions<T, TElement> OnFailureSetFirstLevelError<T, TElement>(this IRuleBuilderOptions<T, TElement> ruleBuilder, CustomContext customContext)
        {
            return ruleBuilder.OnAnyFailure(p => customContext.ExistsErrorInFirstLevel = true);
        }
    }
}