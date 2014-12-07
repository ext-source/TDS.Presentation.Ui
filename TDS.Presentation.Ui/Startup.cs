using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDS.Presentation.Ui.Startup))]
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
