# Okapi
Selenium and ExtSelenium-based Web UI test automation library with dynamic content concept support
* Support Selenium WebDriver Grid configuration only
* Support .Net Framework 4.5 and 4.6

## Set Up Test Project
The code in this repo is for a sample test project based on MSUnit and .Net Framework 4.5 and uses Okapi library.
* Okapi library can be found under NuGet at https://www.nuget.org/packages/Okapi/1.0.0

### Using App.config

If you decide to use **App.config**, add an App.config file as below:

````
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="EnvironmentSection" type="Okapi.Configs.EnvironmentSection, Okapi" />
  </configSections>
  <appSettings>
    <add key="SeleniumHubUrl" value="http://localhost:2021/wd/hub"/> //need to change to your Selenium Hub URL    
  </appSettings>
  <EnvironmentSection>
    <Environments>
      <add targetTestEnvironment="Test"
           active="true"
           driverFlavour="ChromeDriver" //required
           driverTimeoutInSeconds ="10" //if not set, Okapi set 10 by default
           quitDriverOnError ="true"/> //if not set, Okapi set true by default
    </Environments>
  </EnvironmentSection>  
</configuration>
````
### Using class configs

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

namespace OkapiSampleTests.Configurations
{
    public class LocalChromeTestEnvironment : ITestEnvironment
    {
        public static LocalChromeTestEnvironment Instance => new LocalChromeTestEnvironment();
        DriverFlavour ITestEnvironment.DriverFlavour => DriverFlavour.Chrome;
        Uri ITestEnvironment.SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
    }
}
````

You then can pass them into the constructors of the Okapi library's classes, i.e. 
````
DriverPool.Instance.CreateDriver(LocalChromeTestEnvironment.Instance)
````

OR you can inject them into the Okapi library using Dependency Injection (DI) (Ninject).
To inject, you need to implement Okapi library's **IOkapiModuleLoader** interface as below:

````
using Ninject;
using Okapi.Configs;
using Okapi.DI;
using Okapi.Drivers;

namespace OkapiSampleTests.Configurations
{
    internal class CustomisedModuleLoader : IOkapiModuleLoader
    {
        public void LoadAssemblyBindings(IKernel kernel)
        {
            kernel.Bind<ITestEnvironment>().To<LocalChromeTestEnvironment>().InSingletonScope();
            kernel.Bind<IDriverConfig>().To<CustomisedDriverConfig>().InSingletonScope();
            kernel.Bind<IDriverOptionsFactory>().To<CustomisedDriverOptionsFactory>().InSingletonScope();
        }
    }
}
````

If you define both App.config and DI, DI will take precedence.

If you want to control the browsers' behaviours rather than using the default behaviours provided by Opika, 
you can implement Okapi library's **IDriverOptionsFactory** interface. For instance,

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
                    chromeOptions.AddArguments("--no-sandbox");
                    return chromeOptions;
            }
        }
    }
}
````

then inject it via DI.

Okapi supports the following browser types so far:

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

## Example
````
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Enums;

namespace OkapiTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void Single_driver_auto_created_by_driver_pool()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void Developer_friendly_style()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void XPath_by_default()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void By_name()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject(LocatingMethod.Name, "FirstName"); //name attribute of tag input
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void By_anchor()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.New("span", "First name"), SearchInfo.New("input"));
            userName.SendKeys("Automation");
            DriverPool.Instance.QuitAllDrivers();
        }

        [TestMethod]
        public void One_dynamic_content_making_one_test_object_to_hit_two_fields()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
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
            currentDriver.LauchPage("https://www.xero.com/au/signup/");

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
            currentDriver.LauchPage("https://www.xero.com/au/signup/");

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
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            
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
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'{0}')]]/input", DynamicContents.New("First name"));
            ManagedDriver previousActiveDriver = DriverPool.Instance.ActiveDriver;
            DriverPool.Instance.CreateDriver().LauchPage("https://www.google.com");
            DriverPool.Instance.ActiveDriver = previousActiveDriver;

            userName.MoveToElement();
            userName.SendKeys("TesterTester");
            DriverPool.Instance.QuitAllExceptActiveDriver();
            DriverPool.Instance.QuitActiveDriver();
        }
    }
}
````

## Usage
* Usage document in PDF will come soon.
            
## Versions
* Version **1.0.0.1** released on 03/20/2019
* Version **1.0.0** released on 03/19/2019

## NuGet
* https://www.nuget.org/packages/Okapi/1.0.0.1
* Install-Package Okapi -Version 1.0.0.1

## Dependencies
### .NETFramework 4.5
* ExtSelenium (>= 1.0.0.3)
* Ninject (>= 3.3.4)

### .NETFramework 4.6
* ExtSelenium (>= 1.0.0.3)
* Ninject (>= 3.3.4)

## Author
###  **Tam Nguyen**
[![View My profile on LinkedIn](https://static.licdn.com/scds/common/u/img/webpromo/btn_viewmy_160x33.png)](https://www.linkedin.com/in/tam-nguyen-a0792930/)
