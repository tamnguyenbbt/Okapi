using ExtSelenium.DomCore;
using Okapi.Configs;

namespace OkapiSampleTests.ProjectConfig
{
    internal class DriverConfig : IDriverConfig
    {
        public int TimeoutInSeconds => 10;
        public DomUtilConfig SearchByAnchorConfig => null;
    }
}