using BCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public interface MetaPorAsesorRepository : BaseRepository<MetaPorAsesor>
    {
        IEnumerable<MetaPorAsesor> ObtenerMetasPorEncargadoPorPeriodo(int idUsuarioEncargado, int nroMes, int anio);
        new int Insert(MetaPorAsesor metaPorAsesor);
    }
}
