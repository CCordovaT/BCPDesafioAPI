using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public int IdCargo { get; set; }
        public int IdUsuarioEncargado { get; set; }
        public string Contrasenia { get; set; }
        public int IdAgencia { get; set; }
        public string CodAccesoUsuario { get; set; }

        public string DescripcionCargo { get; set; }
        public string NombreAgencia { get; set; }
        public string NombreCompleto { get; set; }
    }

    internal class UsuarioMapper : ClassMapper<Usuario>
    {
        public UsuarioMapper()
        {
            Table("Usuarios");
            Map(prop => prop.IdUsuario).Key(KeyType.Identity);
            Map(prop => prop.DescripcionCargo).Ignore();
            Map(prop => prop.NombreAgencia).Ignore();
            Map(prop => prop.NombreCompleto).Ignore();
            AutoMap();
        }
    }
}
