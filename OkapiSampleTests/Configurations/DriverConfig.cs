using ExtSelenium.DomCore;
using Okapi.Configs;

namespace OkapiSampleTests.Configurations
{
    internal class DriverConfig : IDriverConfig
    {
        public int TimeoutInSeconds => 10;
        public bool QuitDriverOnError => true;
        public DomUtilConfig SearchByAnchorConfig => null;
    }
}
