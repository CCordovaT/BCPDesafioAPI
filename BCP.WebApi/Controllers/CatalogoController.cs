using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    [RoutePrefix("api/catalogos")]
    public class CatalogoController : BaseController
    {
        [Route("tipos-de-documento")]
        [HttpGet]
        public IHttpActionResult ObtenerTiposDeDocumento()
        {
            return Ok(unitOfWorkBCP.TiposDeDocumento.GetAll());
        }
    }
}
