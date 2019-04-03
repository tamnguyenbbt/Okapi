using System;
using System.IO;
using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Okapi.Extensions;
using Okapi.Logs;
using Okapi.Report;
using Okapi.Support.File;
using Okapi.TestUtils;

namespace OkapiSampleTests.ProjectConfig
{
    internal class DependencyInjector : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            string reportFileName = $"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}Report_{DateTime.Now.GetTimestamp()}.txt";
            string logFileName = $"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}Log.txt";
            kernel.Bind<ITestEnvironment>().To<TestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<DriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope();
            kernel.Bind<IOkapiLogger>().To<Logger>().InSingletonScope().WithConstructorArgument(Arg.FileName, logFileName); ;
            kernel.Bind<IReportFormatter>().To<ReportFormatter>().InSingletonScope().WithConstructorArgument(Arg.FileName, reportFileName);
        }
    }
}