using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagazinOnline.Startup))]
namespace MagazinOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
