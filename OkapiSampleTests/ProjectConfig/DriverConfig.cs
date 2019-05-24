using ExtSelenium.DomCore;
using Okapi.Configs;

namespace OkapiSampleTests.ProjectConfig
{
    internal class DriverConfig : IDriverConfig
    {
        public double TimeoutInSeconds => 10;
        public DomUtilConfig SearchByAnchorConfig => null;
    }
}