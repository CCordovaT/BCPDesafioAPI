using BCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    [RoutePrefix("api/metas-por-asesor")]
    public class MetaPorAsesorController : BaseController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Insertar(MetaPorAsesor metaPorAsesor)
        {
            var nuevoIdMeta = unitOfWorkBCP.MetasPorAsesor.Insert(metaPorAsesor);

            return Ok(new { idMeta = nuevoIdMeta });
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult ObtenerMetasPorEncargadoPorPeriodo(int idUsuarioEncargado, int nroMes, int anio)
        {
            var listaMetas = unitOfWorkBCP.MetasPorAsesor.ObtenerMetasPorEncargadoPorPeriodo(idUsuarioEncargado, nroMes, anio);
            if (listaMetas.Count() == 0) return Content(HttpStatusCode.NoContent, listaMetas);

            return Ok(listaMetas);
        }
    }
}
