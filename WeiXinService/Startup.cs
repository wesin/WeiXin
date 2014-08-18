using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiXinService.Startup))]
namespace WeiXinService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
