using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComicShop.Web.Startup))]
namespace ComicShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
