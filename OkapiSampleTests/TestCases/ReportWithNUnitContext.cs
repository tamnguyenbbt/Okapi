using NUnit.Framework;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Report;
using Okapi.Support.Report.NUnit;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.TestCases
{
    [TestFixture]
    public class ReportWithNUnitContext
    {
        [OneTimeSetUp]
        public static void ClassInit()
        {
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
        }

        [SetUp]
        public void TestInit()
        {
        }

        [TearDown]
        public void TestCleanup()
        {
            TestReport.Report(TestContext.CurrentContext.ToOkapiTestContext());
            DriverPool.Instance.QuitActiveDriver();
        }

        [Test]
        [TestCase]
        public void Test1()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.IsTrue(elementCount == 1);
        }

        [Test]
        [TestCase]
        public void Test2()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://accounts.google.com/signup");
            int elementCount = TestObject.New(SearchInfo.New("span", "Next")).ElementCount;
            TestReport.IsTrue(elementCount == 2, $"Number of found elements: {elementCount}");
        }
    }
}