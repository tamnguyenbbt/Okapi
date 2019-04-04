using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Enums;
using Okapi.Report;
using Okapi.Runners;
using OkapiSampleTests.TestData;

namespace OkapiTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        [TestCase]
        public void Get_text_with_assertion_library_of_your_choice()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string text = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            void assertion() => Assert.AreEqual("Try Xero FREE for 30 days!", text);
            TestReport.Verify(assertion);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Assertion_with_user_added_message()
        {
            string expected = "Welcome! Try Xero FREE for 30 days!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            void assertion() => Assert.AreEqual(expected, actual);
            KeyValuePair<Action, string> assertionsAndUserAddedData
                = new KeyValuePair<Action, string>(assertion, $"Expected: {expected} | Actual: {actual}");
            TestReport.Verify(assertionsAndUserAddedData);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Use_steps()
        {
            string expected = "Try Xero FREE for 30 days!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            SampleSteps.Step1(expected);
            SampleSteps.Step1(expected);

            string actual = TestObject.New(SearchInfo.OwnText(expected)).Text;
            TestReport.Verify(() => Assert.AreEqual(expected, actual), $"Expected: {expected} | Actual: {actual}");

            SampleSteps.Step2("Welcome! Try Xero FREE for 30 days!");
            SampleSteps.Step1(expected);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Assertion_with_user_added_messages()
        {
            string expected = "Welcome! Try Xero FREE for 30 days!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            void assertion() => Assert.AreEqual(expected, actual);
            KeyValuePair<Action, IList<string>> assertionsAndUserAddedData
                = new KeyValuePair<Action, IList<string>>(assertion,
                new List<string> { $"Expected: {expected} | Actual: {actual}" });
            TestReport.Verify(assertionsAndUserAddedData);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Assertion_with_user_added_message_passed()
        {
            string expected = "Try Xero FREE for 30 days!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText(expected)).Text;
            void assertion() => Assert.AreEqual(expected, actual);
            KeyValuePair<Action, string> assertionsAndUserAddedData
                = new KeyValuePair<Action, string>(assertion, $"Expected: {expected} | Actual: {actual}");
            TestReport.Verify(assertionsAndUserAddedData);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void One_assertion()
        {
            string expected = "Welcome! Try Xero FREE for 30 days!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            void assertion() => Assert.AreEqual(expected, actual);
            TestReport.Verify(assertion, $"Expected: {expected} | Actual: {actual}");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Loop_test_with_data_set()
        {
            IDataSet<Registration> dataSet = new RegistrationDataSet();
            TestExecutor.Loop(Sample_scenario, dataSet);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
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
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
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
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Parallel_test_with_data_set()
        {
            TestExecutor.Parallel(Sample_scenario, new RegistrationDataSet());
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
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
            TestReport.Report().QuitActiveDriver();
        }

        private static void Sample_scenario(Registration registration)
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys(registration.UserName);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Single_driver_auto_created_by_driver_pool()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Developer_friendly_style()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void XPath_by_default()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void By_name()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject(LocatingMethod.Name, "FirstName"); //name attribute of tag input
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void By_anchor()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.New("span", "First name"), SearchInfo.New("input"));
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void One_dynamic_content_making_one_test_object_to_hit_two_fields()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.New("span", "{0}"), SearchInfo.New("input"), DynamicContents.New("First name"));
            userName.SendKeys("Automation");
            userName.DynamicContents = DynamicContents.New("Last name");
            userName.SendKeys("Tester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
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
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
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
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Another_developer_friendly_style_by_name()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");

            var userName = new TestObject()
            {
                LocatingMethod = LocatingMethod.Name,
                Locator = "FirstName"
            };

            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Single_driver_auto_created_by_driver_pool_plus_user_created_driver()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'{0}')]]/input", DynamicContents.New("First name"));
            ManagedDriver previousActiveDriver = DriverPool.Instance.ActiveDriver;
            DriverPool.Instance.CreateDriver().LaunchPage("https://www.google.com");
            DriverPool.Instance.ActiveDriver = previousActiveDriver;

            userName.MoveToElement();
            userName.SendKeys("TesterTester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void SetDynamicContents()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'{0}')]]/input");
            userName.SetDynamicContents("First name").MoveToElement().SendKeys("TesterTester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Single_anchor()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            TestObject.New(SearchInfo.New("span", "Next1")).Click().Click();
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Try_get_element_count_when_no_element_found()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            var button = TestObject.New(SearchInfo.New("span", "Next1"));

            if (button.TryGetElementCount(1) != 0)
            {
                button.Click();
            }

            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Get_element_count_when_no_element_found()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            var elementCount = TestObject.New(SearchInfo.New("span", "Next1")).ElementCount;
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Get_element_count_when_element_found()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            var elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void By_anchor_without_anchor_tag()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.OwnText("First name"), SearchInfo.New("input"));
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }
    }
}