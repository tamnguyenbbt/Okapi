# Okapi Get Started
**Okapi** is an advanced and easy-to-use Selenium-based **Web UI test automation library/framework**. **Okapi** was designed **not to be just another Web UI test automation library or Selenium-wrapper in the market**. It aims at changing the way you write and maintain Web UI test automation scripts to be fun, full of confidence and cost effective at top levels. It was designed and developed to be game changer in Web UI automation testing business. Okapi is powerful and open.

* Addresses all possible practical test automation difficulties, letting users to focus more on business rules of the web applications under test while scripting (in C#). Okapi helps to build reliable and easy-to-maintain test scripts. If timing and stale element issues from Selenium and from other free or commercial tools have long been haunting you (timing issue is number one cause of failure web ui test automation projects), Okapi lifts all those out for you. Okapi has built-in mechanisms and supporting methods which help you to build reliable tests without having timing issues bothering you.
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
* Supports user-defined actions, to extend/add the web interactive actions where Okapi has not provided yet.
* Comes with FileDB functionality to save and share test data between tests and steps.

## NuGet
* https://www.nuget.org/packages/Okapi/1.6.4
* Install-Package Okapi -Version 1.6.4

## Blog
* https://okapi4automation.wordpress.com

## 'What You See Is What You Get' Style Test Development - First Simple Test Script

**Facebook registration page**

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/FacebookReg.png)

**With Okapi, it is quick and easy to write test scripts.**

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/FirstTest.png)

## Dependencies
### .NETFramework 4.5, 4.6 and 4.7
* DotNetSeleniumExtras.WaitHelpers (>= 3.11.0)
* ExtSelenium (>= 1.1.3)
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
	 highlightTimeInSeconds = "0.05"
	 cachedObjectRepository = "COR.txt"/>
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
    public string CachedObjectRepository => "COR.txt";
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
* Version **1.6.4** released on 29/11/2019

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


# Basic Usage
## Setup to use ChromeDriver on Windows 10
* Download the latest stable chromedriver.exe (32 bit for Windows) version which supports your Chrome browser from https://chromedriver.chromium.org/downloads and save it to a local folder
* Config Path environment variabe for Selenium to find chromedriver.exe
  * Go to Control Panel > System > Advanced system settings > Environment Variables...> System variables > Path
  * Edit and add a new path item pointing to the folder containing chromedriver.exe file 
* Write a simple unit test using Okapi to test
  * ````IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");````
  
## Search by anchors syntax
1. By anchor
* Anchor - a known web element
* Search - web element you need to locate
* Parts - Anchor or Search are made of 2 parts - a tag/css selector; and a text/attribute value. 
	* tag/css selector format: i.e. ````<div>````, ````<li>div>div>````
	* text/attribute value format: i.e. `````How are you?`````
	* One part or two parts can be provided and which part stays first does not matter
* Sample 
	* ````"anchor <label> `How are you?` search <button>"````
	* ````"anchor `How are you?` <label> search <button>"````
2. By 2 anchors
* Need another information: Parent Anchor or Parent for short
* Sample
	* ````"parent `Do you own a car?` anchor <label> `Yes` search <span>"````
	
3. Special case
* Anchor and Search are one
* Sample
	* ````"search <input> `First name`"````
	* ````"<input> `First name`"````
	* ````"`First name`"````
	* ````"First name"````
	
When smart search is turned on (in app.config; recommend to turn it on all the time), text/attribute values are not case-sensitive. Providing part of the text/attribute values is also OK.

4. Example
* A line of code to enter a text "John" to First name text box
	* ````"<input> `first name`".GetTestObject().SendKeys("John");````


# Advanced Usage
## Get text of a cell in a table
* Imagine there is a table on a web page with multiple columns and multiple rows. Under the column 'Student Info', each cell contains student id and student name. We want to get student name when we know student id.
* There are multiple ways to do that in Okapi. Below is code demonstrate one way to do that. 
	* ````ITestObject row = "anchor `{0}` search <tr>".GetTestObject("12345678"); //12345678 is student id````
	* ````int precedingRowCount = row.PrecedingSibling.ElementCount;```` --> get the number of rows above the row with student id above
	* ````string studentName = "anchor `Student Info` search <table>tr>".GetTestObject().FilterByScreenDistance(precedingRowCount)               .Child.NextSiblingAt(2).ChildAt(2, 0, 2).Text;````
	
	By default, ````"anchor `Student Info` search <table>tr>".GetTestObject()```` will get the closest row toward the column title 'Student Info' which is the first row in the table. We don't want that to happen. We want to get the row we wanted so we call FilterByScreenDistance(precedingRowCount) which gets row at at distance order 'precedingRowCount' from the column title.
	Now we are in the row, looking into the DOM a bit and seeing that to go to the student name element we have to call ````Child.NextSiblingAt(2).ChildAt(2, 0, 2)````. 
		
		
## Usage of Okapi lambda functions

### 1. Example 1: working with table
* Imagine there is city table on a web page of a tourism website, each row starting with a checkbox and then city name. You want to select multiple city names by sticking the checkboxes. If a city name has been already selected, you want to bypass clicking on the associated checkbox because doing that will de-select the city name, which is not what you want to do.

* Each checkbox is structured by a 'li' html tag and each city name is structured by a 'span' html tag. The 'li' tag has attribute 'class'. When a checkbox is selected, this attribute has a new value 'ui-checkbox-selected'. When it is not selected, this value is gone.

* With Okapi lambda functions you can write the code as below to be reusable and be driven by test data.

````
[Step]
public static void Select_city_names(params string[] cityNames)
{
    string cityNameCheckBox = "anchor <span> `{0}` search <li>";
    
    cityNameCheckBox.GetTestObject().ForEach(cityNames,
    (self, item) => self.SetAnchorDynamicContents(item)
    .OnTrue(x => !x.TryGetAttribute("class", 0.5).Contains("ui-checkbox-selected")).Click());
    
    TestReport.Report();
}
````


### 2. Example 2: working with a counter
* Imagine there is a counter on a web page. The counter includes a text box displaying an integer number, which can be negative, zero or positive integer number. There are an up arrow and a down arrow right next to the text box. The up arrow is on top of the down arrow. When users perform a click on the up arrow, the number in the text box increases by 1. Similarly, a click on a down arrow decreases that number by 1.

* The text box is structured by html tag 'input' and has a label 'My Counter' next to it.

* Each of the arrows has html structure as '//p-arrow/div/button/span'

* With Okapi lambda functions you can write the code as below to be reusable and be driven by test data.

````
[Step]
public static void Set_my_counter(int setCount)
{
    string counterTextBox = "anchor `My Counter` search <input>";
    string counterControlArrow = "anchor `My Counter` search <p-arrow>div>button>span>";
    
    string currentCountString = counterTextBox.Text ?? counterTextBox.Value;
    int currentCount = string.IsNullOrWhiteSpace(currentCountString) ? 0 : int.Parse(currentCountString);
    
    int numberOfClicksToPerform = setCount - currentCount;
    
    counterControlArrow.GetTestObject().Run(numberOfClicksToPerform > 0,
    self => self.For(numberOfClicksToPerform, x => x.Click(false)),
    self => self.OnTrue(numberOfClicksToPerform < 0).FilterByScreenDistance(1).For(Math.Abs(numberOfClicksToPerform), x => x.Click(false)));
		
    TestReport.Report();
}
````

* Explain:
	- If numberOfClicksToPerform > 0, For() will repeat the click by numberOfClicksToPerform times.
	- Click(false) will click without retries
	- OnTrue(numberOfClicksToPerform < 0) to make sure when numberOfClicksToPerform = 0, do nothing. This is optional.
	- FilterByScreenDistance(1). By default the physical distances from the top left of 'My Counter' label to the top left of each arrow will be calculated and the shortest will be considered. In this case the top arrow has shortest physical distance to that label (order 0).  To access to the down arrow, FilterByScreenDistance(1) will set to get the second shortest distance (order 1).
	- Math.Abs(numberOfClicksToPerform) to change from nagative number to positive number before passing to For() for repeating.
