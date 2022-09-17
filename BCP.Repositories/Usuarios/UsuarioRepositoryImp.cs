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
    public class UsuarioRepositoryImp : BaseRepositoryImp<Usuario>, UsuarioRepository
    {
        public IEnumerable<Usuario> ObtenerListaSimplePorIdEncargado(int idUsuarioEncargado)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Query<Usuario>(@"SELECT u.IdUsuario, u.PrimerApellido || ' ' || u.SegundoApellido || ' ' || u.Nombres NombreCompleto 
                                                                        FROM Usuarios u WHERE u.IdUsuarioEncargado = @idUsuarioEncargado", new { idUsuarioEncargado });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario ObtenerPorCodAcceso(string codAccesoUsuario)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.QueryFirstOrDefault<Usuario>(@"SELECT u.IdUsuario, u.PrimerApellido, u.SegundoApellido, u.Nombres, u.IdCargo, c.DescripcionCargo, u.IdUsuarioEncargado,
                                                                            u.Contrasenia, u.IdAgencia, a.NombreAgencia, u.CodAccesoUsuario 
                                                                        FROM Usuarios u 
                                                                            INNER JOIN Agencias a ON u.IdAgencia = a.IdAgencia 
                                                                            INNER JOIN Cargos c ON u.IdCargo = c.IdCargo
                                                                        WHERE u.CodAccesoUsuario = @codAccesoUsuario", new { codAccesoUsuario });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
