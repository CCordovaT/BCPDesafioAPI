using BCP.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        protected UnitOfWork unitOfWorkBCP;

        public BaseController()
        {
            unitOfWorkBCP = new UnitOfWorkBCP();
        }
    }
}
