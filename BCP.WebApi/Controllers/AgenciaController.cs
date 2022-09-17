using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    [RoutePrefix("api/agencias")]
    public class AgenciaController : BaseController
    { 
        [Route("")]
        [HttpGet]
        public IHttpActionResult ObtenerTodos()
        {
            return Ok(unitOfWorkBCP.Agencias.GetAll().OrderBy(a => a.NombreAgencia));
        }
    }
}
