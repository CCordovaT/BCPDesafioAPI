using BCP.UnitOfWorks;
using BCP.WebApi.Models;
using BCP.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static BCP.Commons.GlobalConstans;

namespace BCP.WebApi.Providers
{
    public class AutenticationBCPProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnitOfWork unitOfWorkBCP;

        public AutenticationBCPProvider()
        {
            unitOfWorkBCP = new UnitOfWorkBCP();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Run(() =>
            {
                context.Request.Body.Position = 0;

                LoginBCPRequest loginRequest = null;
                ValidationResult resultadoLogin = null;

                try
                {

                    loginRequest = GenerarLoginDeDatosCabecera(context.UserName, context.Password);
                    resultadoLogin = ValidarLogueoAlSistema(loginRequest);

                }
                catch (SqlException ex)
                {

                    context.SetError("E3000", ex.Message);
                    return;

                }
                catch (Exception ex)
                {

                    context.SetError("E1000", ex.Message);
                    return;

                }

                if (!resultadoLogin.IsValid)
                {

                    context.SetError(resultadoLogin.Errors.First().ErrorCode, MENSAJE_LOGUEO_INCORRECTO);
                    return;

                }

                ClaimsIdentity claimsIdentity = EstablecerClaimsEnElToken(context, loginRequest);

                context.Validated(claimsIdentity);
            });
        }

        public ClaimsIdentity EstablecerClaimsEnElToken(OAuthGrantResourceOwnerCredentialsContext context, LoginBCPRequest loginRequest)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

            claimsIdentity.AddClaim(new Claim("CodUsuario", loginRequest.CodUsuario));

            return claimsIdentity;
        }

        public ValidationResult ValidarLogueoAlSistema(LoginBCPRequest loginRequest)
        {
            ValidationResult resultadoLogin = new LoginAccesoValidator().Validate(loginRequest);

            return resultadoLogin;
        }

        public string ObtenerParametrosConcatenadosDeCabeceraPeticion(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                using (var _oReader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    return _oReader.ReadToEnd();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LoginBCPRequest GenerarLoginDeDatosCabecera(string codUsuario, string password)
        {
            return new LoginBCPRequest()
            {
                CodUsuario = codUsuario,
                Contrasenia = password
            };
        }
    }
}