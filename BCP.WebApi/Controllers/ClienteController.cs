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
    [RoutePrefix("api/clientes")]
    public class ClienteController : BaseController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Insertar(Cliente cliente)
        {
            var nuevoIdCliente = unitOfWorkBCP.Clientes.Insert(cliente);

            return Ok(new { idCliente = nuevoIdCliente });
        }

        [Route("lista-simple")]
        [HttpGet]
        public IHttpActionResult ObtenerListaSimple()
        {
            return Ok(unitOfWorkBCP.Clientes.ObtenerListaSimpleOrdenada().Select(c => { return c.ConvertTo<ClienteSimpleResponse>(); }));
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult ObtenerTodos()
        {
            var listaClientes = unitOfWorkBCP.Clientes.ObtenerListaDetalladaClientes();
            if (listaClientes.Count() == 0) return Content(HttpStatusCode.NoContent, listaClientes);

            return Ok(listaClientes);
        }
    }
}
