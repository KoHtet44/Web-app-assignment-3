using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyanTour.Startup))]
namespace MyanTour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
