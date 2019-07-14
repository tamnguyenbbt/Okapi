using System;
using System.IO;
using Okapi.Configs;
using Okapi.Enums;
using Okapi.Utils;

namespace OkapiSampleTests.ProjectConfig
{
    internal class TestEnvironment : ITestEnvironment
    {
        public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
        public Uri SeleniumHubUri => new Uri("http://localhost:2021/wd/hub");
        public bool Log => true;
        public bool QuitDriverOnError => true;
        public bool QuitDriverOnFailVerification => true;
        public bool TakeSnapshotOnOK => false;
        public bool TakeSnapshotOnError => true;
        public string SnapshotLocation => "Snapshots";
        public bool RemoteDriver => false;
        public bool SmartSearch => true;
        public string ReportDirectory => $"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}Report";
        public string LogPath => $"{Util.ParentProjectDirectory}{Path.DirectorySeparatorChar}Log.txt";
    }
}