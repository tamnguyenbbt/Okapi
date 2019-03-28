# Okapi Get Started
Okapi is a Selenium and ExtSelenium-based **Web UI test automation library** with dynamic content concept support
* Supports Selenium ChromeDriver, FirefoxDriver, InternetExplorerDriver, EdgeDriver and RemoteWebDriver
* Supports .Net Framework 4.5 and 4.6
* Supports data-driven
* Manages Selenium drivers automatically and hides them from users to simplify test automation processes

## NuGet
* https://www.nuget.org/packages/Okapi/1.0.0.6
* Install-Package Okapi -Version 1.0.0.6

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
    public class CustomisedDriverConfig : IDriverConfig
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
    internal class LocalChromeTestEnvironment : ITestEnvironment
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
    internal class CustomisedDriverOptionsFactory : IDriverOptionsFactory
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

### Customize Okapi Logging
Okapi comes with the ability to log testing activities and to capture snapshots which are controllable via configuration.
You can customize the logging message template format and logging destination by implementing Okapi's interface **IOkapiLogger**.
Below is a simple implementation using Serilog's File sink. Serilog comes with many sinks. You can implement your own logger or implement your own Serilog sink to suit your logging and reporting needs.

At this point of time, IOkapiLogger supports string messages. JSON support may come in future.

````
using System;
using Okapi.Logs;
using Serilog;
using Serilog.Core;

namespace OkapiSampleTests.ThirdParties
{
    internal class OkapiLogger : IOkapiLogger
    {
        private readonly static Logger logger = new LoggerConfiguration().WriteTo.File("C:\\DEV\\Tam\\Okapi\\log.txt").CreateLogger();

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

### Inject Okapi Interface Implementations
Okapi comes with **IOkapiModuleLoader** interface for you to implement using Ninject's IKernel so that you can inject your settings mentioned above to Okapi

````
using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;
using Okapi.Logs;
using OkapiSampleTests.Configurations;
using OkapiSampleTests.ThirdParties;
using OkapiTests;

namespace OkapiSampleTests.DI
{
    internal class OkapiModuleLoader : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            kernel.Bind<ITestEnvironment>().To<LocalChromeTestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<DriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<DriverOptionsFactory>().InSingletonScope();
            kernel.Bind<IOkapiLogger>().To<OkapiLogger>().InSingletonScope();
        }
    }
}
````

## Example
````
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Enums;
using Okapi.Runners;
using OkapiSampleTests.TestData;

namespace OkapiTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void Loop_test_with_data_set()
        {
            IDataSet<Registration> dataSet = new RegistrationDataSet();
            TestExecutor.Loop(Sample_scenario, dataSet);
        }

        [TestMethod]
        public void Loop_test_with_data_list()
        {
            IList<Registration> testData = new List<Registration>
            {
                new Registration()
                {
                    UserName = "Automation1"
                },
                new Registration()
                {
                    UserName = "Automation2"
                },
            };

            TestExecutor.Loop(Sample_scenario, testData);
        }

        [TestMethod]
        public void Parallel_test_with_data_list()
        {
            IList<Registration> testData = new List<Registration>
            {
                new Registration()
                {
                    UserName = "Automation1"
                },
                new Registration()
                {
                    UserName = "Automation2"
                },
            };

            TestExecutor.Parallel(Sample_scenario, testData);
        }

        [TestMethod]
        public void Parallel_test_with_data_set()
        {
            TestExecutor.Parallel(Sample_scenario, new RegistrationDataSet());
        }

        [TestMethod]
        public void Parallel_test_with_data_set_in_line()
        {
            TestExecutor.Parallel(
                new Action<Registration>(x =>
                {
                    DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
                    var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
                    userName.SendKeys(x.UserName);
                    DriverPool.Instance.QuitActiveDriver();
                })
            , new RegistrationDataSet());
        }

        private static void Sample_scenario(Registration registration)
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys(registration.UserName);
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void Single_driver_auto_created_by_driver_pool()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void Developer_friendly_style()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void XPath_by_default()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void By_name()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject(LocatingMethod.Name, "FirstName"); //name attribute of tag input
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void By_anchor()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.New("span", "First name"), SearchInfo.New("input"));
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitAllDrivers();
        }

        [TestMethod]
        public void One_dynamic_content_making_one_test_object_to_hit_two_fields()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.New("span", "{0}"), SearchInfo.New("input"), DynamicContents.New("First name"));
            userName.SendKeys("Automation");
            userName.DynamicContents = DynamicContents.New("Last name");
            userName.SendKeys("Tester");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void Another_develper_friendly_style_by_anchor_implicitly()
        {
            ManagedDriver currentDriver = DriverPool.Instance.ActiveDriver;
            currentDriver.LaunchPage("https://www.xero.com/au/signup/");

            var userName = new TestObject()
            {
                AnchorElementInfo = SearchInfo.New("span", "{0}"),
                SearchElementInfo = SearchInfo.New("input"),
                DynamicContents = new List<string>() { "First name" }
            };

            userName.SendKeys("Automation");
            userName.DynamicContents = DynamicContents.New("Last name");
            userName.SendKeys("Tester");
            DriverPool.Instance.Quit(currentDriver);
        }

        [TestMethod]
        public void Another_develper_friendly_style_by_xpath_as_default()
        {
            ManagedDriver currentDriver = DriverPool.Instance.ActiveDriver;
            currentDriver.LaunchPage("https://www.xero.com/au/signup/");

            var userName = new TestObject()
            {
                Locator = "//label[span[contains(text(),'{0}')]]/input",
                DynamicContents = new List<string>() { "First name" }
            };

            userName.SendKeys("Automation");
            userName.DynamicContents = DynamicContents.New("Last name");
            userName.SendKeys("Tester");
            DriverPool.Instance.Quit(currentDriver);
        }

        [TestMethod]
        public void Another_develper_friendly_style_by_name()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");

            var userName = new TestObject()
            {
                LocatingMethod = LocatingMethod.Name,
                Locator = "FirstName"
            };

            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void Single_driver_auto_created_by_driver_pool_plus_user_created_driver()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'{0}')]]/input", DynamicContents.New("First name"));
            ManagedDriver previousActiveDriver = DriverPool.Instance.ActiveDriver;
            DriverPool.Instance.CreateDriver().LaunchPage("https://www.google.com");
            DriverPool.Instance.ActiveDriver = previousActiveDriver;

            userName.MoveToElement();
            userName.SendKeys("TesterTester");
            DriverPool.Instance.QuitAllExceptActiveDriver();
            DriverPool.Instance.QuitActiveDriver();
        }
    }
}
````

* Data set example
````
using System.Collections.Generic;
using Okapi.Runners;

namespace OkapiSampleTests.TestData
{
    public class RegistrationDataSet : IDataSet<Registration>
    {
        public IList<Registration> Get()
        {
            var data = new List<Registration>
            {
                new Registration()
                {
                    UserName = "Automation1"
                },
                new Registration()
                {
                    UserName = "Automation2"
                },
            };

            return data;
        }
    }
}
````

## Usage
* Usage document will come in near future.
            
## Versions
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
