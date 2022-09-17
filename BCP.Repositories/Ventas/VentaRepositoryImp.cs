using BCP.Commons;
using BCP.Models;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BCP.Commons.GlobalConstans;

namespace BCP.Repositories
{
    public class VentaRepositoryImp : BaseRepositoryImp<Venta>, VentaRepository
    {
        public int CalcularPuntosEInsertar(Venta venta)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    var productoVendido = connection.Get<Producto>(venta.IdProducto);

                    venta.PuntosObtenidos = CalcularPuntosPorProducto(venta.MontoVenta, productoVendido);

                    return connection.ExecuteScalar<int>(@"INSERT INTO Ventas(FechaRegistro, IdUsuario, IdCliente, MontoVenta, PuntosObtenidos, IdProducto) VALUES
                                                          (@FechaRegistro, @IdUsuario, @IdCliente, @MontoVenta, @PuntosObtenidos, @IdProducto); SELECT last_insert_rowid();", 
                                                         new { venta.FechaRegistro, venta.IdUsuario, venta.IdCliente, venta.MontoVenta, venta.PuntosObtenidos, venta.IdProducto });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private double CalcularPuntosPorProducto(double montoVenta, Producto productoVendido)
        {
            var puntosObtenidos = 0.0;

            if (productoVendido.IdTipoCalculo == TipoCalculoProducto.FIJO.ToInt())
            {
                puntosObtenidos =  productoVendido.FactorParaCalculo;
            } else if (productoVendido.IdTipoCalculo == TipoCalculoProducto.PORCENTUAL.ToInt())
            {
                puntosObtenidos = Math.Round(montoVenta * productoVendido.FactorParaCalculo, 2);
            }

            return puntosObtenidos;
        }

        public IEnumerable<Venta> ObtenerPorUsuarioPorPeriodoMensual(int idUsuario, int nroMes, int anio)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Query<Venta>(@"SELECT v.*, u.CodAccesoUsuario, c.PrimerApellido || ' ' || c.SegundoApellido || ' ' || c.Nombres NombreCompletoCliente,
                                                            p.DescripcionProducto FROM Ventas v 
                                                            INNER JOIN Usuarios u ON u.IdUsuario = v.IdUsuario
                                                            INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                                                            INNER JOIN Productos p ON p.IdProducto = v.IdProducto
                                                        WHERE v.IdUsuario = @idUsuario and substr(v.FechaRegistro, 6, 2) = @nroMes and substr(v.FechaRegistro, 1, 4) = @anio",
                                                            new
                                                            {
                                                                idUsuario,
                                                                nroMes = nroMes.ToString("00"),
                                                                anio = anio.ToString()
                                                            });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
