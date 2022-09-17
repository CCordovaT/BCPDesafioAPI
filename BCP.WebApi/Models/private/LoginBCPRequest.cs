using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Models
{
    public class LoginBCPRequest
    {
        public string CodUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}