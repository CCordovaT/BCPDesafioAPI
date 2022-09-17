using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Validators
{
    public static class SetErrorCodeToAllRulesValidator
    {
        public static void SetErrorCodeToAllRules<T>(this AbstractValidator<T> modelValidator, string errorCode)
        {
            foreach (var validator in (modelValidator).Where(rule => rule is PropertyRule ruleChain).SelectMany(rule => rule.Validators))
            {
                validator.Options.ErrorCodeSource = new StaticStringSource(errorCode);
            }
        }
    }
}