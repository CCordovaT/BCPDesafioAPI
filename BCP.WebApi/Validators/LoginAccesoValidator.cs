using BCP.WebApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Validators
{
    public class LoginAccesoValidator : BaseValidator<LoginBCPRequest>
    {
        public LoginAccesoValidator() : base()
        {
            RuleFor(p => p.CodUsuario)
                 .NotEmpty().WithName("Código de usuario")
                 .OnFailureSetFirstLevelError(context);

            RuleFor(p => p.Contrasenia)
                 .NotEmpty().WithName("Contraseña")
                 .OnFailureSetFirstLevelError(context);

            When(p => !context.ExistsErrorInFirstLevel, () =>
            {
                RuleFor(p => p.CodUsuario)
                    .LoginUsuarioDebeExistir(context)
                    .Must((login, cod) => context.Usuario.Contrasenia == login.Contrasenia).WithMessage("'Contraseña' incorrecta");
            });

            this.SetErrorCodeToAllRules("E2000");
        }
    }
}