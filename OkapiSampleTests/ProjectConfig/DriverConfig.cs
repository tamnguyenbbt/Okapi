using ExtSelenium.DomCore;
using Okapi.Configs;

namespace OkapiSampleTests.ProjectConfig
{
    internal class DriverConfig : IDriverConfig
    {
        public int TimeoutInSeconds => 5;
        public bool QuitDriverOnError => true;
        public DomUtilConfig SearchByAnchorConfig => null;
    }
}