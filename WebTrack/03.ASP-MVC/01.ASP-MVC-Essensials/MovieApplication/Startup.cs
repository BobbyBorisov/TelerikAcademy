using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieApplication.Startup))]
namespace MovieApplication
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
