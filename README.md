# Okapi Get Started

## Why Okapi?

* We, human beings, by nature, are better in using intuition than conscious reasoning when dealing with something simple and repetitive.

* Okapi changes the way we write Web UI test automation towards intuition with **What You See Is What You Get** test script development style.

## What is Okapi?

**Okapi** is an advanced and easy-to-use, open and powerful **Web UI test automation API** for **.Net/C#** users. **Okapi** has been designed **not to be just another Web UI test automation library in the market**. It aims at radically changing the way you write and maintain Web UI test automation scripts to be fun, full of confidence and cost effective. It has been designed and developed to be game changer in Web UI automation testing business.

* Okapi addresses all possible practical test automation difficulties such as timing and stale web element issues, letting users focus on business rules of the web applications under test while scripting (in C#). Okapi helps build advanced, reliable and easy-to-maintain Web UI test scripts. Okapi cuts significant development time and effort as well as maintenance time and effort by allowing writing very less code to achieve robust test scripts.

* First to introduce the advanced **Search Web Elements By Anchors** algorithms which are much simpler and intuitive to use and require much less script maintenance than traditional methods (id, name, tag name, class, css, xpath, etc.). Okapi still supports traditional search methods.

* Advanced **Smart Search** by anchors (turned on/off in config)

* **Reusable web driver from another execution session** feature for better user-experience while developing test scripts

* Advanced **Web page xpath recording mechanism**

* **Dynamic Contents** concept for better code reusable and easy to use

* Supports data-driven out of the box

* Supports user-customised test report and logging, coming with two default report packages - text and html

* Supports user-customised test project configuration for quick setup of test project

* Advanced and reliable built-in web element interaction library for developing reliable test scripts with minimal lines of code

* Okapi is ready to use, there being little need to build another wrapper around it.

* Comes under the form of NuGet package and supporting NuGet packages (report, logging, and common)

* Supports **ChromeDriver**, **FirefoxDriver**, **InternetExplorerDriver**, **EdgeDriver**, **SafariDriver**, **OperaDriver** and **Selenium RemoteWebDriver**

* Supports **.Net Framework 4.5, 4.6 and 4.7**

* Easy to integrate with any Unit test framework

* Ideal for setting up and running both locally and in any Continuous Integration environment

* Supports user-defined actions, to extend/add the web interactive actions where Okapi has not provided yet

* FileDB feature to save and share test data between tests and steps

* Support C# lambda for professional .Net/C# developers to use to build advanced scripts with fewer lines of code

* Drivers are hidden from users to make code simpler to be written

## NuGet
* https://www.nuget.org/packages/Okapi/2.1.4
* Install-Package Okapi -Version 2.1.4

## **What You See Is What You Get** Style Test Development - First Simple Test Script

**Facebook registration page**

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookReg.png)

**With Okapi, it is quick and easy to write test scripts.**

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FirstTest.png)

## A Real-Life Test Written Using Okapi

* Below is a real-life workable test using the advanced features of Okapi to maintain minimum lines of code. If it is hard for you to understand for now, please skip this session and read the rest of the document to understand more about Okapi.

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookRegistrationPage.png)

* Base on the web page, construct data template classes

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookRegistration_DataTemplates.png)

* Create test data set class based on data templates. The test data set contains the real test scenarios (business rules to be tested)

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookRegistration_TestData.png)

* Data-driven test step. The step does not contain real business rules. Test data contains business rules and drives the flow of the step. By going data-driven, the step does not need to be changed a lot later on. Most of the Okapi's built-in actions such as SendKeys() have built-in data-driven capability. That means when the input test data is null, they do nothing. By passing in different test data sets, different scenarios can be tested using the same step.

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookRegistration_DataDrivenStep.png)

* A real test with assertion. If assertion fails, test is stopped and reported as failed with error details. You can write dozens of the tests like this (happy path, negative, boundary, pairwise, etc.) by just appending different test data sets and use the same test step.
 
 ![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookRegistration_TestScript.png)
 
 * Outcome: You can see that we have not used a lot of brain power to find xpaths, css selectors, etc. for this test. By looking at the web page itself, we are able to write 90% of the test.
 
  ![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/FacebookRegistrationPageAssertion.png)

## Dependencies

### .NET Framework 4.5, 4.6 and 4.7
* DotNetSeleniumExtras.WaitHelpers (>= 3.11.0)
* ExtSelenium (>= 1.2.6)
* LiteDB (>= 4.1.4)
* Ninject (>= 3.3.4)
* Newtonsoft.Json (>= 12.0.3)
* Okapi.Common (>= 1.1.0)

## Non .Net Support

* Users of other Web UI tools or other programming languages who want to use Okapi's search-by-anchors algorithm can use **Okapi Web API service tool** at https://github.com/tamnguyenbbt/Okapi.Web.Api.Console

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/OkapiWebApiSample.png)

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/OkapiWebApiSampleTest.JPG)

## Set up a Test Project

* The code in this repo is for a sample test project based on NUnit and MSUnit and .Net Framework 4.5 and uses Okapi library.

* The easiest way to experience Okapi is to create a simple unit test project within Visual Studio Community  (https://visualstudio.microsoft.com/vs/community) then install the following NuGet packages and it is ready for you to write unit tests.

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/NuGet.png)

* **Packages**:
	* **Okapi**
	* **NUnit** is needed to write NUnit test cases
	* **NUnit3TestAdapter** is needed to run NUnit test cases within Visual Studio
	* **Okapi.Support.Report.Html** (optional) is needed when you want test reports to be constructed. Okapi sends out test report data when you turn this function on in configuration. Okapi.Support.Report.Html, being a presentation layer, collects those real-time data and builds the html reports. Code for this package is shared at https://github.com/tamnguyenbbt/Okapi.Support.Report.Html. You can base on this code to write your own flavour of Okapi report, locally, as web service, or for CI/CD environments such as Jenkins or TeamCity.
	* **Okapi.Support.Log.Text** (optional) is needed when you want logs are captured. Okapi sends out real-time logs when you turn this function on in configuration. Okapi.Support.Log.Text, being a presentation layer, collects those real-time data and writes out logs for you. Code for this package is shared at https://github.com/tamnguyenbbt/Okapi.Support.Log.Text. You can base on this code to write your own flavour of Okapi logger.
	* **Okapi.Support.Report.NUnit** (optional) provides **ToOkapiTestContext** method which converts NUnit Test Context to Okapi Test Context
		* In Okapi, each test case needs to be decorated with Okapi TestCase attribute and needs to end with TestReport.Report() call so that the test case activities get reported. Similarly, each test step needs to be decorated with Okapi Step attribute and needs to end with TestReport.Report() call so that the test step activities get reported. The advantage of this approach is that you can selectively choose what to report; and that the report mechanism is independent from any unit test library, third-party packages for NUnit to have better looks, or other specific libraries. Another advantage is if you want reports with very nice look, you can write your own presentation layer. I found the approach where introducing a new unit test library with better reporting capabilities and forcing users to use it just to have better reports is a bad idea.
		* With Okapi.Support.Report.NUnit you can call TestReport.Report at NUnit test tear down level instead
		
				
	````
	[Test]
        [TestCase]
        public void Test_with_report()
        {
            	DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            	int elementCount = "<span> `Next`".GetTestObject().ElementCount;
            	TestReport.IsTrue(elementCount == 1);
            	TestReport.Report();
        }		
	````
		
	Or
		
	````
	[TearDown]
        public void TestCleanup()
        {
            	TestReport.Report(TestContext.CurrentContext.ToOkapiTestContext());
            	DriverPool.Instance.QuitActiveDriver();
        }

        [Test]
        [TestCase]
        public void Test_with_report()
        {
            	DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            	int elementCount = "<span> `Next`".GetTestObject().ElementCount;
            	TestReport.IsTrue(elementCount == 1);
        }
	````
	

### Configuration (Optional)

* Okapi supports App.config, class configuration via dependency injection, and class configuration in code. Class configuration in code takes precedence over App.config configuration; and App.config configuration takes precedence over class configuration via dependency injection when more than one methods are used at the same time.

* If none of the methods mentioned above are used, Okapi will use the built-in default configuration (with Chrome driver as default driver).

#### Using App.config

Add an **App.config** file in your test project as below:

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
      <add targetTestEnvironment="Alpha"
	 active = "true"
	 driverFlavour = "ChromeDriver"
	 driverDirectory = ""
	 driverExecutableName = ""
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
      <add targetTestEnvironment="Beta"
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

* When driverDirectory and driverExecutableName are not set, Okapi looks into the Path environment variable for the path and searches for the default driver name in that path.

#### Using Class Configuration via Dependency Injection

Implement **ITestEnvironment** interface

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
    public bool SmartSearch => true;
    public string logPath => "Log.txt";
    public string reportDirectory => "Report";
    public bool HighlightOnSearch => true;
    public string CachedObjectRepository => "COR.txt";
    public double DriverTimeoutInSeconds => 30;
    public string DriverDirectory => "C:\Selenium";
    public string DriverExecutableName => "chromedriver.exe"
}
````

#### Using Class Configuration within Your Test Code

Create a new instance of class **Okapi.Configs.Config**

* Config for a driver

````
	    Config config = new Config()
            {
                DriverFlavour = Okapi.Enums.DriverFlavour.Edge,
                DriverTimeoutInSeconds = 15
            };

            IManagedDriver driver = DriverPool.Instance.CreateDriver(config).LaunchPage(data.Url);
````

* Config for all the drivers

````
            Config config = new Config()
            {
                DriverFlavour = Okapi.Enums.DriverFlavour.Chrome,
                DriverTimeoutInSeconds = 15
            };

            IManagedDriver driver = DriverPool.Instance.SetConfig(config).ActiveDriver.LaunchPage(data.Url);
````


### Override Selenium Driver Options (Optional)

When you want to control the browsers' behaviours rather than using the default behaviours provided by Okapi, 
you can implement **IDriverOptionsFactory** interface. For instance,

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
             chromeOptions.AddArguments("headless");
             return chromeOptions;
    }
}
````

Okapi supports the following browser types:

````
public enum DriverFlavour
{
    Chrome,
    Edge,
    Firefox,
    IE,
    Opera,
    Safari
}
````

### Customise Logging (Optional)

* Okapi comes with the ability to log testing activities and to capture snapshots which are controllable via configuration.
You can customise the logging message template format and logging destination by implementing Okapi's interface **IOkapiLogger**.

* Below is a simple implementation using Serilog's File sink. Serilog comes with many sinks. You can implement your own logger or implement your own Serilog sink to suit your logging and reporting needs.

	* NuGet package at https://www.nuget.org/packages/Okapi.Support.File/1.0.0 (obsolete)
	* From 1.2.7, please use https://www.nuget.org/packages/Okapi.Support.Log.Text/1.0.1
	* GitHub: https://github.com/tamnguyenbbt/Okapi.Support.Log.Text
	* Log file path is set via configuration (see Configuration section)

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

* When no implementation is provided or Okapi.Support.Log.Text NuGet package is not installed, Okapi does not perform logging.

### Customise Test Report (Optional)

* Implement **IReportFormatter** interface.
* To generate test reports for test cases, you need to decorate your test case methods with Okapi **TestCase** attribute. To generate test reports for test steps, decorate test step methods with Okapi **Step** attribute. 

* Call **TestReport.Verify()**, **TestReport.IsTrue()**, etc. to perform assertions and update report (you can use any assertion library but **TestReport** class has assertion methods with built-in reporting engine for Okapi so it serves two purposes - assert and report)

* Call **TestReport.Report()** at the end of the test case methods and test step methods to send the report to IReportFormatter

* Ready-to-use IReportFormatter implementations: 
	* https://github.com/tamnguyenbbt/Okapi.Support.Report.Text (report to text file)
	* https://www.nuget.org/packages/Okapi.Support.Report.Text/1.0.1
	* https://github.com/tamnguyenbbt/Okapi.Support.Report.Html (report to html files)
	* https://www.nuget.org/packages/Okapi.Support.Report.Html/1.0.7

* Report directory is set via configuration (see Configuration section)

* When no implementation is provided, or none of the NuGet packages listed above has been installed, Okapi does not perform reporting. 

### Inject Okapi Interface Implementations (Optional and Obsolete)

* Okapi comes with **IOkapiModuleLoader** interface for you to implement using Ninject's IKernel so that you can inject any implementation of Okapi's public interfaces to Okapi.

* However, from version 1.2.4, the implementation of **IOkapiModuleLoader** is NO LONGER required. Okapi automatically finds and loads the implementations for ITestEnvironment, IDriverOptionsFactory, IOkapiLogger, and IReportFormatter if any.

````
internal class DependencyInjector : IOkapiModuleLoader
{
    public void LoadAssemblyBindings(IKernel kernel)
    {
        kernel.Bind<ITestEnvironment>().To<TestEnvironment>().InSingletonScope();
        kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope();
        kernel.Bind<IOkapiLogger>().To<Logger>().InSingletonScope();
        kernel.Bind<IReportFormatter>().To<ReportFormatter>().InSingletonScope();
    }
}
````

## Sample Tests Using MSTest
* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/TestCases/SimpleTests.cs

## Sample Test Structure Set-up Using Page Object Model
* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/PageObjectModelSample

## Sample Test Using Reusable Driver
* https://github.com/tamnguyenbbt/Okapi/blob/master/OkapiSampleTests/TestCases/ReusableDriver.cs
          
## Versions
* Version **2.1.4** released on 09/04/2020

## Author
###  **Tam Nguyen**
[![View My profile on LinkedIn](https://static.licdn.com/scds/common/u/img/webpromo/btn_viewmy_160x33.png)](https://www.linkedin.com/in/tam-nguyen-a0792930/)

## Future Support/Development

### 1. Okapi Studio, desktop application for Okapi
Okapi Studio leverages the power of Okapi and has the following base features:
* Test artefact creation/edit vis UI. Unlike other tools in the market which have UI view and expert (code) view, Okapi Studio has only one UI view to be simple but it is advanced so users can create sophisticated tests without writing any line of code.
* Test artefact manager - project, test case, test step, test suite, object repository
* Execution/Debug - tests, test, actions, action, line by line, breakpoints
* Report
* Import/Export
* Test Data Parameterization
* Console Runner for CI/CD

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/OkapiStudio1.png)

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/OkapiStudio2.png)


# BASIC USAGE

## Setup to Use ChromeDriver on Windows 10

* Download the latest stable chromedriver.exe (32 bit for Windows) version which supports your Chrome browser from https://chromedriver.chromium.org/downloads and save it to a local folder

* Config Path environment variable for Selenium to find chromedriver.exe
  * Go to Control Panel > System > Advanced system settings > Environment Variables...> System variables > Path
  * Edit and add a new path item pointing to the folder containing chromedriver.exe file 
  
* Write a simple unit test using Okapi to test
  * ````IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");````  
  
* To be a bit more advanced, you might want to set up Selenium grid (hub and nodes) configuration instead. Check out: https://www.guru99.com/introduction-to-selenium-grid.html 
* In app.config, set driverFlavour to "Chrome"

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/AppConfig.jpg)

## Setup to Use EdgeDriver on Windows 10
* Download the latest stable Edge driver from https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver, change its name to 'MicrosoftWebDriver.exe' and save it to a local folder

* Config Path environment variable

* In app.config, set driverFlavour to "Edge"
  
## Search by Anchors Syntax
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
	
	* By any text or any attribute value: 
		````
			"`Hello`".GetTestObject();
			"Hello".GetTestObject();
			"Confirmation".GetTestObject();
			....
		````
* Note: Okapi treats traditional searching methods such as Id and class name as special cases of the advanced search by anchors algorithm where a search element is also the anchor element. 

For instance, 
````"userName".GetTestObject().SendKeys("John")```` acts the same as ````"Id `userName`".GetTestObject().SendKeys("John")````.


## Reuse Browser Session Opened from Previous Test Execution
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
	
* ````DriverPool.Instance.GetReusableDriver()```` creates a new driver if no reusable driver found active or gets the latest active reusable driver, ready for usage.

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

## Use Locating String

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
"anchor `First Name` search <input>".GetTestObject().SendKeys("John");
"anchor `first name` <label> search <input>".GetTestObject().SendKeys("John");
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
	"search <p-listboxitem>li>span[1]>".GetTestObject().Click(); //using embedded index at the end of the html tag chain
	"search <p-listboxitem/li/span[1]>".GetTestObject().Click(); //using embedded index at the end of the html tag chain
	````
	
## Embedded Element Index

* Element index can set via SetElementIndex() or via embedded element index for search by anchor or search by two anchors
* Embedded element index is the integer number between a opening square bracket and a closing square bracket at the end of search html tag/css selector

Example:
````
	"anchor <thead>tr>th> `Name` search <tbody>tr>td[1]>".GetTestObject();
	"anchor <thead>tr>th> `Name` search <tbody/tr/td[1]>".GetTestObject();
	"anchor <thead>tr>th> `Name` search <td[1]>".GetTestObject();
````

Of the found web elements, index 0 gets the first element; index 1 gets the second element, and so on.
	
## Use Info Class

* To check if the details of the web elements pointed to by a TestObject, Info class is helpful. It can be used to help you make decision on what element index to be passed to SetElementIndex().	

* Example:
````
Info info = "<p-listboxitem/li/span>".GetTestObject().Info;
Info info = "<p-listboxitem/li/span>".GetTestObject().QuickInfo; //a less information but less time to calculate
````

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/Info.png)


## Use FilterByScreenDistance()

* Okapi's search by anchors core algorithm is sophisticated but the basic for most of the common cases is:
	* It gets web elements having the shortest Document Object Model (DOM) from the anchor
	* Then it tries to filter out the ones having the larger loops in DOM 
	* Then it picks the ones with the shortest physical distance on screen. And these are the ones returned to your tests by Okapi.
	
* There are cases you don't want just to get/perform action on the elements with the shortest physical distance on screen. **FilterByScreenDistance(params int[] distanceOrders)** help you to control in this case. Order 0 is for the shortest distance, order 1 is for the second shortest distance, and so on.

## Control Screen Distance in Search by Anchors

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

## Control DOM Distance in Search by Anchors

* By default, Okapi search by anchors engine returns the web elements having the same SHORTEST DOM distances. Unlike physical screen distance order which starts from 0, Okapi considers the shortest DOM distance as order 1, the second shortest DOM distance as order 2 and so on. When a higher order is set, the search outcome will include those returned by the lower orders automatically. For instance, if order 3 is set, the search result will include those web elements found by order 1, 2 and 3.

* When more than one web elements are found, the web element under consideration/focus will be based on the set element index (mentioned above)

* To set the order, use ITestObject method **SetShortestDomDistanceDepth(int order)**

* Example: look at the below simple html snippet
````
	<div>
		<span>Status</span>
		<span>Inactive</span>
	</div>	
````

* By default, order 1 is set. ````"anchor `Status` search <span>".GetTestObject()```` gets the first span, the one containing inner text 'Status' because it has the shortest DOM distance (distance as 0; order 1) from itself (it is the anchor).

* To get both the spans, set order 2. ````"anchor `Status` search <span>".GetTestObject().SetShortestDomDistanceDepth(2)````. By default, element index 0 is set so the first span is returned/set focus (top down). To return the second span (the span containing 'Inactive' text), set element index as 1. 
	````
		"anchor `Status` search <span>".GetTestObject().SetShortestDomDistanceDepth(2).SetElementIndex(1); Or
		"anchor `Status` search <span[1]>".GetTestObject().SetShortestDomDistanceDepth(2); //use embedded element index
	````

* Use Info or QuickInfo to have a detailed look into the search results
	````
		"anchor `Status` search <span[1]>".GetTestObject().SetShortestDomDistanceDepth(2).Info;		
	````
	
* After changing order to be more than 1 for a test object, use **RestoreDefaultShortestDomDistanceDepth()** to set the order back to 1 (default) when needed.

* If more than one web elements are found (same shortest DOM distances), by default, the ones with smallest loop are returned, larger loops being filtered out/removed (filter being ON). To turn this filter off/on, use **FilterByShortestRootAnchorDomDistance(bool on)**. To understand how this filter works, imagine multiple triangles (A-R-S) where A is anchor element, R is root element and S is search element. If multiple search web elements are found initially, there are multiple ARS triangles. They all shares the same A. Smallest html loops have the shortest A to R DOM distance.

## Memory Cache

* Okapi TestObject class has a built-in memory caching mechanism to boost performance. It manages the cache automatically in a smart way for most of the cases.

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

````
ITestObject studentId = "5235868631646".GetTestObject();
ITestObject studentName = cabinetProduct.ParentAt(2).NextSiblingAt(1).ChildAt(4); //order starts from 0
TestReport.IsTrue("Jane Doe", studentName.Value);

//the above 2 lines work fine if the web page under test (so the DOM) is stable before these 2 lines are running.
//One way to achieve that is to use Sleep() but that is quite bad practice in test automation.
//If the page is not stable yet when these lines are run, the chance to fail with StaleWebElementException is high, 
//making the test script not reliable enough to be trusted.

//better approach
ITestObject studentName = cabinetProduct.ParentAt(2).NextSiblingAt(1).ChildAt(4);
//retries to clear memory cache and calculates again and again until the condition is true or timeout reached. 
//This is to make sure to get the result which is correct when the DOM is stable.
var result = studentName.RetryToClearRelationCacheUntil(self => self.TryGetText(2).Equals("Jane Doe"));
TestReport.IsTrue(result.Value);

//lazy approach, getting all possible children and let Okapi to find which one containing 'Jane Doe'. 
//If any matched, Okapi returns the first matched.
//Drawback is slow speed
ITestObject studentName = cabinetProduct.ParentAt(2).NextSiblingAt(1).Child;  
var result = studentName.RetryToClearRelationCacheUntil((self, index) => self.SetElementIndex(index).TryGetText(2).Equals("Jane Doe"));
TestReport.IsTrue(result.Value);
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

* When you work with, say, an html table where you add a new row every time a test script is run; the added row being based on dynamic test data (i.e. a random date or number); and the locator for this row containing this dynamic data, please be mindful about it. If you cache this test object locator, next executions will get that cached locator which contains the old dynamic data. But you have new test data for every execution. Then the cached xpath does not serve up well. In this situation, you need to force search by anchors engine to delete that cached item and recalculate the locator by calling **ClearObjectRepositoryCache()**

* Example: a table
	````
		ITestObject studentRow = "Anchor <thead>tr>th> `Order` search `{0}`".GetTestObject("1").ClearObjectRepositoryCache();
            	string firstName = studentRow.NextSiblingAt(0).Value; //input box
            	string lastName = studentRow.NextSiblingAt(1).Value; //input box
            	string dobString = studentRow.NextSiblingAt(2).Text; //label
		DateTime dob = DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
	````


## Work with Drivers/Browsers

* With Okapi, drivers are managed in the back-ground and named ManagedDriver which implements IManagedDriver interface. Users do not need to refer to a driver for every action like in Selenium, making it easier for users to focus on the business rules of the test scenario, cutting over-heads in code. A ManagedDriver object is one-one mapped to a browser.

* Managed drivers are created, stored and deleted in a pool. The only times users have to deal with a driver is when launching a page and when quitting a driver.

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

* With Selenium, every time a test script is executed, it has to create a new driver. Unlike Selenium, Okapi allows users to reuse an already opened browser from the last run, in the same execution or not in the same execution session.

````
DriverPool.Instance.CreateReusableDriverFromLastRun();
````


## FileDB
* Okapi comes with a file database utility called FileDB for users to save and retrieve test data to share between test scripts across multiple running sessions.

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


## Work with Windows

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

* Okapi's preferred method of managing iframes is to use **Frame** objects. After having the list of **Frame** objects (children, children of children, and so on) via **InnerIFrames** property, users can jump straight to any frame using **JumpToIFrame(Guid id)**.

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

## AppConfig Class
* Okapi.Configs.AppConfig.TargetTestEnvironment gets the target environment name set within app.config file


## Util Class
* Okaki.Utils.Util class provides utility properties and methods to be used in test scripts.


## Test Data Interfaces

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
	* Some inexperienced automation testers try to use CSV, Excel, database, etc. to store test data when they write test scripts directly from IDEs. This is often considered overkill and often adds unnecessary overheads because they need to convert back and forth from DTO classes to one of the above-mentioned forms. These forms may be useful when you use a tool, not an API, such as you write a desktop client application which uses Okapi as the engine.
	* Always write reusable test steps which are independent from the web page business rules. Business rules should be embedded in test data and be injected by test data into reusable test steps (data-driven test). Okapi methods support data-driven test out of the box.
	* Embedding business rules within the code is very bad practice of writing test automation scripts. It makes it hard to debug and troubleshoot, hard to maintain, etc. and the scripts look messy.


## Common TestObject Method References

* Click -> clicks on a web element. Checks if the web element is ready before clicking. Retries if the click action does not take effect
* DoubleClick -> double click on a web element
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
* GetLifespanInMilliseconds -> get life span of a web element, useful for elements which exist a short time, such as a validation error message
* (To be added)

## Visual Studio Unit Test Logs for Failed Tests 

* Okapi console logs (in JSON format) on failed tests are comprehensive which support the best for script debugging

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/UnitTestExplorer.png)


## View Test Execution Report

* If you have installed the Html test report NuGet package mentioned above, Okapi creates test execution reports for you after each execution.

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/SummaryHtmlReport.png)


![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/TestCaseDetailedHtmlReport.png)

## View Activity Logs

* If you have installed Okapi.Support.Log.Text NuGet package as mentioned above and have set log path within the configuration, Okapi generates activity logs for you.

````
2020-02-27 09:48:40.115 +11:00 [INF] Click | Index: 0 | Locators: //p-dropdownitem/li/span[text()='7']          ----> TEST: [Id: 21637a99-ed8e-4059-9186-71df03ed3de4 | Name: Test1 | Namespace: Okapi.Sample.Tests.TestCases | File Name: C:\DEV\Okapi.Sample.Tests\TestCases\Sample.cs | Line: 10 | Column: 12]          ----> STEP: [Id: 843ab07c-ea65-4965-8710-4fb220b876d7 | Name: Step1 | Namespace: Okapi.Sample.Tests.TestCases.TestSteps | File Name: C:\DEV\Okapi.Sample.Tests\TestSteps\Login.cs | Line: 57 | Column: 9]
````

* For failed activities, the log includes more failed details in JSON format

## Record Html Document XPaths

* Okapi comes with the capability to record all the xpaths within a html document. There are two ways to do that - via **Dom** class or via **IManagedDriver**.

* It is open for users of other tools to pass a html document as text into Okapi and Okapi provides back the xpaths for all the web elements on that html document. There having been some requests from those who have contacted me, I am going to develop a simple Console application, Desktop application, or a simple self-host web service for users of other tools/APIs and those who use Java Selenium to call to get xpaths for all web elements on a html document or xpaths for individual search by anchors.

* Example: Record xpaths for all web elements in a document
````
IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
string html = driver.Html;
Dom dom = new Dom(html);
ManagedXPaths managedXPaths = dom.UnverifiedDocumentManagedXPaths;
managedXPaths.UpdateDescription("Login");
List<string> xpaths = managedXPaths?.Select(x => x.RecomendedUnverifiedLocator)?.ToList();
````

* Example: Record xpaths for some web elements in a document
````
IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
string html = driver.Html;
Dom dom = new Dom(html);
int managedXPathCount = dom.ManagedXPathCount;
ManagedXPaths managedXPaths = dom.GetUnverifiedManagedXPaths(10, 30); //get 30 xpaths out of managedXPathCount xpaths, from index 10 to index 39)
List<string> xpaths = managedXPaths?.Select(x => x.RecomendedUnverifiedLocator)?.ToList();
````

* This method provides the unverified xpaths - those calculated from the provided html document. These xpaths are not tested/confirmed from a real driver/browser.

* Recording from **IManagedDriver** and you get the verified/confirmed xpaths against the real driver

* Example: Record xpaths for all web elements from current driver
```
IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
ManagedXPaths verifiedManagedXPaths = driver.GetDocumentManagedXPaths();
```

* Example: Record xpaths for some web elements from current driver
```
IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
int managedXPathCount = driver.GetDocumentManagedXPathCount();
ManagedXPaths verifiedManagedXPaths = driver.GetDocumentManagedXPaths(0, 20); //get 20 xpaths out of managedXPathCount xpaths, from index 0 to index 19)
```

* Instead of recording for all web elements, users are alllowed to narrow down the web elements of choice using **DomFilter** class.

* Example:

````
IManagedDriver driver = DriverPool.Instance.GetReusableDriver();
DomFilter domFilter = new DomFilter()
                .SetAllowedTextKeywordsForAnchor("User Nanme", "Password", "Sign In")
                .SetAllowedHtmlTagsOrCssSelectorsForNonAnchor("span", "div")
                .SetAllowedHtmlTagsOrSelectorsForAnchor("label");
Dom dom = new Dom(html, domFilter);
int managedXPathCount = dom.ManagedXPathCount;
ManagedXPaths verifiedManagedXPaths = driver.GetDocumentManagedXPaths(10, 20, domFilter); 
````

## ManagedXPathCache File Cache

* The outcome of the previous recording process is **ManagedXPaths** class. Okapi has the class **ManagedXPathCache** for users to organise **ManagedXPaths** instances within a file cache

````
IManagedDriver driver = DriverPool.Instance.GetReusableDriver();
ManagedXPaths managedXPaths = dom.UnverifiedDocumentManagedXPaths;
ManagedXPathCache cache = new ManagedXPathCache("C:\\test");
Guid? id = cache.Save(managedXPaths);
IList<ManagedXPaths> allManagedXPaths = cache.FindAll();
ManagedXPaths savedManagedXPaths = cache.FindById(id);
IList<ManagedXPaths> allLoginManagedXPaths = cache.FindByDescription("Login");
cache.Delete(id);
allManagedXPaths = cache.FindAll();
````

## Get Possible XPaths from Search by Anchors Locators

* Users of other web ui test tools can use Okapi to convert search-by-anchors texts into possible xpaths for using with your tools. You need to pass in two pieces of information - html document text; search-by-anchors text

* Example:

	````ManagedXPaths managedXPaths = "<button> `Save`".GetTestObject().GetManagedXPaths(html);````
	
* Because you pass in html content, Okapi calculates based on it. You lose a bit of precision offered by Okapi when you use Okapi fully with Okapi's IManagedDriver. The reason is, with Okapi's IManagedDriver, Okapi applies two additional layers of filters. The first is an algorithm of getting shortest physical distance on driver/browser; the second is double-checking the calculated xpaths against driver to narrow down search results. 

* You also lose a bit of performance because you cannot use Okapi's cache to speed up test executions here.

* Developement of a legacy-dotNet-based self-host RESTful API is underway so that when done, your tools can call it in real-time to perform search-by-anchors text to xpaths conversions. This webservice is for Windows but it can be wrapped into docker images for other environments such as Linux. 

# ADVANCED USAGE

## Get Text of a Cell in a Table

* Imagine there is a table on a web page with multiple columns and multiple rows. Under the column 'Student Info', each cell contains student id and student name. We want to get student name when we know student id.

* There are multiple ways to do that in Okapi. Below is code demonstrate one way to do that. 
	* ````ITestObject row = "anchor `{0}` search <tr>".GetTestObject("12345678"); //12345678 is student id````
	* ````int precedingRowCount = row.PrecedingSibling.ElementCount;```` --> get the number of rows above the row with student id above
	* ````string studentName = "anchor `Student Info` search <table>tr>".GetTestObject().FilterByScreenDistance(precedingRowCount)               .Child.NextSiblingAt(2).ChildAt(5).Text;````
	
	By default, ````"anchor `Student Info` search <table>tr>".GetTestObject()```` will get the closest row toward the column title 'Student Info' which is the first row in the table. We don't want that to happen. We want to get the row we wanted so we call FilterByScreenDistance(precedingRowCount) which gets row at at distance order 'precedingRowCount' from the column title.
	Now we are in the row, looking into the DOM a bit and seeing that to go to the student name element we have to call ````Child.NextSiblingAt(2).ChildAt(5)````. 
	
## Working with Repeated UI Blocks

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
		
## Usage of Okapi Lambda Functions

### 1. Example 1: working with multiple text boxes having similar characteristics
* Imagine there is a web page which has multiple text boxes with similar html structures and we need to fill up these text boxes with test data. When a piece of data for a text box is null, does nothing for that text box. Each text box has a label next to it.

* We need to write reusable code with test data driven capability so we can use this block of code, a method, to test the page with both positive test cases and negative test cases, driven by test data.

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

### 2. Example 2: Working with Table
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


### 3. Example 3: Working with a Counter
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
	- Math.Abs(numberOfClicksToPerform) to change from negative number to positive number before passing to For() for repeating.
	
	
### 4. Example 4: Working with a ComboBox
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

### 5. Example 5: Working with Paging
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
     self =>
     {
        self.Click();
        "<div>spinner>progressbar>".GetTestObject().WaitUntilGone();
     });
}
````

	
## Verify if a Checkbox Becomes a Saved Symbol after Ticking it

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

## Use Strict Mode

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
	
	
# COMMON PRACTICAL USAGES

## Check Multiple Conditions
* Stop checking on getting the first false

````
	bool validationOK = false;
	
	"anchor <thead>tr>th> `First Name` search <tbody>tr>td> `{0}`"
	.GetTestObject()
	.ClearObjectRepositoryCache()
	.OnTrue(self => self.SetSearchElementDynamicContents("John").OneFound(5))
	.OnTrue(self => 
	{
		string dateOfBirth = self.NextSibling.Text;
                return dateOfBirth.Equals("01/01/1991"));
	})
	.Run(() => validationOK = true);
	
	TestReport.IsTrue(validationOK);
````
	
## Constructing High-Level Actions
* Okapi has some high-level actions via **Okapi.Common.CommonActions** class. You can build your own reusable high-level actions for your organisation's web applications where the same html UI design/structural patterns are repeated for multiple web elements and/or in multiple web pages.

* Below is an example of reusable action to select date from a date picker. You can see search-by-anchors is used instead of xpaths which makes this method easier to maintain and robust.

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/DatePicker.png)

````
[Step]
public void PickDateFromDatePicker(DateTime dateTime, string anchorText, string anchorTag = null, 
string parentAnchorText = null, string parentAnchorTag = null)
{
	// Click selector to launch date picker
	string selectorLocator = CommonActions.Instance.BuildSearchByAnchorsLocator(
	parentAnchorTag, parentAnchorText, anchorTag, anchorText, "button>span", null);
	
	selectorLocator.GetTestObject().Click();
	
	// Get current month and year from the date picker using class attribute values, i.e. 'datepicker-month'
	string currentMonthText = "datepicker-month".GetTestObject().Text;
	string currentYearText = "datepicker-year".GetTestObject().Text;
	DateTime currentDate = 
	DateTime.ParseExact($"01 {currentMonthText} {currentYearText}", "dd MMM yyyy", CultureInfo.InvariantCulture);
	int currentMonth = currentDate.Month;
	int currentYear = currentDate.Year;
	
	// Get month difference
	int newMonth = dateTime.Month;
	int newYear = dateTime.Year;
	
	int yearDiff = newYear - currentYear;
	int monthDiff = newMonth - currentMonth + yearDiff * 12;
	
	// Build search-by-anchors locator for next or previous arrow with search element text as dynamic, which is '{0}'.
	// This later can be injected with a class attribute value, for the next arrow or the previous arrow
	string arrowLocator = CommonActions.Instance.BuildSearchByAnchorsLocator(
	parentAnchorTag, parentAnchorText, null, anchorText, "div>a>span", "{0}");
	
	// If monthDiff > 0, inject 'datepicker-next-icon' - class attribute value for next arrow.
	// Then loop through monthDiff with the step as 1 and click on the next arrow for each loop.
	// If monthDiff <0, do the same for previous arrow. 
	arrowLocator.GetTestObject().Run(monthDiff >= 0,
	self => 
	self.SetSearchElementDynamicContents("datepicker-next-icon").OnTrue(monthDiff > 0).For(x => x.Click().Sleep(50), monthDiff),
	self =>
	self.SetSearchElementDynamicContents("datepicker-previous-icon").For(x => x.Click().Sleep(50), -monthDiff));
	
	// Click on the date to select it
	string itemLocator = CommonActions.Instance.BuildSearchByAnchorsLocator(
	parentAnchorTag, parentAnchorText, anchorTag, anchorText, "td>a", dateTime.Date.ToString());
	
	itemLocator.GetTestObject().Click();
	
	// Report step
	TestReport.Report();
}
````

**Usage:**
	In the below usage example, no parent anchor information is needed; anchor tag is not need; anchor text is the label 'Registration Date:' on top of the date picker.

	PickDateFromDatePicker(new DateTime(7, 4, 2020), "Registration Date:");

* Below is an example of reusable action to select time from a time picker.

![alt text](https://github.com/tamnguyenbbt/Okapi/blob/master/Photos/TimePicker.png)

````
[Step]
public void PickTimeFromTimePicker(int? hour, int? minute, string parentAnchorText = null, string parentAnchorTag = null)
{
	TestExecutor.Run(hour != null && hour >= 0 && minute != null && minute >= 0, () =>
	{
		PickHourOrMinuteFromTimePicker((int)hour, "hour-picker", parentAnchorText, string parentAnchorTag);
		PickHourOrMinuteFromTimePicker((int)minute, "minute-picker", parentAnchorText, string parentAnchorTag);
	});
	
	TestReport.Report();
}

private void PickHourOrMinuteFromTimePicker(int hourOrMinute, string classAttribute, string parentAnchorText = null, string parentAnchorTag = null)
{
	// Get current hour or minute
	string currentHourOrMinuteText = CommonActions.Instance.BuildSearchByAnchorsLocator(
	null, null, null, classAttribute, "div>span[1]", null).GetTestObject().Text;
	
	int currentHourOrMinute = int.Parse(currentHourOrMinuteText);
	
	// Get hour or minute defference
	int diff = hourOrMinute - currentHourOrMinute;
	
	// Set hour or minute
	string arrowLocator = CommonActions.Instance.BuildSearchByAnchorsLocator(
	parentAnchorTag, parentAnchorText, null, classAttribute, "div>a>span", null);
	
	ITestObject arrow = arrowLocator.GetTestObject().NoFilterByScreenDistances(); // Get arrow up and down
	
	arrow.Run(diff >= 0,
	self => self.SetElementIndex(0).OnTrue(diff > 0).For(x => x.Click().Sleep(100), diff),
	self => self.SetElementIndex(1).For(x => x.Click().Sleep(100), -diff));
}
````
