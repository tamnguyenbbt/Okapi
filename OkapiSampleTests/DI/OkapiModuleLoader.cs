using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Okapi.Logs;
using OkapiSampleTests.Configurations;
using OkapiSampleTests.ThirdParties;
using OkapiTests;

namespace OkapiSampleTests.DI
{
    internal class OkapiModuleLoader : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            kernel.Bind<ITestEnvironment>().To<LocalChromeTestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<DriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope();
            kernel.Bind<IOkapiLogger>().To<OkapiLogger>().InSingletonScope();
        }
    }
}