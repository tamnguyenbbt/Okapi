using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;

namespace OkapiSampleTests.Configurations
{
    internal class CustomisedModuleLoader : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            kernel.Bind<ITestEnvironment>().To<LocalChromeTestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<CustomisedDriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<CustomisedDriverOptionsFactory>().InSingletonScope();
        }
    }
}