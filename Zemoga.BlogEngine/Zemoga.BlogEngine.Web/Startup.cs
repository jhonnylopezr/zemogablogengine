using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zemoga.BlogEngine.Web.Startup))]
namespace Zemoga.BlogEngine.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
