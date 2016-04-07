using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupplyChain.WebUI.Startup))]
namespace SupplyChain.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
