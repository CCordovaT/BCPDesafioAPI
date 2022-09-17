using BCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public interface ClienteRepository : BaseRepository<Cliente>
    {
        IEnumerable<Cliente> ObtenerListaDetalladaClientes();
        new int Insert(Cliente cliente);
        IEnumerable<Cliente> ObtenerListaSimpleOrdenada();
    }
}
