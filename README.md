# Okapi Get Started
Okapi is a Selenium and ExtSelenium-based **Web UI test automation library** with dynamic content concept support
* Supports Selenium ChromeDriver, FirefoxDriver, InternetExplorerDriver, EdgeDriver and RemoteWebDriver
* Supports .Net Framework 4.5 and 4.6
* Advanced and unique auto and manual Page Object Model class code generation/recording algorithm
* Supports data-driven out of the box
* Reusable web driver from another execution session
* Manages Selenium drivers automatically
* Supports user-customized test report and logging
* Supports user-customized test project configuration for quick setup of test project
* Advanced built-in web object interaction library for developing reliable test scripts with less lines of code
* Search by anchor; search by two anchors; smart search
* Realiable
* Easy to integrate with any Unit test framework
* Ideal for setting up and running both locally and in any Continuous Integration environment

## NuGet
* https://www.nuget.org/packages/Okapi/1.2.4
* Install-Package Okapi -Version 1.2.4

## Dependencies
### .NETFramework 4.5
* ExtSelenium (>= 1.0.1.0)
* Ninject (>= 3.3.4)
* From 1.2.4, depends on Okapi.Common 1.0.0

### .NETFramework 4.6
* ExtSelenium (>= 1.0.1.0)
* Ninject (>= 3.3.4)
* From 1.2.4, depends on Okapi.Common 1.0.0

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
			   driverFlavour = "ChromeDriver"
         		   remoteDriver = "false"
			   driverTimeoutInSeconds = "10"
			   quitDriverOnError = "true"
			   log = "true"
			   takeSnapshotOnOK = "true"
			   takeSnapshotOnError = "true"
			   snapshotLocation = "Snapshots"
			   smartSearch = "true"
			   logPath = "Log.txt"
			   reportDirectory = "Report"/>
			<add targetTestEnvironment="Test2"
			   active = "false"
			   driverFlavour = "IE"
         		   remoteDriver = "false"
			   driverTimeoutInSeconds = "10"
			   quitDriverOnError = "true"
			   log = "true"
			   takeSnapshotOnOK = "true"
			   takeSnapshotOnError = "true"
			   snapshotLocation = "Snapshots"/>
		</Environments>
	</EnvironmentSection>
</configuration>
</configuration>
````
#### Using Class Configuration

If you decide to use class configs, implement the following interfaces:

* Implement **IDriverConfig** (optional)
````
internal class DriverConfig : IDriverConfig
{
    public int TimeoutInSeconds => 2;
    public DomUtilConfig SearchByAnchorConfig => null;        
}
````

* Implement **ITestEnvironment**
````
internal class TestEnvironment : ITestEnvironment
{
    public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
    public Uri SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
    public bool Log => false;
    public bool QuitDriverOnError => true;
    public bool QuitDriverOnFailVerification => true;
    public bool TakeSnapshotOnOK => false;
    public bool TakeSnapshotOnError => true;
    public string SnapshotLocation => "Snapshots";
    public bool RemoteDriver => false; //use local driver, not remote
    public bool SmartSearch => true; //from 1.2.3
    public string logPath => "Log.txt"; //from 1.2.4
    public string reportDirectory => "Report"; //from 1.2.4
}
````

You then can pass the objects of these classes into the constructors of the Okapi library's classes, i.e. 
````
DriverPool.Instance.CreateDriver(LocalChromeTestEnvironment.Instance)
````

OR you can inject them into Okapi via its Dependency Injection (DI) interface (using Ninject).

### Override Selenium Driver Options (Optional)

If you want to control the browsers' behaviours rather than using the default behaviours provided by Okapi, 
you can implement its **IDriverOptionsFactory** interface. For instance,

````
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
             //chromeOptions.AddArguments("headless");
             return chromeOptions;
    }
}
````

then inject it via DI.

At this time, Okapi supports the following browser types:

````
public enum DriverFlavour
{
    Chrome,
    Edge,
    Firefox,
    IE
}
````

### Customize Logging (Optional)
Okapi comes with the ability to log testing activities and to capture snapshots which are controllable via configuration.
You can customize the logging message template format and logging destination by implementing Okapi's interface **IOkapiLogger**.
Below is a simple implementation using Serilog's File sink. Serilog comes with many sinks. You can implement your own logger or implement your own Serilog sink to suit your logging and reporting needs.

Use Nuget package at https://www.nuget.org/packages/Okapi.Support.File/1.0.0 for the same purpose.

**Note**: from Okapi 1.2.4, Okapi configuration allows passing log file path and report directory via app.config or ItestEnvironment. Users don't need to perform Ninject dependencies with constructors, please use https://www.nuget.org/packages/Okapi.Support.File/1.0.1 for simpler. Also, users don't need to use Ninject at all.

````
internal class Logger : IOkapiLogger
{
    private readonly static SeriLogLogger logger = new LoggerConfiguration().WriteTo.File($"{Util.ParentProjectDirectory}			{Path.DirectorySeparatorChar}log.txt").CreateLogger();

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
````

### Customize Test Report (Optional)
Implement **IReportFormatter** interface. Below is a simple ReportFormatter sending test case execution results to a text file.
A comprehensive html/javascript report with summary charts will be developed in future as a seperate project/nuget package. 
To produce test report, you need to decorate your test case methods with attribute **TestCase** and test step methods with **Step**. Also, call **TestReport.Verify()** to perform assertions and update report (you can use any assertion library), and call **TestReport.Report()** at the end of the test methods and test step methods to send the report to the implementation class of IReportFormatter

* Example: https://github.com/tamnguyenbbt/Okapi.Support.File/blob/master/Okapi.Support.File/ReportFormatter.cs
* Use Nuget package at https://www.nuget.org/packages/Okapi.Support.File/1.0.0 for the same purpose.


### Inject Okapi Interface Implementations
Okapi comes with **IOkapiModuleLoader** interface for you to implement using Ninject's IKernel so that you can inject your settings mentioned above to Okapi

````
internal class DependencyInjector : IOkapiModuleLoader
{
    public void LoadAssemblyBindings(IKernel kernel)
    {
        kernel.Bind<ITestEnvironment>().To<TestEnvironment>().InSingletonScope(); //optional; if not provided, Okapi uses App.config
        kernel.Bind<IDriverConfig>().To<DriverConfig>().InSingletonScope(); //optional; if not provided, Okapi uses its built-in one
        kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope(); //optional; if not provided, Okapi uses its built-in one
        kernel.Bind<IOkapiLogger>().To<Logger>().InSingletonScope(); //optional; if not provided, Okapi does not log info
        kernel.Bind<IReportFormatter>().To<ReportFormatter>().InSingletonScope(); //optional; if not provided, Okapi does not produce test report
    }
}
````

**Note**: from 1.2.4, the implementation of **IOkapiModuleLoader** is not required for user-customized classes so the dependencies on Ninject is no longer required. Okapi automatically finds and loads the implementations for ITestEnvironment, IDriverConfig, IDriverOptionsFactory, IOkapiLogger, and  IReportFormatter if any.

## Sample Tests Using MSTest

* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/SampleTests.cs
          
## Versions
* Version **1.2.4** released on 04/07/2019

## Author
###  **Tam Nguyen**
[![View My profile on LinkedIn](https://static.licdn.com/scds/common/u/img/webpromo/btn_viewmy_160x33.png)](https://www.linkedin.com/in/tam-nguyen-a0792930/)
