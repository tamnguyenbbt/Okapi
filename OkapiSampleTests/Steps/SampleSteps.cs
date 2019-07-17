using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Report;
using OkapiSampleTests.TestData;

namespace OkapiSampleTests.Steps
{
    public class SampleSteps
    {
        [Step]
        public static void Use_data(Registration registration)
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys(registration.UserName);
            TestReport.Report();
        }

        [Step]
        public static void Step1()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            TestReport.Report();
        }

        [Step]
        public static void Step2(string data)
        {
            TestObject.New(SearchInfo.OwnText("first Name"), SearchInfo.New("input")).SendKeys(data);
            TestReport.Report();
        }

        [Step]
        public static void Step3()
        {
            var userName = TestObject.New("//label[span[contains(text(),'NO NAME')]]/input");
            userName.SendKeys("tester");
            TestReport.Report();
        }

        [Step]
        public static void Loop_scenario(Registration registration)
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys(registration.UserName);
            TestReport.Report().QuitActiveDriver();
        }
    }
}