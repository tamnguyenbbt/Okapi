using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Serilog.Core;

namespace OkapiSampleTests.Configurations
{
    internal class CustomisedModuleLoader : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            kernel.Bind<ITestEnvironment>().To<LocalChromeTestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<CustomisedDriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<CustomisedDriverOptionsFactory>().InSingletonScope();
            kernel.Bind<ILogEventSink>().To<DefaultSink>().InSingletonScope();
        }
    }
}
