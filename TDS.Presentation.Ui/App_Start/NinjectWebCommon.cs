using System;
using System.Data.Entity;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;

using TDS.DataAccess;
using TDS.DataAccess.Implementation;
using TDS.Mappings.ModulesMappings;
using TDS.Presentation.Ui;

using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace TDS.Presentation.Ui
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                Preload(kernel);

                LoadModules(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void Preload(IKernel kernel)
        {
            kernel.Bind<IContextAdapter<DbContext>>()
                .ToProvider<AppContextProvider>()
                .InRequestScope();
        }

        private static void LoadModules(IKernel kernel)
        {
            kernel.Load(
                new BussinessMappingsModule(),
                new PresentationMappingModule(), 
                new DataAccessMappingModule<DbContext>(
                    contextAdapter: kernel.Get<IContextAdapter<DbContext>>()));
        }
    }
}
