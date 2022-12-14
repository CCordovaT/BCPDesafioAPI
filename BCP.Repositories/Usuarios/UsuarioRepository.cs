using BCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public interface UsuarioRepository : BaseRepository<Usuario>
    {
        Usuario ObtenerPorCodAcceso(string codAccesoUsuario);
        IEnumerable<Usuario> ObtenerListaSimplePorIdEncargado(int idUsuarioEncargado);
    }
}
