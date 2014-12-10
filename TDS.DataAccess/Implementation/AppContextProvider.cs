using Ninject.Activation;

namespace TDS.DataAccess.Implementation
{
    public class AppContextProvider : Provider<IContextAdapter<AppContext>>
    {
        protected override IContextAdapter<AppContext> CreateInstance(IContext context)
        {
            AppContext appContext = new AppContext();
            //appContext.Configuration.AutoDetectChangesEnabled = false;
            return new ContextAdapter<AppContext>(appContext);
        }
    }
}
