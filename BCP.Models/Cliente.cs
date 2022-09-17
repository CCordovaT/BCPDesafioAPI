using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public string NroCelular { get; set; }

        public string DescripcionTipoDocumento { get; set; }
        public string NombreCompleto { get; set; }
    }

    internal class ClienteMapper : ClassMapper<Cliente>
    {
        public ClienteMapper()
        {
            Table("Clientes");
            Map(prop => prop.IdCliente).Key(KeyType.Identity);
            Map(prop => prop.DescripcionTipoDocumento).Ignore();
            Map(prop => prop.NombreCompleto).Ignore();
            AutoMap();
        }
    }
}
