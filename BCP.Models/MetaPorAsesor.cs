using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class MetaPorAsesor
    {
        public int IdMeta { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int IdUsuario { get; set; }
        public double TotalPuntosMeta { get; set; }

        public string NombreAsesor { get; set; }
        public double TotalPuntosObtenidos { get; set; }
    }
    internal class MetaPorAsesorMapper : ClassMapper<MetaPorAsesor>
    {
        public MetaPorAsesorMapper()
        {
            Table("MetasPorAsesor");
            Map(prop => prop.IdMeta).Key(KeyType.Identity);
            Map(prop => prop.NombreAsesor).Ignore();
            Map(prop => prop.TotalPuntosObtenidos).Ignore();
            AutoMap();
        }
    }

}
