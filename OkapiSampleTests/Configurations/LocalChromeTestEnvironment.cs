using System;
using Okapi.Configs;
using Okapi.Enums;

namespace OkapiTests
{
    internal class LocalChromeTestEnvironment : ITestEnvironment
    {
        public static LocalChromeTestEnvironment Instance => new LocalChromeTestEnvironment();
        public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
        public Uri SeleniumHubUri => new Uri("http://localhost:4444/wd/hub");
        public bool Log => true;
    }
}
