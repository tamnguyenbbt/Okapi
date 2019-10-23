using NUnit.Framework;
using Okapi.Drivers;
using Okapi.Extensions;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.TestCases
{
    [TestFixture]
    public class ReusableDriver
    {
        private Token token = null;

        [Test]
        [@TestCase]
        public void Test_1_using_regular_managed_driver_not_closed_at_end_of_the_test()
        {
            IManagedDriver managedDriver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");
            token = managedDriver.Token;
            "<input> `{0}`".GetTestObject("First name").SendKeys("John");
        }

        [Test]
        [@TestCase]
        public void Test_2_running_after_test_1_using_memory_token_reusable_driver()
        {
            DriverPool.Instance.CreateReusableDriver(token.RemoteServerUri, token.SessionId);
            "<input> `{0}`".GetTestObject("surname").SendKeys("Doe");
        }

        [Test]
        [@TestCase]
        public void Test_3_running_after_test_1_and_2_in_another_execution_session()
        {
            //very useful during script development and debugging; no need to run everything again from beginning
            DriverPool.Instance.CreateReusableDriverFromLastRun(); 
            "`Sign Up`".GetTestObject().Click();
        }
    }
}
