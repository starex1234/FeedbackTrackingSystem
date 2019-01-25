using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeedBackTracking.Startup))]
namespace FeedBackTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
