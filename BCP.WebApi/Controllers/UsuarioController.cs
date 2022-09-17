using BCP.Commons;
using BCP.Models;
using BCP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuarioController : BaseController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult ObtenerPorId(string codAccesoUsuario)
        {          
            return Ok(unitOfWorkBCP.Usuarios.ObtenerPorCodAcceso(codAccesoUsuario).ConvertTo<UsuarioResponse>());
        }

        [Route("lista-simple")]
        [HttpGet]
        public IHttpActionResult ObtenerListaSimplePorEncargado(int idUsuarioEncargado)
        {
            return Ok(unitOfWorkBCP.Usuarios.ObtenerListaSimplePorIdEncargado(idUsuarioEncargado).Select(u => u.ConvertTo<UsuarioSimpleResponse>()));
        }
    }
}