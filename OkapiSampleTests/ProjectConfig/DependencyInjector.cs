using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Okapi.Logs;
using Okapi.Support.File;

namespace OkapiSampleTests.ProjectConfig
{
    //no longer needed if using Okapi from 1.2.4 
    internal class DependencyInjector : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            // kernel.Bind<ITestEnvironment>().To<TestEnvironment>().InSingletonScope();
            // kernel.Bind<IDriverConfig>().To<DriverConfig>().InSingletonScope();
            // kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope();
            // kernel.Bind<IOkapiLogger>().To<Logger>().InSingletonScope();
            // kernel.Bind<ReportFormatter>().To<ReportFormatter>().InSingletonScope();
        }
    }
}