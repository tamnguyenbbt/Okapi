# Okapi Get Started
**Okapi** is an advanced and easy-to-use Selenium-based **Web UI test automation library/framework**. **Okapi** was designed **not to be just another Web UI test automation library or Selenium-wrapper in the market**. It aims at radically changing the way you write and maintain Web UI test automation scripts to be fun, full of confidence and cost effective at top levels. It was designed and developed to be game changer in Web UI automation testing business. Okapi is powerful and open.

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
* https://www.nuget.org/packages/Okapi/1.8.9
* Install-Package Okapi -Version 1.8.9

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
* ExtSelenium (>= 1.1.4)
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
* Version **1.8.9** released on 15/01/2020

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
* To be a bit more advanched, you might want to set up Selenium grid (hub and nodes) configuration instead. Check out: https://www.guru99.com/introduction-to-selenium-grid.html 
  
## Search by anchors syntax
1. By anchor
	* Anchor - a known web element
	* Search - web element you need to locate
	* Parts - Anchor or Search are made of 2 parts - a tag/css selector; and a text/attribute value. 
		* tag/css selector format: i.e. ````<div>````, ````<li>div>div>````, or ````<li/div/div>````
		* text/attribute value format: i.e. `````How are you?````` (in between 2 backticks)
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
		
5. Other searches
	* By xpath 
		````
			"xpath `//div/input[text()='First Name']`".GetTestObject(); Or
			"//div/input[text()='First Name']".GetTestObject();
		````
	* By class name
		````
			"class `userName`".GetTestObject(); Or
			"class name `userName`".GetTestObject(); Or
			"classname `userName`".GetTestObject(); Or
			"Class `userName`".GetTestObject(); Or
			"userName".GetTestObject();
			....
		````
	* By link text
		````
			"linktext `Student name`".GetTestObject(); Or
			"link tExt `student name`.GetTestObject(); Or
			"link `student name`".GetTestObject();
			....
			````
	* By id:
		````
			"id `passwordInput`".GetTestObject(); Or
			"passwordInput".GetTestObject();
			....
		````
			
	* By other types: partial link text, css selector, etc.: similar syntax

## Continue with the browser session opened from the previous test execution
* Imagine your test case has to test a chain of web pages, say 5 pages. So far you have already automated for the first 4 pages and you are now working on scripting for the last page, page 5. While scripting page 5, you have to run the test from time to time to see if what you have scripted is correct. 

* With Selenium, it is very annoying that to check what happens on page 5 and you have to run the test from beginning which starts to interact with page 1, then moving to page 2, and so on. This is time wasting.

* Okapi allows you to run the test going through from page 1 to 4 then stop your test but not closing the browser. And while scripting page 5, you can always run the test to confirm what you have done on page 5 is correct. BUT you run on the previous opened browser which stays at page 4.

````
[Test]
public void Already_complete_works()
{
     DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
     .....// your code to interact with page 1 to 4 here
}

[Test]
public void Temporary_development()
{
     DriverPool.Instance.CreateReusableDriverFromLastRun();
     .....// your code to interact with page 5 here
}
````

* How to use:
	*  Run Already_complete_works() test; then stop it; not closing the browser opened by it. The browser will land at page 4 at end of the this test.
	*  Start to code for page 5 in Temporary_development(). Confirm the script by running it from time to time. It will act on the previous opened browser instead of opening a new browser. You can repeat this cycle as many times as you want.
	*  When you are happy with the code in Temporary_development(), copy it and paste it at the end of Already_complete_works(). Then delete the Temporary_development() and rerun the whole Already_complete_works() to double check your complete script.

## Use Dynamic Contents
* Okapi introduces Dynamic Contents concept to promote code reusability. The main class in Okapi is TestObject class which implements ITestObject interface. Each TestObject object can represent any of multiple web elements on a web page. It can also represent multiple web elements on a web page.  

* For instance, the xpath "//span[label[text()='First Name']]/input" points to the First Name text box; and "//span[label[text()='Last Name']]/input" points to the Last Name text box. 

* You can always write code as below

````
ITestObject firstNameTextBox = "//span[label[text()='First Name']]/input".GetTestObject();
ITestObject lastNameTextBox = "//span[label[text()='Last Name']]/input".GetTestObject();
firstNameTextBox.SendKeys("John");
lastNameTextBox.SendKeys("Doe");
````

Or by id

````
ITestObject firstNameTextBox = "id `firstNameId`".GetTestObject();
ITestObject lastNameTextBox = "id `lastNameId`".GetTestObject();
firstNameTextBox.SendKeys("John");
lastNameTextBox.SendKeys("Doe");
````

* However, these 2 xpaths are very similar, so we can do a bit better with Okapi dynamic contents. TestObject will switch the context based on the dynamic content values to locate the expected web element for you.

````
ITestObject genericTextBox = "//span[label[text()='{0}']]/input".GetTestObject(); //{0} is a single dynamic content
genericTextBox.SetDynamicContents("First Name").SendKeys("John");
genericTextBox.SetDynamicContents("Last Name").SendKeys("Doe");
````

or by id

````
ITestObject genericTextBox = "id `{0}`".GetTestObject();
genericTextBox.SetDynamicContents("firstNameId").SendKeys("John");
genericTextBox.SetDynamicContents("lastNameId").SendKeys("Doe");
````

* With Okapi search by anchors, there can be dynamic contents in parent anchor, in anchor, and/or in search parts. Therefore, Okapi has the following methods for search by anchors:
	* SetAnchorDynamicContents(params string[] dynamicContents)
	* SetParentAnchorDynamicContents(params string[] dynamicContents)
	* SetSearchElementDynamicContents(params string[] dynamicContents)
	
````
"anchor <h2> `{0}` search <span> `Add Student`".GetTestObject().SetAnchorDynamicContents("Create Student Profile").Click();
````

* In the above example, there is only dynamic contents for anchor. So you can use SetDynamicContents() instead. Okapi is smart enough to set it for anchor. 

* When there are dynamic contents for more than one parts (i.e. for both anchor and search, or parent and anchor, etc.), SetDynamicContents() will always set for anchor.

````
"anchor <h2> `{0}` search <span> `{0}`".GetTestObject().SetDynamicContents("Create Student Profile").SetSearchElementDynamicContents("Add Student").Click();
````

* In the above example, there is dynamic contents for only one part. So you can set dynamic contents within GetTestObject() as well to be short.

````
"anchor <h2> `{0}` search <span> `Add Student`".GetTestObject("Create Student Profile").Click();
````

* When there are more than one dynamic contents within, i.e. an xpath or a part of search by anchors locating string, the format starts from 0, `{0}`, `{1}` and so on.

````
"anchor <h2> `{0} {1}` search <span> `Add Student`".GetTestObject("Create", "Student Profile").Click();
````


## Use locating string

* There are traditional ways to locate a web element by a locating string within Okapi. But the easier way is as the example below

````
"<button> `Cancel`".GetTestObject().Click();
````

* Okapi is smart in a way that it predicts what you are trying to tell it. For instance, in html you have 

````
<div> 
	<label id = 'ui-label-unique-id'>First Name</label>
	<input class="ui-textbox-unique ui-generic" id='firstNameId'>
</div>
````

it will do the same task for all these below lines:

````
"div[label[text='First Name']]/input".GetTestObject().SendKeys("John");
"xpath `div[label[text='First Name']]/input`".GetTestObject().SendKeys("John");
"id `firstNameId`".GetTestObject().SendKeys("John");
"`firstNameId`".GetTestObject().SendKeys("John");
"firstNameId".GetTestObject().SendKeys("John");
"classname `ui-textbox-unique`".GetTestObject().SendKeys("John");
"class `ui-textbox-unique`".GetTestObject().SendKeys("John");
"`ui-textbox-unique`".GetTestObject().SendKeys("John");
"ui-textbox-unique".GetTestObject().SendKeys("John");
"anchor `ui-label-unique-id` search <input>".GetTestObject().SendKeys("John");
````

## Use SetElementIndex()
* In general, if a TestObject based on a locator returns more than one web elements, SetElementIndex() will narrow down to the web element with the set index. Indexes starts from 0. And when not set, index 0 is used by default. When one web element is found, index 0 is always used even if you try to set index more than 0.

* Similarly, for example, if 2 elements found, they will be indexed as 0 and 1. If you try to set index as 2 or higher, it will be brought down automatically to 1.

* A common usage of SetElementIndex() is when you have a dropdown, a list box or a menu with multiple items. You can use SetDynamicContents() as discussed above or SetElementIndex().

* Example:
 	* There is a list box. Each of its items can be located via the xpath "//p-listboxitem/li/span[x]" where x = 0, 1, 2,... where 0 gets the first item, 1 gets the second and so on.
	* In Okapi you can do the following to click the second item, all producing the same outcome
	````
	"//p-listboxitem/li/span".GetTestObject().SetElementIndex(1).Click(); //using xpath
	"search <p-listboxitem/li/span>".GetTestObject().SetElementIndex(1).Click(); //using anchor
	"search <p-listboxitem>li>span>".GetTestObject().SetElementIndex(1).Click(); //using anchor
	"<p-listboxitem>li>span>".GetTestObject().SetElementIndex(1).Click(); //using anchor
	"<p-listboxitem/li/span>".GetTestObject().SetElementIndex(1).Click(); //using anchor
	"<p-listboxitem/li/span[1]>".GetTestObject().Click(); //using embedded index at the end of the html tag chain
	"<p-listboxitem>li>span[1]>".GetTestObject().Click(); //using embedded index at the end of the html tag chain
	"search <p-listboxitem>li>span[1]>".GetTestObject().SetElementIndex(1).Click(); //using embedded index at the end of the html tag chain
	"search <p-listboxitem/li/span[1]>".GetTestObject().SetElementIndex(1).Click(); //using embedded index at the end of the html tag chain
	````
	
## Embedded element index
* Element index can set via SetElementIndex() or via embedded element index for search by anchor or search by two anchors
* Embedded element index is the integer number between a opening square bracket and a closing square bracket at the end of search html tag/css selector

Example:
````
	"anchor <thead>tr>th> `Name` search <tbody>tr>td[1]>".GetTestObject();
	"anchor <thead>tr>th> `Name` search <tbody/tr/td[1]>".GetTestObject();
	"anchor <thead>tr>th> `Name` search <td[1]>".GetTestObject();
````

Of the found web elements, index 0 gets the first element; index 1 gets the second element, and so on.
	
## Use Info class
* To check if the details of the web elements pointed to by a TestObject, Info class is helful. It can be used to help you make decision on what element index to be passed to SetElementIndex().	

* Example:
````
Info info = "<p-listboxitem/li/span>".GetTestObject().Info;
Info info = "<p-listboxitem/li/span>".GetTestObject().QuickInfo; //a less information but less time to calculate
````

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Info.png)


## Use FilterByScreenDistance()
* Okapi's search by anchors core algorithm is sophisticated but the basic for most of the common cases is:
	* It gets web elements having the shortest Document Object Model (DOM) from the anchor
	* Then it tries to filter out the ones having the larger loops in DOM 
	* Then it picks the ones with the shortest physical distance on screen. And these are the ones returned to your tests by Okapi.
	
* There are cases you don't want just to get/perform action on the elements with the shortest physical distance on screen. **FilterByScreenDistance(params int[] distanceOrders)** help you to control in this case. Order 0 is for the shortest distance, order 1 is for the second shortest distance, and so on.

## Control search by anchors' screen distance
* By default, Okapi returns the web element with the shortest physical distance (screen distance) from the anchor when you perform search by anchors.

* For instance, after applying shortest DOM distance filter, a search returns 10 possible web elements. Okapi then applies shortest screen distance filter on the result and narrows down to 2 web elements which have the same shortest screen distances.

* Users are allowed to ask Okapi not applying shortest screen distance filter by calling method **NoFilterByScreenDistance()**

````
	ITestObject firstNameTestObject = "anchor <thead>tr>th> `First Name` search <tbody>tr>td>".GetTestObject("First Name");
	int count = firstNameTestObject.GetTestObject().NoFilterByScreenDistance().TryGetElementCount();
````

This setting has the scope of the test object. In the above example, after calling **NoFilterByScreenDistance()**, there is no screen distance filter applied on firstNameTestObject. If you want to re-apply this shortest screen distance filter, you can call **DefaultFilterByScreenDistance()** on the firstNameTestObject.

* By default, screen distances are measured from TOP LEFT of the anchor element to TOP LEFT of the search elements. Users can change the reference point of the anchor element and/or that of the search elements by calling **FilterByShortestScreenDistance(ReferenceType anchorReferenceType, ReferenceType searchElementReferenceType)**

* **FilterByScreenDistance(params int[] distanceOrders)** has been explained in the previous usage. **FilterByScreenDistance(ReferenceType anchorReferenceType, ReferenceType searchElementReferenceType, params int[] distanceOrders)** can be used to control both the screen distance orders and reference points as well.

## Memory Cache

* Okapi TestObject class has a built-in memory caching mechanism to boost performance. It manages the cache automatically in a smart way for most of the case.

* When you use the same variable to store a TestObject object for multiple actions in series then you need to clear the cache manually when you know that DOM has changed since the last action.

* Example: 
````
ITestObject saveButton = "Save".GetTestObject().Click();
....
// do something so that the web page content is changed
....
string disabledAttributeValue = saveButton.ClearCache().GetAttribute("disabled"); //if you don't clear the cache here, saveButton will give you the old information based on the old content of the web page.
````

* However, if you create a new TestObject instance for every action, nothing is cached

````
"Save".GetTestObject().Click();
....
// do something so that the web page content is changed
....
string disabledAttributeValue = "Save".GetTestObject().GetAttribute("disabled");
````

* Another situation where you need to manually clear cache is as in the below example:

````
ITestObject studentInfo = "anchor `Student Name` search <span>".GetTestObject();
ITestObject checkbox = studentInfo.Parent.PrecedingSibling;
checkbox.Click(); //after this, DOM changes and if want to use checkbox for another action, have to clear cache
checkbox.RetryToClearRelationCacheUntil(...) //there will be an example in Advanced usage for this case

````
	

## File Cache
* Okapi's search by anchors requires a lot of calculations and consumes quite a lot of memory and CPU so for some circumstances such as a web page is large, it can be slow. 

* When you see that the search by anchors is too slow, the best is to improve your locator to help Okapi's search by anchors a bit or just use traditional locating methods such as xpath.

* Example:
````
"anchor `Student Name` search <span>" //forces Okapi to work more; imagine there are 1000 span tags in the page, Okapi has to visit them all
"anchor `Student Name` search <li>div>span>" //Okapi loves this because the locator gives Okapi more information; Okapi has to visit only where there are "//li/div/span" 
"anchor <label> `Student Name` search <li>div>span>" //Okapi loves this even more
````

* If your tests rely heavily on search by anchors then, for some particular large web pages, the execution can be slow. File cache can be of help.

* To turn on globally, in **app.config** add **cachedObjectRepository ="your file path"**

* When you run your tests for the first times, this file is updated with the outcomes calculated by search by anchors. For the future test executions, Okapi will look up this file for cached information. If not found or the found information for an action becomes obsolete due to the web page having changed so making the action failed, it will automatically do search by anchors calculation, delete the existing information from the file and add the new outcome to the file. If you want to have a fresh cache again, you can delete the file.

* Users can clear this cache for a test object by calling **ClearObjectRepositoryCache()**

* When you work with, say, an html table where you add a new row everytime a test script is run; the added row being based on dynamic test data (i.e. a random date or number); and the locator for this row containing this dynamic data, please be mindful about it. If you cache this test object locator, next executions will get that cached locator which contains the old dynamic data. But you have new test data for every execution. Then the cached xpath does not serve up well. In this situation, you need to force search by anchors engine to delete that cached item and recalculate the locator by calling **ClearObjectRepositoryCache()**

* Example: a table
	````
		ITestObject studentRow = "Anchor <thead>tr>th> `Order` search `{0}`".GetTestObject("1").ClearObjectRepositoryCache();
            	string firstName = studentRow.NextSiblingAt(0).Value; //input box
            	string lastName = studentRow.NextSiblingAt(1).Value; //input box
            	string dobString = studentRow.NextSiblingAt(2).Text; //label
		DateTime dob = DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
	````


## Work with drivers/browsers

* With Okapi, drivers are managed in the back-ground and named ManagedDriver which implements IManagedDriver interface. Users do not need to refer to a driver for every action like in Selenium, making it easier for users to focus on the business rules of the test scenario, cutting over-heads in code. A ManagedDriver object is one-one mapped to a browser.

* Managed drivers are created, stored and deleted in a pool. The only times users have to deal with a driver is when launching a page and when quiting a driver.

````
  DriverPool.Instance.ActiveDriver.LaunchPage("http://www.google.com");
````

or 

````
  IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage(testData.Url);
````

````
	DriverPool.Instance.QuitAllDrivers();
	DriverPool.Instance.QuitActiveDriver();
	DriverPool.Instance.Quit(driver);
	DriverPool.Instance.QuitAllExceptActiveDriver();
````

* When a test script needs to deal with more than one browsers, you can create new drivers in your test scripts with **CreateDriver(bool setAsActive = true)** method

````
	IManagedDriver newDriver = DriverPool.Instance.CreateDriver(); //by default the newly created driver will be set as active, pushing the current one into inactive queue
````
	
* To set a driver as active

````
DriverPool.Instance.ActiveDriver = driver as ManagedDriver;
````

* After a driver is set active, all the actions will be performed on that driver.

* With Selenium, everytime a test script is executed, it has to create a new driver. Unlike Selenium, Okapi allows users to reuse an already opened browser from the last run, in the same execution or not in the same execution session.

````
DriverPool.Instance.CreateReusableDriverFromLastRun();
````


## FileDB
* Okapi comes with a file database utility called FileDB for users to save and retrieve test data to share between test scripts accross multiple running sessions.

* It allows user to insert, retrieve, update and delete payloads in the form of C# classes, so data is ready to update and use without any transformation.

* Define:
````
using Okapi.Utils;
using Okapi.Utils.DB;

....
 string dataBasePath = $"{Util.CurrentProjectDirectory}{Util.DirectorySeparatorChar}Database{Util.DirectorySeparatorChar}MyFileDB.db";
 FileDB fileDB = new FileDB(dataBasePath); 
````

* Insert
````
Student student = new Student();
long recordId = fileDB.Insert(student, "New Student", "Year 10");
````

* Retrieval 
````
DbObject<Student> studentRecord = fileDB.FindById<Student>(recordId);
Student payload = studentRecord.Payload;
payload.Name = "New Name";

studentRecord = fileDB.GetLastInsertedRecordInTheSameExecutionThread<Student>();
studentRecord = fileDB.GetLastInsertedRecordByStatus<Student>(FileDBSearchMethod.IgnoreCase, "New Student", "year 10);
````

* Update
````
bool success = fileDB.Update(recordId, payload, "Name Changed");
````

* Delete
````
success =fileDB.Delete<Student>(studentRecord.Id);
````


## Work with windows
* To be updated

## Work with iframes
* Okapi.Drivers.ManagedDriver class has methods and properties to deal ith iframes similar to the way Selenium deals with iframes.
	*   	SwitchToDefaultContent()
	*	SwitchToParentIFrame()
	*	SwitchToParentIFrame()
	*   	SwitchToIFrame(string name) //works only if the frame has a name
	*   	SwitchToIFrame(int index) //needs to know the hierarchy of frames to figure out relative index
	*       ActiveFrameName //property to get name, if any, of the active frame

* Properties **InnerIFrames** returns a list of **Frame** objects representing the iframes inside the current html document. Each frame object includes a unique Id (GUID), a frame index (similar to Selenium; users have to switch one by one from top down), attributes within a frame tag, content of a html document which contains this frame, and a list of html documents contained by this frame.

* Okapi's prefered way of managing iframes is to use **Frame** objects. After having the list of **Frame** objects (children, children of children, and so on) via **InnerIFrames** property, users can jump straight to any frame using **JumpToIFrame(Guid id)**.

* When DOM has been changed since the last action, **RefreshInnerIFrames()** returns a list of latest **Frame** objects based on up-to-date DOM.

## Work with TestExecutor
* TestExecutor class has the methods to help you perform complex calculations in fewer lines of code
* Below are some examples

````
	TestExecutor.Run(HasStudents(), () =>
        {
             SelectAllStudents();
        });
````

````
	TestExecutor.Skip(false, () => DriverPool.Instance.QuitActiveDriver()); //change to true to skip the execution of this line
````

````
	List<Student> students = studentRecords.Payload.Students;
	
	TestExecutor.Loop(students, x =>
        {
             TestReport.IsTrue(x.FirstName.GetTestObject().IsDisplayed(5));
        });
````

````
	int studentCount = students.Count;
	
	TestExecutor.Loop(students, (i, x) =>
        {
             new FileDB(sharedDatabasePath).Insert(x, $"Student {i + 1} of {studentCount}");
        });
````

* Please use IDE's intelliSense to find out more methods offered by TestExecutor

## AppConfig class
* Okapi.Configs.AppConfig.TargetTestEnvironment gets the target environment name set within app.config file


## Util class
* Okaki.Utils.Util class provides utility properties and methods to be used in test scripts.


## Test data interfaces
* Okapi offers 2 interfaces under namespace **Okapi.Runners** ready for creating test data in the form of DTOs (Data transfer objects)
	* ````INameDataSet<T> and IDataSet<T>````
	
* When implementing **INameDataSet**, users have to implement the method ````IDictionary<string, T> Get()```` where the string is data item name, and T is data class

* When implementing **IDataSet**, users have to implement the method ````IList<T> Get()````

* To add test data, Okapi extends ````IDictionary<string, T>```` with the method **Append**. This method can be used with Okapi class **Okapi.Runners.NamedDataItem** to add data items

* Example:

````
	public class AccountDTO
	{
		public string Username {get; set;}
		public string Password {get; set;}
	}
	
	public class AccountDataSet : INamedDataSet<AccountDTO>
    	{
		public IDictionary<string, AccountDTO> Get()
		{
		    var data = new Dictionary<string, AccountDTO>();

		    data.Append(new NamedDataItem<AccountDTO>
		    {
			Name = "Default Account",
			Data = new AccountDTO
			{
			   Username = "test",
			   Password = "test"
			}
		    });
		    
		    return data;
		}
	}
	
	AccountDTO testData = new AccountDataSet().Get()["Default Account"];
````

* Best test data usage practices
	* If you write test scripts using Okapi, C# and any IDE such as Visual Studio, the best form of test data is DTO classes.
	* Some try to use CSV, Excel, Database to store test data. This is overkill and adds uneccessary overheads because you need to convert back and forth from one DTO classes to one of the above-mentioned forms. These forms are useful only when you have a tool, not an API, such as you write a desktop client application which uses Okapi as the engine.
	* Always write reusable test steps which are independent from the web page business rules. Business rules should be embedded in test data and be injected by test data into reusable test steps (data-driven test).


## Common TestObject Method References
* Click -> clicks on a web element. Checks if the web element is ready before clicking. Retries if the click action does not take effect
* DoubleClick
* SendKeys -> inputs text into a text box or a text area
* Clear -> clears a text box or a text area
* ClearAllWithBackspaceKey -> clears a text box or a text area; should be used when Clear does not work for some special web front-end implementations
* ClearWithBackspaceKey -> clears part of a text box or a text area
* ClickAndHold -> clicks on a web element and holds (left mouse down and hold)
* ClickHoldAndRelease -> clicks on a web element (left mouse down), holds left mouse down, then releases (left mouse up) after a set amount of time
* ReleaseMouseClick -> releases mouse click (left mouse up) on the web element represented by TestObject or on the current mouse pointer
* DragAndDrop -> drags and drops a web element to a specified location or to another specified web element
* VerticalDragAndDrop -> drags and drops a web element to a specified location vertically
* HorizontalDragAndDrop -> drags and drops a web element to a specified location horizontally
* MoveToElement -> sets focus on a web element represented by the TestObject with set element index
* MoveMousePointer -> moves the mouse pointer to a specified location from the web element represented by TestObject
* Highlight -> highlights the web element represented by the TestObject
* ScrollIntoView -> scrolls web page so that the web element represented by TestObject goes into view
* WaitForAjaxCall -> waits for an ajax call to complete when you know the Url of that Ajax call
* WaitForAllAjaxCalls -> waits for all ajax calls to complete
* WaitUntilPageReady -> detects and waits for some common Web UI techniques underneath to finish their works and ajax calls completed 
* WaitUntilDomToBeStable -> polls to see if the DOM complete loading (i.e. predicts if no more web element is added to DOM)
* WaitUntilEnabled -> waits until the web element represented by TestObject being unabled. Relies on Selenium so this one does not work for all cases
* WaitUntilClickable -> waits until the web element represented by TestObject being clickable. Relies on Selenium so this one does not work for all cases
* WaitUntilVisible -> waits until the web element represented by TestObject being enabled and displayed. Relies on Selenium so this one does not work for all cases


# Advanced Usage
## Get text of a cell in a table
* Imagine there is a table on a web page with multiple columns and multiple rows. Under the column 'Student Info', each cell contains student id and student name. We want to get student name when we know student id.

* There are multiple ways to do that in Okapi. Below is code demonstrate one way to do that. 
	* ````ITestObject row = "anchor `{0}` search <tr>".GetTestObject("12345678"); //12345678 is student id````
	* ````int precedingRowCount = row.PrecedingSibling.ElementCount;```` --> get the number of rows above the row with student id above
	* ````string studentName = "anchor `Student Info` search <table>tr>".GetTestObject().FilterByScreenDistance(precedingRowCount)               .Child.NextSiblingAt(2).ChildAt(5).Text;````
	
	By default, ````"anchor `Student Info` search <table>tr>".GetTestObject()```` will get the closest row toward the column title 'Student Info' which is the first row in the table. We don't want that to happen. We want to get the row we wanted so we call FilterByScreenDistance(precedingRowCount) which gets row at at distance order 'precedingRowCount' from the column title.
	Now we are in the row, looking into the DOM a bit and seeing that to go to the student name element we have to call ````Child.NextSiblingAt(2).ChildAt(5)````. 
	
## Working with repeated UI blocks
* Imagine there is a web page with multiple UI blocks. Each block has a city name and a url link named 'See details' to open up the details about the city.

* We want to check if the city names and the links are correct and also they are arranged properly on the page. With Okapi, it is quite easy to do with very few number of lines of code.

````
"<h2> `{0}`".GetTestObject().ForEach(new List<string> { "London", "Canberra", "Sydney", "Paris", "New York" },
                (self, item) =>
                {
                    bool cityNameFound = self.SetDynamicContents(item).SingleFound; // check if the city name is found
                    Point selfLocation = self.Location; //get the city name's location on the web page 

                    ITestObject seeDetailUrl = self.Parent.NextSibling.ChildAt(5); //get 'See details' url element
                    Point seeDetailUrlLocation = seeDetailUrl.Location;                    
                    Size seeDetailUrlSize = seeDetailUrl.Size;
		    
		    //Assertions
                    TestReport.IsTrue(cityNameFound);
                    TestReport.AreEqual("See Details", seeDetailUrl.Text);
                    TestReport.AreEqual(500, selfLocation.X);
                    TestReport.AreEqual(500, seeDetailUrlLocation.X);
                    TestReport.AreEqual(50, seeDetailUrlLocation.Y - selfLocation.Y);
                    TestReport.AreEqual(100, seeDetailUrlSize.Width);
                    TestReport.AreEqual(20, seeDetailUrlSize.Height);
                });
````
		
## Usage of Okapi lambda functions

### 1. Example 1: working with multiple text boxes having similar characteristics
* Imagine there is a web page which has multiple text boxes with similar html structures and we need to fill up these text boxes with test data. When a piece of data for a text box is null, does nothing for that text box. Each text box has a label next to it.

* We need to write reusable code with test data driven capability so we can use this block of code, a method, to test the page with both possitive test cases and negative test cases, driven by test data.

* With Okapi lambda functions you can write the code as below:

````
[Step]
public static void Fill_up_client_profile_information(IList<string> labels, IList<string> testData)
{
    string genericTextBox  = "parent <h2> `Create client profile` anchor <label> `{0}` search <input>";
    
    genericTextBox
    .GetTestObject()
    .For(labels.Count, 
    (self, index) => self.OnNotNull(testData[index]).SetAnchorDynamicContents(labels[index]).Clear().SendKeys(testData[index]));
    
    TestReport.Report();
}
````

* For instance, when we want to fill up First Name, Last Name, but not Date of Birth, we can call:

````
IList<string> labels = new List<string> { "First Name", "Last Name", "Date of Birth" };
IList<string> testData = new List<string> { "John", "Doe", null };
FFill_up_client_profile_information(labels, testData);	
````

### 2. Example 2: working with table
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


### 3. Example 3: working with a counter
* Imagine there is a counter on a web page. The counter includes a text box displaying an integer number, which can be negative, zero or positive integer number. There are an up arrow and a down arrow right next to the text box. The up arrow is on top of the down arrow. When users perform a click on the up arrow, the number in the text box increases by 1. Similarly, a click on a down arrow decreases that number by 1.

* The text box is structured by html tag 'input' and has a label 'My Counter' next to it.

* Each of the arrows has html structure as '//p-arrow/div/button/span'

* With Okapi lambda functions you can write the code as below to be reusable and be driven by test data.

````
[Step]
public static void Set_my_counter(int setCount)
{
    ITestObject counterTextBox = "anchor `My Counter` search <input>".GetTestObject();
    ITestObject counterControlArrow = "anchor `My Counter` search <p-arrow>div>button>span>".GetTestObject();
    
    string currentCountString = counterTextBox.Text ?? counterTextBox.Value;
    int currentCount = string.IsNullOrWhiteSpace(currentCountString) ? 0 : int.Parse(currentCountString);
    
    int numberOfClicksToPerform = setCount - currentCount;
    
    counterControlArrow.Run(numberOfClicksToPerform > 0,
    self => self.For(numberOfClicksToPerform, x => x.Click(false)),
    self => self.OnTrue(numberOfClicksToPerform < 0).FilterByScreenDistance(1).For(Math.Abs(numberOfClicksToPerform), x => x.Click(false)));
		
    TestReport.Report();
}
````

* Explain:
	- If numberOfClicksToPerform > 0, For() will repeat the click by numberOfClicksToPerform times.
	- Click(false) will click without retries
	- OnTrue(numberOfClicksToPerform < 0) to make sure when numberOfClicksToPerform = 0, do nothing. This is optional.
	- FilterByScreenDistance(1). By default the physical distances from the top left of 'My Counter' label to the top left of each arrow will be calculated and the shortest will be considered. In this case the up arrow has shortest physical distance to that label (order 0).  To access to the down arrow, FilterByScreenDistance(1) will set to get the second shortest distance (order 1).
	- Math.Abs(numberOfClicksToPerform) to change from nagative number to positive number before passing to For() for repeating.
	
	
### 4. Example 4: working with a combo box
* Imagine there is city combo box where each list item contains a city label and a checkbox. Users are allowed to select multiple cities by ticking on multiple checkboxes. The cities selected will be displayed on the top input area of the combo box horizontally.

* We want to select some cities and check if they are displayed correctly on the input area.

````
List<string> visitingCities = new List<string> { "Lodon", "Philadelphia", "Paris" };

ITestObject dropdownSelector = "anchor `Visiting Cities` search <multiselect/div/div/span>".GetTestObject();   
    
ITestObject checkbox = "parent `Visiting Cities` anchor `{0}` <multiselectitem>li>span> search <multiselectitem>li>div>div>".GetTestObject();

ITestObject displayedCityNames = "anchor `Visiting Cities` search <multiselect/div/div/div/div/div>".GetTestObject();
    
dropdownSelector.Click();
    
checkbox.ForEach(visitingCities, (self, item) => self.SetAnchorDynamicContents(item).RetryToClickUntilAttributeValueContains("class", "state-active"));    
// if ticked, 'state-active' will be added to the class attribute value 
            
displayedCityNames.FilterByScreenDistance(0, 1, 2).ForEach(visitingCities, (self, item, index) =>
{
      string displayedCityName = self.SetElementIndex(index).Text;
      TestReport.AreEqual(item, displayedCityName);
});  
// The selected cities will be displayed as 'London Philadelphia Paris'  
// order 0 is the distance from the label 'Visiting Cities' to the displayed text 'London'
// order 1 is the distance from the label 'Visiting Cities' to the displayed text 'Philadelphia'
// order 2 is the distance from the label 'Visiting Cities' to the displayed text 'Paris'
````

### 5. Example 5: working with paging
* Imagine there is a web page listing 20 items from top down. At the bottom of the web page, there are page indicator, a next button and a previous button. Clicking on the next button displays the next 20 items.

* We want to click on the next button multiple times until reaching the last items. On each page, perform some actions.

````
[Step]
public static void VisitAllPagesAndPerform(Action action)
{
    "<a>div> `next-navigate-icon`".GetTestObject().WhileDo(self =>
    {
        action();
        bool found = self.OneFound(5);
        bool enabled = !"<span>a> `Next Page`".GetTestObject().TryGetAttribute("class").Contains("disabled");
        return found && enabled;
     },
     self >
     {
        self.Click();
        "<div>spinner>progressbar>".GetTestObject().WaitUntilGone();
     });
}
````

	
## Check if a checkbox becomes a saved symbol after ticking it
* There are multiple ways to do this in Okapi. Below is an example showing one way to do it.
* Imagine there is a checkbox next to a city name label on a web page. When we tick the checkbox, it becomes a saved symbol. We need to check if the checkbox becomes a saved symbol after we click on it. 

````
ITestObject cityNameLabel = "London".GetTestObject();

ITestObject cityNameCheckBox = cityNameLabel.Parent.PrecedingSibling.Child; //inspect the web page DOM for this; this one pointing to a tooltip and a checkbox.

checkbox.SetElementIndex(1).Click(); //set element index as 1 so pointing to the checkbox instead of the tooltip then click it

//now we don't want to create a new TestObject object with a new locator. We want to use the same checkbox variable.
KeyValuePair<ITestObject, bool> result = checkbox.RetryToClearRelationCacheUntil(obj
                => TestExecutor.Any(obj, "saved", (index, element) => { return element.SetElementIndex(index).TryGetText(2); }));
		
TestReport.IsTrue(result.Value);

````

* Other ways, which are a bit shorter: 
````
KeyValuePair<ITestObject, bool> result = checkbox.RetryToClearRelationCacheUntil(obj
                => TestExecutor.Any(obj, "lock", element => { return element.TryGetText(2); }));
````

````
KeyValuePair<ITestObject, bool> result = checkbox.RetryToClearRelationCacheUntil(obj
                => { return obj.TryGetText(2) == "lock"; });
````

* Explain:
	* 'obj' and 'element' are both the checkbox
	* 'index' is 1
	* TestExecutor.Any(...) checks if the element's text becomes 'saved' and returns a boolean value - true/false
	* After 'checkbox.SetElementIndex(1).Click()', the DOM will be updated and keeps on changing in a short time. So RetryToClearRelationCacheUntil() keeps on clearing the cache for cityNameLabel.Parent.PrecedingSibling.Child relationship until the condition returning by TestExecutor.Any(...) becomes true.
	* The outcome of RetryToClearRelationCacheUntil() is a key-value pair of checkbox TestObject itself and the boolean value of this TestExecutor.Any(...) check.

## Use strict mode
* ITestObject has property **bool Strict { get; }** for users to check the current running mode and method **ITestObject StrictMode(bool value)** to turn strict mode on/off.

* Search by anchors performance is a bit better under unstrict mode than under strict mode; By default, strict mode is turned off. However, there are user cases where strict mode is needed.

* Let's see the example below to understand strict mode
	* Most of the time, if a web element on a web page does not exist in DOM, there is no html tag related to it so there is no XPath associated with it. But sometimes, UI developers may just remove the inner text, not the html tags in DOM.
	
	* For instance, in a web page, there is a 'First Name' input box associated with a validation label next to it. When users have not input anything in the input box and clicked Save button, the error message displays otherwise it does not display. The UI developers have decided not to remove the whole XPATH in DOM for that error message when there is no validation error; they have decided just to remove the inner text. So when there is an error, the XPath is **//label[text()='Student Details']/div/span/m-error[text()='First name cannot be empty']"**. And when there is no error the XPath is **//label[text()='Student Details']/div/span/m-error**. 
	
	* To search this web element by anchor when there is an error, we use: 
	
	````
		"anchor <label> `Student Details` search <m-error> `First name cannot be empty`".GetTestObject();
	````
	
	* Under unstrict mode, when the search engine finds ONE web element, it associates that web element with **//label[text()='Student Details']/div/span/m-error** to do less calculation. This is enough in most of the cases. And this XPath is saved in File Cache. However, in this example, **//label[text()='Student Details']/div/span/m-error** exists in DOM when there is no validation error. In the next executions, when you try to find the web element associated with the validation error message, **//label[text()='Student Details']/div/span/m-error** is retrieved from File Cache. If you assert to see if the validation error not displayed, the result can be wrong. 
	
	* So for this case or similar cases, you may want to set strict mode and Okapi search by anchors engine will return the full XPath even when ONE web element is found; in the above example, **//label[text()='Student Details']/div/span/m-error[text()='First name cannot be empty']"** instead of **//label[text()='Student Details']/div/span/m-error**.
