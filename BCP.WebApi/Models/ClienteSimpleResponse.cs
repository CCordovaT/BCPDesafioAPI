using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Models
{
    public class ClienteSimpleResponse
    {
        public int IdCliente { get; set; }
        public string NombreCompleto { get; set; }
    }
}