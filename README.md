# Okapi Get Started
**Okapi** is a Selenium and ExtSelenium-based **Web UI test automation library/framework** with the following key features
* Unlike many free and commercial test automation frameworks in the market, providing good user interfaces, utilities, a compiler, an object repository, a not very smart recording and object spying tool based on traditional html searching methods (id, name, tag name, class, css, xpath, etc.), and an API library then let users to deal with all the real-life tough test automation scripting obstacles such as timing, single-page application automation obstacles, AJAX etc. (that why a lot of organizations after deciding to buy/get them, have to find experiened and technical strong automation testers and form a large team to build test automation frameworks around them. Sometimes, they have to involve some good web developers and spend years to build the automation test frameworks around them. Unfortunately, quite often web developers have little knowledge and experience on real-life test automation difficulties and quite often they fail or create messy frameworks.), Okapi deals with all these things, letting users to focus more on business rules of the web applications under test while scripting (there is little need to build automation framework around Okapi).  
* Comes under the form of NuGet package and supporting NuGet packages (report, logging, and common), ready to be downloaded and used
* With its advanced algorithm, **being the first automation test framework in the market** to introduce the search web elements by anchors method, which are much simpler and intuitive to use and require much less script maintenance than traditional methods (id, name, tag name, class, css, xpath, etc.)
* Introduces the **Dynamic Contents** concept for better code reusable and easy to use
* Advanced and unique auto and manual Page Object Model class code generation/recording algorithm
* Advanced **smart search** by anchors (turned on/off in config)
* Supports data-driven out of the box
* **Reusable web driver from another execution session** (for better user-experience while developing test scripts)
* Manages Selenium drivers automatically
* Supports user-customized test report and logging, coming with two default report packages - text and html
* Supports user-customized test project configuration for quick setup of test project
* Advanced built-in web object interaction library for developing reliable test scripts with less lines of code
* Reliable
* Supports Selenium ChromeDriver, FirefoxDriver, InternetExplorerDriver, EdgeDriver and RemoteWebDriver
* Supports .Net Framework 4.5 and 4.6* 
* Easy to integrate with any Unit test framework
* Ideal for setting up and running both locally and in any Continuous Integration environment

## NuGet
* https://www.nuget.org/packages/Okapi/1.2.27
* Install-Package Okapi -Version 1.2.27

## Dependencies
### .NETFramework 4.5
* DotNetSeleniumExtras.WaitHelpers (>= 3.11.0)
* ExtSelenium (>= 1.0.6)
* LiteDB (>= 4.1.4)
* Ninject (>= 3.3.4)
* Okapi.Common (>= 1.0.7)
* Simplify.Windows.Forms (>= 1.0.0)

### .NETFramework 4.6
* DotNetSeleniumExtras.WaitHelpers (>= 3.11.0)
* ExtSelenium (>= 1.0.6)
* LiteDB (>= 4.1.4)
* Ninject (>= 3.3.4)
* Okapi.Common (>= 1.0.7)
* Simplify.Windows.Forms (>= 1.0.0)

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

OR you can inject them into Okapi via its Dependency Injection (DI) interface (using Ninject). From version 1.2.3, Okapi automatically picks up the implemented classes without the need to inject vis DI (DI is stilled supported).

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

* Nuget package at https://www.nuget.org/packages/Okapi.Support.File/1.0.0 (obsolete)
* From 1.2.7, please use https://www.nuget.org/packages/Okapi.Support.Log.Text/1.0.0
* GitHub: https://github.com/tamnguyenbbt/Okapi.Support.Log.Text

**Note**: from Okapi 1.2.4, Okapi configuration allows passing log file path and report directory via app.config or ITestEnvironment. Users don't need to perform Ninject dependencies with constructors, please use https://www.nuget.org/packages/Okapi.Support.Log.Text/1.0.0 which provides the default implementation of IOkapiLogger. Also, users don't need to use Ninject at all.

````
    public class Logger : IOkapiLogger
    {
        private static SeriLogLogger logger;

        public Logger()
        {
            string logFileName = Session.Instance.LogPath;
            logger = new LoggerConfiguration().WriteTo.File(logFileName).CreateLogger();
        }

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
Implement **IReportFormatter** interface.
To produce test report, you need to decorate your test case methods with Okpai **TestCase** attribute and test step methods with Okapi **Step** attribute. Also, call **TestReport.Verify()** to perform assertions and update report (you can use any assertion library), and call **TestReport.Report()** at the end of the test methods and test step methods to send the report to the implementation class of IReportFormatter

* GitHub: https://github.com/tamnguyenbbt/Okapi.Support.Report.Text (report to text file) and https://github.com/tamnguyenbbt/Okapi.Support.Report.Html (report to html files)
* Nuget packages: https://www.nuget.org/packages/Okapi.Support.Report.Text/1.0.1 and https://www.nuget.org/packages/Okapi.Support.Report.Html/1.0.2

**Note**: from Okapi 1.2.4, Okapi configuration allows passing log file path and report directory via app.config or ITestEnvironment. Users don't need to perform Ninject dependencies with constructors.

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

* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/TestCases/SimpleTests.cs
          
## Versions
* Version **1.2.27** released on 07/08/2019

## Author
###  **Tam Nguyen**
[![View My profile on LinkedIn](https://static.licdn.com/scds/common/u/img/webpromo/btn_viewmy_160x33.png)](https://www.linkedin.com/in/tam-nguyen-a0792930/)
