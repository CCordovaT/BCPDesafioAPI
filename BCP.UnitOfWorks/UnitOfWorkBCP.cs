using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCP.Models;
using BCP.Repositories;

namespace BCP.UnitOfWorks
{
    public class UnitOfWorkBCP : UnitOfWork
    {
        public BaseRepository<Agencia> Agencias => new BaseRepositoryImp<Agencia>();

        public UsuarioRepository Usuarios => new UsuarioRepositoryImp();

        public ClienteRepository Clientes => new ClienteRepositoryImp();

        public BaseRepository<TipoDeDocumento> TiposDeDocumento => new BaseRepositoryImp<TipoDeDocumento>();

        public BaseRepository<Producto> Productos => new BaseRepositoryImp<Producto>();

        public VentaRepository Ventas => new VentaRepositoryImp();

        public MetaPorAsesorRepository MetasPorAsesor => new MetaPorAsesorRepositoryImp();
    }
}
