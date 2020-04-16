using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TruckApp.Startup))]
namespace TruckApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
