using System;
using Okapi.Configs;
using Okapi.Enums;

namespace OkapiTests
{
    internal class LocalChromeTestEnvironment : ITestEnvironment
    {
        public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
        public Uri SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
        public bool Log => true;
        public bool TakeSnapshotOnOK => true;
        public bool TakeSnapshotOnError => true;
        public string SnapshotLocation => "Snapshots";
        public bool RemoteDriver => false;
    }
}