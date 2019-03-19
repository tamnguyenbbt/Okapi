using System;
using Okapi.Configs;
using Okapi.Enums;

namespace OkapiSampleTests.Configurations
{
    public class LocalChromeTestEnvironment : ITestEnvironment
    {
        public static LocalChromeTestEnvironment Instance => new LocalChromeTestEnvironment();
        DriverFlavour ITestEnvironment.DriverFlavour => DriverFlavour.Chrome;
        Uri ITestEnvironment.SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
    }
}