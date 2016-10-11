using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jruchala_blog.Startup))]
namespace jruchala_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
