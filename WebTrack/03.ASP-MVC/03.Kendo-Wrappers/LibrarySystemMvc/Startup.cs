using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibrarySystemMvc.Startup))]
namespace LibrarySystemMvc
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
