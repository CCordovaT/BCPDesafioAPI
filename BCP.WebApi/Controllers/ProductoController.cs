using BCP.Commons;
using BCP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductoController : BaseController
    {
        [Route("lista-simple")]
        [HttpGet]
        public IHttpActionResult ObtenerListaSimple()
        {
            return Ok(unitOfWorkBCP.Productos.GetAll().Select(p => p.ConvertTo<ProductoSimpleResponse>()));
        }
    }
}
