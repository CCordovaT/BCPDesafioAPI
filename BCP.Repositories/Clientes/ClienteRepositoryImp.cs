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
    public class ClienteRepositoryImp : BaseRepositoryImp<Cliente>, ClienteRepository
    {
        public IEnumerable<Cliente> ObtenerListaDetalladaClientes()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Query<Cliente>(@"SELECT u.*, t.DescripcionTipoDocumento
                                                         FROM Clientes u 
                                                         INNER JOIN TiposDeDocumento t on t.IdTipoDocumento = u.IdTipoDocumento");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public new int Insert(Cliente cliente)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.ExecuteScalar<int>(@"INSERT INTO Clientes(IdTipoDocumento, NroDocumento, PrimerApellido, SegundoApellido, Nombres, NroCelular)
                                                    VALUES(@IdTipoDocumento, @NroDocumento, @PrimerApellido, @SegundoApellido, @Nombres, @NroCelular); SELECT last_insert_rowid();", new { cliente.IdTipoDocumento, cliente.NroDocumento,
                                                cliente.PrimerApellido, cliente.SegundoApellido, cliente.Nombres, cliente.NroCelular});
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Cliente> ObtenerListaSimpleOrdenada()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Query<Cliente>("SELECT IdCliente, PrimerApellido || ' ' || SegundoApellido || ' ' || Nombres NombreCompleto FROM Clientes Order By 2");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
