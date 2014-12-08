using Microsoft.Owin;

using Owin;

using TDS.Presentation.Ui;

[assembly: OwinStartup(typeof(Startup))]
namespace TDS.Presentation.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
