using BCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public interface VentaRepository : BaseRepository<Venta>
    {
        IEnumerable<Venta> ObtenerPorUsuarioPorPeriodoMensual(int idUsuario, int nroMes, int Anio);
        int CalcularPuntosEInsertar(Venta venta);
    }
}
