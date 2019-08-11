using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Enums;
using Okapi.Report;
using OkapiSampleTests.Steps;

namespace OkapiSampleTests.TestCases
{
    [TestClass]
    //See https://github.com/tamnguyenbbt/Okapi/blob/master/HowToTestWithChromeDriver.md 
    //for how to set up a simple Chrome driver to use with these tests
    public class SimpleTests
    {
        [TestMethod]
        [TestCase]
        public void Dynamic_find_by_tag_and_text()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string text = Dynamic.Find("<h2> `Try Xero FREE for 30 days!`").Text;
            void assertion() => Assert.AreEqual("Try Xero FREE for 30 days!", text);
            TestReport.Verify(assertion);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Dynamic_find_by_xpath()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            Dynamic.Find("Find xpath `//label[span[contains(text(),'First name')]]/input`").SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_own_text()
        {
            DriverPool.Instance.ActiveDriver.SetTimeoutInSeconds(4).LaunchPage("https://www.xero.com/au/signup/");
            string text = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            TestReport.AreEqual("Try Xero FREE for 30 days!", text);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Use_assertion()
        {
            string expected = "Try Xero FREE for 30 days!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            TestReport.AreEqual(expected, actual, $"Expected: {expected} | Actual: {actual}");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Failed_assertion_with_action_on_fail()
        {
            string expected = "Hello";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            TestReport.IsTrue(
                expected == actual,
                () =>
                {
                    new TestObject(LocatingMethod.Name, "FirstName").SendKeys("Automation");
                }, "Expected: {0} | Actual: {1}", expected, actual);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_name_attribute()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject(LocatingMethod.Name, "FirstName");
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_xpath_by_default()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = new TestObject("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_anchor_with_smart_search()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            //<span class="form-name">First name</span>
            //<input class="form-input">
            var userName = TestObject.New(SearchInfo.New("span", "first name"), SearchInfo.New("input"));
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_anchor_with_smart_search_extending_to_attribute_value_text()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            //<input aria-label="First name">
            ITestObject firstNameTextBox = TestObject.New(SearchInfo.New("input", "first name"));
            firstNameTextBox.SendKeys("Tester");
            var locators = firstNameTextBox.AllLocators;

            firstNameTextBox = TestObject.New(SearchInfo.New("input", "first na"));
            firstNameTextBox.SendKeys("Tester");
            locators = firstNameTextBox.AllLocators;

            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_anchor_using_anchor_own_text()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.OwnText("first name"), SearchInfo.New("input"));
            userName.SendKeys("Automation");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Use_anchor_dynamic_content_making_one_test_object_representing_two_web_elements()
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
        public void Use_SetDynamicContents()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'{0}')]]/input");
            userName.SetDynamicContents("First name").MoveToElement().SendKeys("TesterTester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Use_single_driver_auto_created_by_driver_pool_and_a_user_created_driver()
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
        public void Find_by_anchor_with_defining_test_object_using_new_key_word()
        {
            ManagedDriver currentDriver = DriverPool.Instance.ActiveDriver;
            currentDriver.LaunchPage("https://www.xero.com/au/signup/");

            ITestObject userName = new TestObject()
            {
                AnchorElementInfo = SearchInfo.New("span", "{0}"),
                SearchElementInfo = SearchInfo.New("input"),
                DynamicContents = new List<string>() { "First name" }
            };

            userName.SendKeys("Automation");
            userName.SetAnchorDynamicContents("Last name");
            userName.SendKeys("Tester");
            DriverPool.Instance.Quit(currentDriver);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_xpath_with_defining_test_object_using_new_key_word()
        {
            ManagedDriver currentDriver = DriverPool.Instance.ActiveDriver;
            currentDriver.LaunchPage("https://www.xero.com/au/signup/");

            ITestObject userName = new TestObject()
            {
                Locator = "//label[span[contains(text(),'{0}')]]/input",
                DynamicContents = new List<string>() { "First name" }
            };

            userName.SendKeys("Automation").SetDynamicContents("Last name").SendKeys("Tester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Find_by_name_attribute_with_defining_test_object_using_new_key_word()
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
        public void Find_by_anchor_where_anchor_being_also_the_search_element()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            TestObject.New(SearchInfo.New("span", "Next")).Click().Click();
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Try_get_element_count_when_no_element_found()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            var button = TestObject.New(SearchInfo.New("span", "NextWrong"));

            if (button.TryGetElementCount(1) != 0)
            {
                button.Click();
            }

            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Get_element_count()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.Verify(() => Assert.IsTrue(elementCount == 1));
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Use_test_steps()
        {
            SampleSteps.Step1();
            SampleSteps.Step2("tester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Failed_the_last_step()
        {
            SampleSteps.Step1();
            SampleSteps.Step2("tester");
            SampleSteps.Step3();
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Failed_the_second_step()
        {
            SampleSteps.Step1();
            SampleSteps.Step3();
            SampleSteps.Step2("tester");
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Failed_assertion_with_user_added_message()
        {
            string expected = "Hello world!";
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            void assertion() => Assert.AreEqual(expected, actual);
            var assertionsAndUserAddedData = new KeyValuePair<Action, string>(assertion, $"Expected: {expected} | Actual: {actual}");
            TestReport.Verify(assertionsAndUserAddedData);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Failed_finding_by_anchor_when_element_is_not_found()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            TestObject.New(SearchInfo.New("span", "NextWrong")).Click();
            TestReport.Report().QuitActiveDriver();
        }
    }
}