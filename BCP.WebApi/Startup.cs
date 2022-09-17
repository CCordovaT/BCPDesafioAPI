using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(BCP.WebApi.Startup))]

namespace BCP.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var oConfiguracion = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);

            Register(oConfiguracion);

            ConfigurationOAuth(app);

            app.UseWebApi(oConfiguracion);
        }
    }
}
