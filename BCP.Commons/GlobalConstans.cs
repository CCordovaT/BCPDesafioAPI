using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Commons
{
    public static class GlobalConstans
    {
        public const string MENSAJE_LOGUEO_INCORRECTO = "Usuario y/o contraseña incorrecta";

        public enum CargoUsuario
        {
            GERENTE = 1,
            ASESOR = 2,
        }

        public enum TipoCalculoProducto
        {
            FIJO = 1,
            PORCENTUAL = 2,
        }
    }
}
