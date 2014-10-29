using EasyNetQTalk.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace EasyNetQTalk.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR()
               .UseNancy();
        }
    }
}