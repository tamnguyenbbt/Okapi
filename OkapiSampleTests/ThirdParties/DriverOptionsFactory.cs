using Okapi.Drivers;
using Okapi.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace OkapiSampleTests.ThirdParties
{
    internal sealed class DriverOptionsFactory : IDriverOptionsFactory
    {
        public DriverOptions CreateDriverOptions(DriverFlavour driverFlavour)
        {
            switch (driverFlavour)
            {
                case DriverFlavour.Edge:
                    return new EdgeOptions();
                case DriverFlavour.IE:
                    return new InternetExplorerOptions();
                case DriverFlavour.Firefox:
                    return new FirefoxOptions();
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--no-sandbox");
                    return chromeOptions;
            }
        }
    }
}