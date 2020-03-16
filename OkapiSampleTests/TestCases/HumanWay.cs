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
    public class HumanWay
    {
        private IManagedDriver driver = null;

        [OneTimeSetUp]
        public void ClassInit()
        {
            driver = DriverPool.Instance.ActiveDriver.SetTimeoutInSeconds(2).LaunchPage("https://www.facebook.com/reg");
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            DriverPool.Instance.QuitActiveDriver();
        }

        [TearDown]
        public void TestCleanup()
        {
            TestReport.Report(TestContext.CurrentContext.ToOkapiTestContext());
        }

        [Test]
        [TestCase]
        public void Test1()
        {
            TestObject.New("<input> `First name`").SendKeys("tester");
        }

        [Test]
        [TestCase]
        public void Test2()
        {
            TestObject.New("<input> `{0}`").SetDynamicContents("First name").SendKeys("tester");
        }

        [Test]
        [TestCase]
        public void Test3()
        {
            TestObject.New("search element with tag <input> and text `{0}`").SetDynamicContents("First name").SendKeys("tester");
        }

        [Test]
        [TestCase]
        public void Test4()
        {
            ITestObject birthDayDropDown = ListBox.New("anchor <div> `Birthday`, search <select> `{0}`").SetSearchElementDynamicContents("Day");
            (birthDayDropDown as ListBox).SelectByValue("7");
        }

        [Test]
        [TestCase]
        public void Test5()
        {
            ITestObject birthDayDropDown = ListBox
                .New("I want to set anchor text as `Birthday` and tag as <div>, then search element tag as <select> and text as `{0}`")
                .SetSearchElementDynamicContents("Day");
            (birthDayDropDown as ListBox).SelectByValue("7");
        }

        [Test]
        [TestCase]
        public void Test6()
        {
            ITestObject birthDayDropDown = ListBox
                .New("I want to set search element tag as <select> and text as `{0}`; anchor text as `Birthday` and tag as <div>")
                .SetSearchElementDynamicContents("Day");
            (birthDayDropDown as ListBox).SelectByValue("7");
        }
    }
}