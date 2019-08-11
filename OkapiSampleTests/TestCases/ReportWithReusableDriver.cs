using NUnit.Framework;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Enums;
using Okapi.Report;
using Okapi.Support.Report.NUnit;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.TestCases
{
    [TestFixture]
    //Try to run all the tests in this class and see Html report at [Project Folder]/Report
    public class ReportWithReusableDriver
    {
        private ITestObject genericTextBox = TestObject.New(SearchInfo.New(HtmlTag.input, "{0}"));

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
        public void Test_1_passed()
        {
            DriverPool.Instance.ActiveDriver.SetTimeoutInSeconds(3).LaunchPage("https://accounts.google.com/signup");
            //Not worried about entering the exact word 'First name' in 'SetDynamicContents' when smart search is turned on in App.config
            genericTextBox.SetDynamicContents("first na").SendKeys("John");
            Enter_username("john.doe");
        }

        [Test]
        [TestCase]
        //Test2 continues from what Test1 has done but not necessary in the same execution. 
        //That means that you can run Test1 first; then run Test2 in the second execution.
        //This can be achieved using 'ReusableDriverFromLastRun' as long as the browser opened by Test1 is kept opened
        //and W3C mode is turned off or turned off by default. 
        //Chrome driver versions before 73 have W3C mode turned off by default so they can be used to test this one.
        //https://chromedriver.storage.googleapis.com/index.html?path=72.0.3626.7/
        public void Test_2_failed_unable_to_find_last_name_text_box()
        {
            DriverPool.Instance.CreateReusableDriverFromLastRun().SetTimeoutInSeconds(3);
            Enter_password("password is password");
            genericTextBox.SetDynamicContents("Last name1111").SendKeys("Doe");
        }

        [Test]
        [TestCase]
        public void Test_3_failed_because_test_2_closed_the_driver_on_failure()
        {
            DriverPool.Instance.CreateReusableDriverFromLastRun().SetTimeoutInSeconds(3);
            TestObject.New(SearchInfo.New(HtmlTag.span, "Next")).Click();
        }

        [Step]
        //This step is decorated with attribute [Step] and ended with 'TestReport.Report();' so it will be reported
        private void Enter_username(string userName)
        {
            genericTextBox
                .SetDynamicContents("Username")
                .SendKeys(userName);
            TestReport.Report();
        }

        [Step]
        //This step is decorated with attribute [Step] and closed with 'TestReport.Report();' so it will be reported
        private void Enter_password(string password)
        {
            genericTextBox
                .SetDynamicContents("Password")
                .SendKeys(password);
            TestReport.Report();
        }
    }
}