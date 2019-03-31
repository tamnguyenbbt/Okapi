# Okapi Get Started
Okapi is a Selenium and ExtSelenium-based **Web UI test automation library** with dynamic content concept support
* Supports Selenium ChromeDriver, FirefoxDriver, InternetExplorerDriver, EdgeDriver and RemoteWebDriver
* Supports .Net Framework 4.5 and 4.6
* Supports data-driven out of the box 
* -->  When passing null value to action methods (i.e. SendKeys), they will do nothing
* --> Every time changing dynamic contents with new data values, new web element will be referenced, ready to accept user actions (useful for acting on menus, dropdowns, and tables)
* Manages Selenium drivers automatically and hides them from users to simplify test automation processes
* Ideal for setting Web UI automation test project using Page object Model (POM). The combination of data-driven and POM will result in better decoupling, cleaner code, low cost of maintenance, and easier to scale.
* Support user-customized test report (users to implement IReportFormatter interface so you can format test report and send it to destination (ALM, Web services, etc.) based on your needs without being dependent on test franeworks like MSUnit, NUnit, Cucumber-based ones, etc.). This introduces a bit of overhead in your test script or test script cleanup but gives you the fexibility to report in any format (text, html, etc.) to any destination you and your organisation want to. Currently this supports reporting to test case level. Reporting to test step level will be in development soon.

## NuGet
* https://www.nuget.org/packages/Okapi/1.0.0.9
* Install-Package Okapi -Version 1.0.0.9

## Dependencies
### .NETFramework 4.5
* ExtSelenium (>= 1.0.0.3)
* Ninject (>= 3.3.4)

### .NETFramework 4.6
* ExtSelenium (>= 1.0.0.3)
* Ninject (>= 3.3.4)

## Set Up Test Project
The code in this repo is for a sample test project based on MSUnit and .Net Framework 4.5 and uses Okapi library.

### Test Environment And Selenium Driver Configuration
Okapi supports both App.config and class configuration. Class configuration takes precedence when both App.config and class configuration are provided.

#### Using App.config

If you decide to use **App.config**, add an App.config file as below:

````
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="EnvironmentSection" type="Okapi.Configs.EnvironmentSection, Okapi" />
	</configSections>
	<appSettings>
		<add key="SeleniumHubUrl" value="http://localhost:2021/wd/hub"/>
	</appSettings>
	<EnvironmentSection>
		<Environments>
			<add targetTestEnvironment="Test1"
			   active="true"
			   driverFlavour="ChromeDriver"
         		   remoteDriver="false"
			   driverTimeoutInSeconds ="10"
			   quitDriverOnError ="true"
			   log ="true"
			   takeSnapshotOnOK ="true"
			   takeSnapshotOnError ="true"
			   snapshotLocation ="Snapshots"/>
			<add targetTestEnvironment="Test2"
			   active="false"
			   driverFlavour="IE"
         		   remoteDriver="false"
			   driverTimeoutInSeconds ="10"
			   quitDriverOnError ="true"
			   log ="true"
			   takeSnapshotOnOK ="true"
			   takeSnapshotOnError ="true"
			   snapshotLocation ="Snapshots"/>
		</Environments>
	</EnvironmentSection>
</configuration>
</configuration>
````
#### Using Class Configuration

If you decide to use class configs, implement the following interfaces:

* Implement **IDriverConfig**
````
using ExtSelenium.DomCore;
using Okapi.Configs;

namespace OkapiSampleTests.Configurations
{
    public class DriverConfig : IDriverConfig
    {
        public int TimeoutInSeconds => 10; //if not set, Okapi set 10 by default
        public bool QuitDriverOnError => true; //if not set, Okapi set true by default
        public DomUtilConfig SearchByAnchorConfig => null;
    }
}
````

* Implement **ITestEnvironment**
````
using System;
using Okapi.Configs;
using Okapi.Enums;

namespace OkapiTests
{
    internal class TestEnvironment : ITestEnvironment
    {
        public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
        public Uri SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
        public bool Log => true; //enable logging
        public bool TakeSnapshotOnOK => true;
        public bool TakeSnapshotOnError => true;
        public string SnapshotLocation => "Snapshots";
        public bool RemoteDriver => false; //use local driver, not remote
    }
}
````

You then can pass the objects of these classes into the constructors of the Okapi library's classes, i.e. 
````
DriverPool.Instance.CreateDriver(LocalChromeTestEnvironment.Instance)
````

OR you can inject them into Okapi via its Dependency Injection (DI) interface (using Ninject).

### Override Selenium Driver Options 

If you want to control the browsers' behaviours rather than using the default behaviours provided by Okapi, 
you can implement its **IDriverOptionsFactory** interface. For instance,

````
using Okapi.Drivers;
using Okapi.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace OkapiSampleTests.Configurations
{
    internal class DriverOptionsFactory : IDriverOptionsFactory
    {
        public DriverOptions CreateDriverOptions(DriverFlavour driverFlavour)
        {
            switch (driverFlavour)
            {
                case DriverFlavour.Edge:
                    return new EdgeOptions();
                case DriverFlavour.IE:
                    return new InternetExplorerOptions();
                case DriverFlavour.Firefox:
                    return new FirefoxOptions();
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");
                    return chromeOptions;
            }
        }
    }
}
````

then inject it via DI.

At this time, Okapi supports the following browser types:

````
namespace Okapi.Enums
{
    public enum DriverFlavour
    {
        Chrome,
        Edge,
        Firefox,
        IE
    }
}
````

### Customize Logging
Okapi comes with the ability to log testing activities and to capture snapshots which are controllable via configuration.
You can customize the logging message template format and logging destination by implementing Okapi's interface **IOkapiLogger**.
Below is a simple implementation using Serilog's File sink. Serilog comes with many sinks. You can implement your own logger or implement your own Serilog sink to suit your logging and reporting needs.

At this point of time, IOkapiLogger supports string messages. JSON support may come in future.

````
using System;
using System.IO;
using Okapi.Logs;
using Okapi.TestUtils;
using Serilog;
using SeriLogLogger = Serilog.Core.Logger;

namespace OkapiSampleTests.ProjectConfig
{
    internal class Logger : IOkapiLogger
    {
        private readonly static SeriLogLogger logger = new LoggerConfiguration().WriteTo.File($"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}log.txt").CreateLogger();

        public void Error(string messageTemplate)
        {
            logger.Error(messageTemplate);
        }

        public void Error(string messageTemplate, Exception exception)
        {
            logger.Error(exception, messageTemplate);
        }

        public void Info(string messageTemplate)
        {
            logger.Information(messageTemplate);
        }
    }
}
````

### Customize Test Report
Implement **IReportFormatter** interface. Below is a simple ReportFormatter sending test case execution results to a text file.
A comprehensive html/javascript report with summary charts will be developed in future as a seperate project/nuget package. 

````
using System;
using System.IO;
using System.Text;
using Okapi.Extensions;
using Okapi.Report;
using Okapi.TestUtils;
using Serilog;
using SeriLogLogger = Serilog.Core.Logger;

namespace OkapiSampleTests.ProjectConfig
{
    internal class ReportFormatter : IReportFormatter
    {
        private readonly static SeriLogLogger logger = new LoggerConfiguration()
            .WriteTo
            .File($"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}Report_{DateTime.Now.GetTimestamp()}.txt").CreateLogger();

        public void Run(ReportData data)
        {
            StringBuilder reportStringBuilder = new StringBuilder();
            reportStringBuilder.Append($"TEST CASE: {data.TestMethod.Name}");

            reportStringBuilder.Append($"{Environment.NewLine}");
            reportStringBuilder.Append("\t");
            reportStringBuilder.Append($"RESULT: {data.TestResult}");

            if (data.DurationInSeconds != -1)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"DURATION: {data.DurationInSeconds} seconds");
            }

            if (data.StartDateTime != null)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"START TIME: {data.StartDateTime}");
            }

            reportStringBuilder.Append($"{Environment.NewLine}");
            reportStringBuilder.Append("\t");
            reportStringBuilder.Append($"END TIME: {data.EndDateTime}");

            if (data.AdditionalData.HasAny())
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"ADDITIONAL DATA: {data.AdditionalData.ConvertToString()}");
            }

            if (data.FailDetails != null)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"FAIL INFO: {data.FailDetails}");
            }

            if (data.Exception != null)
            {
                reportStringBuilder.Append($"{Environment.NewLine}");
                reportStringBuilder.Append("\t");
                reportStringBuilder.Append($"EXCEPTION: {data.Exception}");
            }

            if (data.TestResult.Equals(TestResult.PASS))
            {
                logger.Information(reportStringBuilder.ToString());
            }
            else
            {
                logger.Error(reportStringBuilder.ToString());
            }
        }
    }
}
````

### Inject Okapi Interface Implementations
Okapi comes with **IOkapiModuleLoader** interface for you to implement using Ninject's IKernel so that you can inject your settings mentioned above to Okapi

````
using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Okapi.Logs;
using Okapi.Report;

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
            kernel.Bind<IReportFormatter>().To<ReportFormatter>().InSingletonScope();
        }
    }
}
````

## Example
````
See https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/SampleTests.cs
````

## Usage
* Usage document will come in near future.
            
## Versions
* Version **1.0.0.9** released on 03/31/2019
* Version **1.0.0.8** released on 03/31/2019
* Version **1.0.0.7** released on 03/30/2019
* Version **1.0.0.6** released on 03/29/2019
* Version **1.0.0.5** released on 03/28/2019
* Version **1.0.0.4** released on 03/28/2019
* Version **1.0.0.3** released on 03/26/2019
* Version **1.0.0.2** released on 03/21/2019
* Version **1.0.0.1** released on 03/20/2019
* Version **1.0.0** released on 03/19/2019

## Author
###  **Tam Nguyen**
[![View My profile on LinkedIn](https://static.licdn.com/scds/common/u/img/webpromo/btn_viewmy_160x33.png)](https://www.linkedin.com/in/tam-nguyen-a0792930/)
