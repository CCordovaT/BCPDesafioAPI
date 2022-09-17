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
        public Usuario ObtenerPorCodAcceso(string CodAccesoUsuario)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE CodAccesoUsuario = @CodAccesoUsuario", new { CodAccesoUsuario });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
