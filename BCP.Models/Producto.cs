using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int IdTipoCalculo { get; set; }
        public double FactorParaCalculo { get; set; }
    }
    internal class ProductoMapper : ClassMapper<Producto>
    {
        public ProductoMapper()
        {
            Table("Productos");
            Map(prop => prop.IdProducto).Key(KeyType.Identity);
            AutoMap();
        }
    }
}
