using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Models
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public int IdCargo { get; set; }
        public int IdUsuarioEncargado { get; set; }
        public int IdAgencia { get; set; }
        public string CodAccesoUsuario { get; set; }

        public string DescripcionCargo { get; set; }
        public string NombreAgencia { get; set; }
    }
}