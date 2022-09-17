using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Commons
{
    public static class CommonExtensions
    {
        public static bool InValues<T>(this T value, params T[] listaValores)
        {
            if (listaValores == null) throw new ArgumentException("No hay datos que validar");
            return listaValores.Contains(value);
        }

        public static int ToInt(this object value)
        {
            if (value is Enum) return (int)value;

            decimal.TryParse(value?.ToString(), out var valorConvertido);

            return int.Parse(Math.Round(valorConvertido, 0).ToString());
        }

        public static double ToDouble(this object value)
        {
            double.TryParse(value?.ToString(), out var valorConvertido);
            return valorConvertido;
        }

        public static DateTime ToDateTime(this object value)
        {
            DateTime.TryParse(value?.ToString(), out var valorConvertido);
            return valorConvertido;
        }

        public static bool ToBool(this object value)
        {
            return value?.ToString() == "1" || value?.ToString().ToUpper() == "TRUE";
        }

        public static bool IsEmpty(this object value)
        {
            return string.IsNullOrWhiteSpace(value?.ToString());
        }

        public static T ConvertTo<T>(this object value)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
        }
    }
}
