using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMISProject.Startup))]
namespace CMISProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
