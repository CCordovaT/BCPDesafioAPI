using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Validators
{
    public static class WhenNotExistContextErrorValidator
    {
        public static IRuleBuilderOptions<T, TElement> WhenNotExistsContextErrorInSecondLevel<T, TElement>(this IRuleBuilderOptions<T, TElement> ruleBuilder, CustomContext customContext)
        {
            return ruleBuilder.When(p => !customContext.ExistsErrorInSecondLevel, ApplyConditionTo.CurrentValidator);
        }
    }
}