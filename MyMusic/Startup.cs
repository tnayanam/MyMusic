using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMusic.Startup))]
namespace MyMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
