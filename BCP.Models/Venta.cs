using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public double MontoVenta { get; set; }
        public double PuntosObtenidos { get; set; }

        public string CodAccesoUsuario { get; set; }
        public string NombreCompletoCliente { get; set; }
        public string DescripcionProducto { get; set; }
    }

    internal class VentaMapper : ClassMapper<Venta>
    {
        public VentaMapper()
        {
            Table("Ventas");
            Map(prop => prop.IdVenta).Key(KeyType.Identity);
            Map(prop => prop.CodAccesoUsuario).Ignore();
            Map(prop => prop.NombreCompletoCliente).Ignore();
            Map(prop => prop.DescripcionProducto).Ignore();
            AutoMap();
        }
    }
}
