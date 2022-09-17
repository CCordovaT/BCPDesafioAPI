using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class Agencia
    {
        public int IdAgencia { get; set; }
        public string NombreAgencia { get; set; }
    }

    internal class AgenciaMapper : ClassMapper<Agencia>
    {
        public AgenciaMapper()
        {
            Table("Agencias");
            Map(prop => prop.IdAgencia).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
