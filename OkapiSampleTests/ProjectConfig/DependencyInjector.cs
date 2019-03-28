using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Okapi.Logs;

namespace OkapiSampleTests.ProjectConfig
{
    internal class DependencyInjector : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            kernel.Bind<ITestEnvironment>().To<TestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<DriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope();
            kernel.Bind<IOkapiLogger>().To<Logger>().InSingletonScope();
        }
    }
}