using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LosYuyitos.Startup))]
namespace LosYuyitos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
