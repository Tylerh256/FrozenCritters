using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrozenCritters.Startup))]
namespace FrozenCritters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
