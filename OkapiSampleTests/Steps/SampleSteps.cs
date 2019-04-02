using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Report;
using OkapiSampleTests.TestData;

namespace OkapiTests
{
    public class SampleSteps
    {
        [Step]
        public static void Sample_scenario(Registration registration)
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys(registration.UserName);
            TestReport.Report();
        }

        [Step]
        public static void Step1(string expected)
        {
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            TestReport.Verify(() => Assert.AreEqual(expected, actual), $"Expected: {expected} | Actual: {actual}");
            TestReport.Report();
        }

        [Step]
        public static void Step2(string expected)
        {
            string actual = TestObject.New(SearchInfo.OwnText("Try Xero FREE for 30 days!")).Text;
            TestReport.Verify(() => Assert.AreEqual(expected, actual), $"Expected: {expected} | Actual: {actual}");
            TestReport.Report();
        }
    }
}