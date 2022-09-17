using BCP.Repositories;
using BCP.WebApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Validators
{
    public static class LoginUsuarioDebeExistirRule
    {
        public static IRuleBuilderOptions<LoginBCPRequest, string> LoginUsuarioDebeExistir(this IRuleBuilder<LoginBCPRequest, string> ruleBuilder, CustomContext ctx)
        {
            return ruleBuilder.Must(CodUsuario => EsUsuarioValido(CodUsuario, ctx)).WithMessage("'Código de usuario' no existe");
        }

        private static bool EsUsuarioValido(string codUsuario, CustomContext context)
        {
            context.Usuario = new UsuarioRepositoryImp().ObtenerPorCodAcceso(codUsuario.ToString());

            return context.Usuario != null;
        }
    }
}