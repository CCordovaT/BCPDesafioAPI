using BCP.Commons;
using BCP.WebApi.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BCP.WebApi.Handlers
{
    public class CustomReponseFormatHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var respuesta = await base.SendAsync(request, cancellationToken);

            return FormatearMensajeRespuesta(request, respuesta);
        }

        private static HttpResponseMessage FormatearMensajeRespuesta(HttpRequestMessage request, HttpResponseMessage response)
        {
            response.TryGetContentValue(out object contenidoRespuesta);

            var apiResponse = new ApiResponse();

            if (response.IsSuccessStatusCode)
            {
                apiResponse.CodigoRespuesta = "OK";
                apiResponse.Data = contenidoRespuesta;
            }
            else
            {
                var httpError = contenidoRespuesta as HttpError;

                if (httpError != null)
                {
                    apiResponse.CodigoRespuesta = ObtenerCodigoRespuestaSegunHttpResponse(response);

                    if (apiResponse.CodigoRespuesta.IsEmpty()) apiResponse.CodigoRespuesta = ObtenerCodigoRespuestaSegunTipoError(httpError);

                    apiResponse.MensajeError = ObtenerMensajeErrorConcatenado(httpError);
                }
                else
                {
                    if (contenidoRespuesta is ValidationResult)
                    {
                        var resultadoValidacion = contenidoRespuesta as ValidationResult;

                        apiResponse.CodigoRespuesta = resultadoValidacion.Errors.FirstOrDefault()?.ErrorCode;
                        apiResponse.MensajeError = resultadoValidacion.ToString(Environment.NewLine);
                    }
                    else if (contenidoRespuesta is BadRequestResponse)
                    {
                        var badRequestRespuesta = contenidoRespuesta as BadRequestResponse;

                        apiResponse.CodigoRespuesta = badRequestRespuesta.ErrorCode;
                        apiResponse.MensajeError = badRequestRespuesta.Mensaje;
                    }
                }
            }

            var nuevaRespuestaFormateada = request.CreateResponse(response.StatusCode, apiResponse);

            foreach (var cabecera in response.Headers)
            {
                nuevaRespuestaFormateada.Headers.Add(cabecera.Key, cabecera.Value);
            }

            return nuevaRespuestaFormateada;
        }

        private static string ObtenerMensajeErrorConcatenado(HttpError httpError)
        {
            return $"{(httpError.Message.IsEmpty() ? "Error" : httpError.Message)}{(httpError.ExceptionMessage.IsEmpty() ? "" : $"- {httpError.ExceptionMessage}")}";
        }

        private static string ObtenerCodigoRespuestaSegunTipoError(HttpError httpError)
        {
            switch (httpError.ExceptionType)
            {
                case "System.Data.SqlClient.SqlException": return "E3000";
                case "System.Data.SqlTypes.SqlNullValueException": return "E3001";
                case "System.Data.SqlTypes.SqlTruncateException": return "E3002";
                case "System.Data.SqlTypes.SqlTypeException": return "E3003";

                default: return "E1001";
            }
        }

        private static string ObtenerCodigoRespuestaSegunHttpResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    return "E4000";

                case HttpStatusCode.NotFound:
                    return "E4001";

                case HttpStatusCode.MethodNotAllowed:
                    return "E4002";

                default:
                    return "";
            }
        }
    }
}