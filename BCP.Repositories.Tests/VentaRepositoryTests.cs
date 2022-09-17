using System;
using System.Linq;
using BCP.Commons;
using BCP.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BCP.Commons.GlobalConstans;

namespace BCP.Repositories.Tests
{
    [TestClass]
    public class VentaRepositoryTests
    {
        private readonly VentaRepository ventaRepository;
        private readonly UsuarioRepository usuarioRepository;
        private readonly BaseRepository<Producto> productoRepository;

        public VentaRepositoryTests()
        {
            ventaRepository = new VentaRepositoryImp();
            usuarioRepository = new UsuarioRepositoryImp();
            productoRepository = new BaseRepositoryImp<Producto>();
        }

        [TestMethod]
        public void DeberiaInsertarVentaYCalcularLosPuntosParaValoresFijos()
        {
            Usuario usuarioAsesor = ObtenerUsuarioAsesor();
            var producto = productoRepository.GetAll().First(p => p.IdTipoCalculo == TipoCalculoProducto.FIJO.ToInt());

            var ventaEsperada = new Venta()
            {
                FechaRegistro = DateTime.Now,
                IdCliente = 1,
                IdUsuario = usuarioAsesor.IdUsuario,
                IdProducto = producto.IdProducto,
                MontoVenta = 2000.0,
                PuntosObtenidos = producto.FactorParaCalculo
            };

            var ventaRequest = new Venta()
            {
                FechaRegistro = ventaEsperada.FechaRegistro,
                IdCliente = ventaEsperada.IdCliente,
                IdUsuario = ventaEsperada.IdUsuario,
                IdProducto = ventaEsperada.IdProducto,
                MontoVenta = ventaEsperada.MontoVenta
            };

            var idVentaNueva = ventaRepository.CalcularPuntosEInsertar(ventaRequest);

            idVentaNueva.Should().BeGreaterThan(0);

            var ventaActual = ventaRepository.GetByKey(idVentaNueva);

            ventaActual.Should().BeEquivalentTo(ventaEsperada, options => options.Excluding(p => p.IdVenta));
        }

        private Usuario ObtenerUsuarioAsesor()
        {
            return usuarioRepository.GetAll().First(u => u.IdCargo == CargoUsuario.ASESOR.ToInt());
        }

        [TestMethod]
        public void DeberiaInsertarVentaYCalcularLosPuntosParaValoresPorcentuales()
        {
            var usuarioAsesor = ObtenerUsuarioAsesor();
            var producto = productoRepository.GetAll().First(p => p.IdTipoCalculo == TipoCalculoProducto.PORCENTUAL.ToInt());

            var montoVenta = 2000.3;

            var ventaEsperada = new Venta()
            {
                FechaRegistro = DateTime.Now,
                IdCliente = 1,
                IdUsuario = usuarioAsesor.IdUsuario,
                IdProducto = producto.IdProducto,
                MontoVenta = montoVenta,
                PuntosObtenidos = Math.Round(producto.FactorParaCalculo * montoVenta, 2)
            };

            var ventaRequest = new Venta()
            {
                FechaRegistro = ventaEsperada.FechaRegistro,
                IdCliente = ventaEsperada.IdCliente,
                IdUsuario = ventaEsperada.IdUsuario,
                IdProducto = ventaEsperada.IdProducto,
                MontoVenta = ventaEsperada.MontoVenta
            };

            var idVentaNueva = ventaRepository.CalcularPuntosEInsertar(ventaRequest);

            idVentaNueva.Should().BeGreaterThan(0);

            var ventaActual = ventaRepository.GetByKey(idVentaNueva);

            ventaActual.Should().BeEquivalentTo(ventaEsperada, options => options.Excluding(p => p.IdVenta));
        }
    }
}
