using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class TipoDeDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
    }
    internal class TipoDeDocumentoMapper : ClassMapper<TipoDeDocumento>
    {
        public TipoDeDocumentoMapper()
        {
            Table("TiposDeDocumento");
            Map(prop => prop.IdTipoDocumento).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
