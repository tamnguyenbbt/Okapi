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
