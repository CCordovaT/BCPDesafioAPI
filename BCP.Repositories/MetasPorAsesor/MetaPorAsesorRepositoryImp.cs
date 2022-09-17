using BCP.Commons;
using BCP.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public class MetaPorAsesorRepositoryImp : BaseRepositoryImp<MetaPorAsesor>, MetaPorAsesorRepository
    {
        public IEnumerable<MetaPorAsesor> ObtenerMetasPorEncargadoPorPeriodo(int idUsuarioEncargado, int nroMes, int anio)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Query<MetaPorAsesor>(@"SELECT u.IdUsuario, u.PrimerApellido || ' ' || u.SegundoApellido || ' ' || u.Nombres NombreAsesor,
                                                                    m.IdMeta, m.Mes, m.Anio, m.TotalPuntosMeta, 
                                                                    (SELECT SUM(v.PuntosObtenidos) FROM Ventas v WHERE v.IdUsuario = u.IdUsuario 
                                                                                        AND substr(v.FechaRegistro, 6, 2) = substr('00' || m.Mes, -2)
                                                                                        AND substr(v.FechaRegistro, 1, 4) = CAST(m.Anio AS TEXT)) TotalPuntosObtenidos
                                                                  FROM Usuarios u 
                                                                 LEFT JOIN MetasPorAsesor m ON u.IdUsuario = m.IdUsuario AND m.Mes = @nroMes AND m.Anio = @anio WHERE u.IdUsuarioEncargado = @idUsuarioEncargado", 
                                                                 new { nroMes, anio, idUsuarioEncargado });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public new int Insert(MetaPorAsesor metaPorAsesor)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.ExecuteScalar<int>(@"INSERT INTO MetasPorAsesor(Mes, Anio, IdUsuario, TotalPuntosMeta)
                                                           VALUES (@Mes, @Anio, @IdUsuario, @TotalPuntosMeta); SELECT last_insert_rowid();", new
                    {
                        metaPorAsesor.Mes,
                        metaPorAsesor.Anio,
                        metaPorAsesor.IdUsuario,
                        metaPorAsesor.TotalPuntosMeta
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
