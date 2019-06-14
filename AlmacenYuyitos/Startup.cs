using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlmacenYuyitos.Startup))]
namespace AlmacenYuyitos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
