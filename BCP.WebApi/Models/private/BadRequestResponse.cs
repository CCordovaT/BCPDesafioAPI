using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebApi.Models
{
	public class BadRequestResponse
{
        public string ErrorCode { get; set; }
        public string Mensaje { get; set; }
    }
}