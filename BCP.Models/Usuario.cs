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
    }

    internal class UsuarioMapper : ClassMapper<Usuario>
    {
        public UsuarioMapper()
        {
            Table("Usuarios");
            Map(prop => prop.IdUsuario).Key(KeyType.Identity);
            AutoMap();
        }
    }
}
