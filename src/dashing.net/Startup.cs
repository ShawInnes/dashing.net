using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(dashing.net.Startup))]

namespace dashing.net
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
