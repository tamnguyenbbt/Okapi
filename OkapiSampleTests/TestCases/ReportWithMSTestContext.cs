using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Report;
using Okapi.Support.Report.MSTest;

namespace OkapiSampleTests.TestCases
{
    [TestClass]
    public class ReportWithMSTestContext
    {
        private static TestContext classTestContext;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            classTestContext = context;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestInit()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestReport.Report(TestContext.ToOkapiTestContext());
            DriverPool.Instance.QuitActiveDriver();
        }

        [TestMethod]
        [TestCase]
        public void Passed_test()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.IsTrue(elementCount == 1);
        }

        [TestMethod]
        [TestCase]
        public void Failed_test()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.IsTrue(elementCount == 2, $"Number of found elements: {elementCount}");
        }
    }
}