using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BCP.WebApi.Models
{
    [DataContract]
    public class ApiResponse
    {

        [DataMember(EmitDefaultValue = false)]
        public string CodigoRespuesta { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string MensajeError { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Data { get; set; }
    }
}