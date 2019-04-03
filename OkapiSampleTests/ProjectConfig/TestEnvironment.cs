using System;
using Okapi.Configs;
using Okapi.Enums;

namespace OkapiSampleTests.ProjectConfig
{
    internal class TestEnvironment : ITestEnvironment
    {
        public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
        public Uri SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
        public bool Log => false;
        public bool QuitDriverOnError => true;
        public bool QuitDriverOnFailVerification => true;
        public bool TakeSnapshotOnOK => false;
        public bool TakeSnapshotOnError => true;
        public string SnapshotLocation => "Snapshots";
        public bool RemoteDriver => false;
    }
}
