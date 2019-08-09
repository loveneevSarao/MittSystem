using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MittSystem.Startup))]
namespace MittSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
