using ExtSelenium.DomCore;
using Okapi.Configs;

namespace OkapiSampleTests.ProjectConfig
{
    internal class DriverConfig : IDriverConfig
    {
        public int TimeoutInSeconds => 2;
        public bool QuitDriverOnError => true;
        public bool QuitDriverOnFailVerification => true;
        public DomUtilConfig SearchByAnchorConfig => null;        
    }
}