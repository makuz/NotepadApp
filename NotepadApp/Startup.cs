using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotepadApp.Startup))]
namespace NotepadApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
