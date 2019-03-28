using Okapi.Drivers;
using Okapi.Elements;
using OkapiSampleTests.TestData;

namespace OkapiTests
{
    public class SampleScenarios
    {
        public static void Sample_scenario(Registration registration)
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
            var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
            userName.SendKeys(registration.UserName);
            DriverPool.Instance.QuitActiveDriver();
        }
    }
}