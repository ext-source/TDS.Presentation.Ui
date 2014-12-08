using Ninject.Activation;

namespace TDS.DataAccess.Implementation
{
    public class AppContextProvider : Provider<IContextAdapter<AppContext>>
    {
        protected override IContextAdapter<AppContext> CreateInstance(IContext context)
        {
            return new ContextAdapter<AppContext>(new AppContext());
        }
    }
}
