using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Drivers;
using Okapi.Elements;

namespace OkapiTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void Test1()
        {
            DriverPool.Instance.ActiveDriver.LauchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New(SearchInfo.New("span", "{0}"), SearchInfo.New("input"), DynamicContents.New("First name"));
            userName.SendKeys("Automation");
            userName.DynamicContents = DynamicContents.New("Last name");
            userName.SendKeys("Tester");
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        public void Test2()
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