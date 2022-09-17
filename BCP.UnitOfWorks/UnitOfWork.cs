using BCP.Models;
using BCP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.UnitOfWorks
{
    public interface UnitOfWork
    {
        BaseRepository<Agencia> Agencias { get; }
        UsuarioRepository Usuarios { get; }
        ClienteRepository Clientes { get; }
        BaseRepository<TipoDeDocumento> TiposDeDocumento { get; }
        BaseRepository<Producto> Productos { get; }
        VentaRepository Ventas { get; }
        MetaPorAsesorRepository MetasPorAsesor { get; }
    }
}
