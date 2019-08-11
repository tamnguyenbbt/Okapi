using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Report;

namespace OkapiSampleTests.TestCases
{
    [TestClass]
    public class ReportIndividually
    {
        [TestMethod]
        [TestCase]
        public void Passed_test()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.IsTrue(elementCount == 1);
            TestReport.Report().QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Failed_test()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.IsTrue(elementCount == 2, $"Number of found elements: {elementCount}");
            TestReport.Report();
            DriverPool.Instance.QuitAllDrivers();
        }
    }
}