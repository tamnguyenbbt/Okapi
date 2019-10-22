# Okapi Get Started
**Okapi** is an advanced and easy-to-use Selenium-based **Web UI test automation library/framework**. **Okapi** was designed **not to be just another Web UI test automation library or Selenium-wrapper in the market**. It aims at changing the way you write and maintain Web UI test automation scripts to be fun, full of confidence and cost effective. It was designed and developed to be a game changer in Web UI automation testing business.

* Addresses all possible practical test automation difficulties, letting users to focus more on business rules of the web applications under test while scripting (in C#).
* Okapi is ready to use, there being little need to build another wrapper around it. 
* Comes under the form of NuGet package and supporting NuGet packages (report, logging, and common)
* First to introduce the advanced **search web elements by anchors** algorithms which are much simpler and intuitive to use and require much less script maintenance than traditional methods (id, name, tag name, class, css, xpath, etc.)
* Advanced **smart search** by anchors (turned on/off in config)
* Introduces **Reusable web driver from another execution session** (for better user-experience while developing test scripts)
* Introduces the **Dynamic Contents** concept for better code reusable and easy to use
* Advanced and unique auto and manual Page Object Model class code generation/recording algorithm
* Supports data-driven out of the box
* Manages Selenium drivers automatically
* Supports user-customized test report and logging, coming with two default report packages - text and html
* Supports user-customized test project configuration for quick setup of test project
* Advanced built-in web object interaction library for developing reliable test scripts with less lines of code
* Reliable API (i.e. all methods detect if the web element under test is found before performing an action on it. Click method also detects if the click action has taken effect otherwise retries up to 3 times, etc.)
* Supports Selenium ChromeDriver, FirefoxDriver, InternetExplorerDriver, EdgeDriver and RemoteWebDriver
* Supports .Net Framework 4.5, 4.6 and 4.7
* Easy to integrate with any Unit test framework
* Ideal for setting up and running both locally and in any Continuous Integration environment
* Smart search on traditional searching methods (id, class name, link text, xpath, etc.). For instance, "userName".GetTestObject().SendKeys("John") acts the same as "Id `userName`".GetTestObject().SendKeys("John").
Okapi treats traditional searching mwethods such Id and class name as special cases of the advanced search by anchors algorithm where search element is also the anchor element.

## NuGet
* https://www.nuget.org/packages/Okapi/1.4.1
* Install-Package Okapi -Version 1.4.1

## Blog
* https://okapi4automation.wordpress.com

## 'What You See Is What You Get' Style Test Development - First Simple Test Script

Facebook registration page

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/FacebookReg.png)

With Okapi, it is quick and easy to write test scripts

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/FirstTest.png)

## Dependencies
### .NETFramework 4.5, 4.6 and 4.7
* DotNetSeleniumExtras.WaitHelpers (>= 3.11.0)
* ExtSelenium (>= 1.0.14)
* LiteDB (>= 4.1.4)
* Ninject (>= 3.3.4)
* Newtonsoft.Json (>= 12.0.2)
* Okapi.Common (>= 1.0.8)
* Simplify.Windows.Forms (>= 1.0.0)

## Set Up Test Project
The code in this repo is for a sample test project based on MSUnit and .Net Framework 4.5 and uses Okapi library.

### Test Environment And Selenium Driver Configuration
Okapi supports both App.config and class configuration. App.config configuration takes precedence when both App.config and class configuration are provided.

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
	 active = "true"
	 driverFlavour = "ChromeDriver"
         remoteDriver = "false"
	 driverTimeoutInSeconds = "10"
	 quitDriverOnError = "true"
	 log = "true"
	 takeSnapshotOnOK = "true"
	 takeSnapshotOnError = "true"
	 snapshotLocation = "Snapshots"
         smartSearch = "true"
         logPath = "log.txt"
         reportDirectory = "Report"
         highlightOnSearch = "true"
	 highlightTimeInSeconds = "0.05"/>
      <add targetTestEnvironment="Test2"
	 active = "false"
	 driverFlavour = "IE"
         remoteDriver = "false"
	 driverTimeoutInSeconds = "10"
	 quitDriverOnError = "true"
	 log = "true"
	 takeSnapshotOnOK = "true"
	 takeSnapshotOnError ="true"
	 snapshotLocation = "Snapshots"
         smartSearch = "true"
         logPath = "log.txt"
         reportDirectory = "Report"/>
    </Environments>
  </EnvironmentSection>
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
    public string reportDirectory => "Report"; //from 1.2.4
    public bool HighlightOnSearch => true; //from 1.3.8 --> helpful in development time and debugging
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
* From 1.2.7, please use https://www.nuget.org/packages/Okapi.Support.Log.Text/1.0.1
* GitHub: https://github.com/tamnguyenbbt/Okapi.Support.Log.Text

**Note**: from Okapi 1.2.4, Okapi configuration allows passing log file path and report directory via app.config or ITestEnvironment. Users don't need to perform Ninject dependencies with constructors, please use https://www.nuget.org/packages/Okapi.Support.Log.Text/1.0.1 which provides the default implementation of IOkapiLogger. Also, users don't need to use Ninject at all.

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
* Nuget packages: https://www.nuget.org/packages/Okapi.Support.Report.Text/1.0.1 and https://www.nuget.org/packages/Okapi.Support.Report.Html/1.0.7

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

## Sample Test Structure Set-up Using Page Object Model
* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/PageObjectModelSample

## Sample Test Using Reusable Driver
* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/TestCases/ReusableDriver.cs
          
## Versions
* Version **1.4.1** released on 22/10/2019

## Author
###  **Tam Nguyen**
[![View My profile on LinkedIn](https://static.licdn.com/scds/common/u/img/webpromo/btn_viewmy_160x33.png)](https://www.linkedin.com/in/tam-nguyen-a0792930/)

## Future Support/Development
Okapi Studio, desktop application for Okapi is under development and demo version is expected to be released mid 2020.
Okapi Studio leverages the power of Okapi and has the following base features:
* Test artefact creation/edit vis UI. Unlike other tools in the market which have UI view and expert (code) view, Okapi Studio has only one UI view to be simple but it is advanced so users can create sophisticated tests without writing any line of code.
* Test artefact manager - project, test case, test step, test suite, object repository
* Execution/Debug - tests, test, actions, action, line by line, breakpoints
* Report
* Import/Export
* Test Data Parameterization
* Console Runner for CI/CD

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiStudio1.png)

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiStudio2.png)


