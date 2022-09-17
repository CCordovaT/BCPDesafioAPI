using BCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    [RoutePrefix("api/ventas")]
    public class VentaController : BaseController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult ObtenerPorUsuarioPorPeriodoMensual(int idUsuario, int nroMes, int anio)
        {
            var listaVentas = unitOfWorkBCP.Ventas.ObtenerPorUsuarioPorPeriodoMensual(idUsuario, nroMes, anio);
            if (listaVentas.Count() == 0) return Content(HttpStatusCode.NoContent, listaVentas);

            return Ok(listaVentas);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Insertar(Venta venta)
        {
            venta.FechaRegistro = DateTime.Now;

            var idVentaNueva = unitOfWorkBCP.Ventas.CalcularPuntosEInsertar(venta);

            return Ok(new { idVenta = idVentaNueva });
        }
    }
}
